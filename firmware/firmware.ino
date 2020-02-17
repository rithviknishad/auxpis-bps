#include <Wire.h>
#include <Adafruit_INA219.h>
#include <Adafruit_GFX.h>
#include <MCUFRIEND_kbv.h>
#include <TouchScreen.h>

/*
    Units Definitions
*/

#define unit  * 1
#define milli *(1e-3)
#define micro *(1e-6)

#define s   unit
#define ms  milli
#define us  micro

#define A   unit
#define mA  milli
#define uA  micro

#define V   unit
#define mV  milli
#define uV  micro

#define W   unit
#define mW  milli
#define uW  micro

#define Wh  unit
#define mWh milli
#define uWh micro


typedef Adafruit_GFX_Button button;

// touchscreen parameters
static const int XP = 8, XM = A2, YP = A3, YM = 9; // TS pins
static const int TS_LEFT = 919, TS_RT = 98, TS_TOP = 866, TS_BOT = 190; // TS CALIB BOUNDS

MCUFRIEND_kbv screen;
TouchScreen touchscreen = TouchScreen(8, A3, A2, 9, 300);
Adafruit_INA219 power_meter;


/*
    GLOBAL SYSTEM PARAMETERS
*/

#define VOUT_LIMIT 26   V
#define IOUT_LIMIT 3200 mA


/*
    SERIAL REPORT BIT REGISTER

    +-------------------------------------------------------------------------------+
    | SR | MS | VO | TP | VNB | I  | P  | E | OM | TM | PWMPBNB | VS | VL | EF | LE |
    | 15 | 14 | 13 | 12 |  11 | 10 | 09 | 8 |  7 |  6 |  5 | 4  |  3 |  2 |  1 |  0 |
    +-------------------------------------------------------------------------------+
    
    SR  -> SERIAL REPORT (Report periodically)
    MS  -> MILLISECONDS (Uptime of system in milliseconds, obtained from millis())
    VO  -> INSTANT OUTPUT VOLTAGE
    TP  -> TARGET PARAMETERS (VoutMax, IoutMax_mA)
    VNB -> INSTANT NEGATIVE BOOST VOLTAGE (Negative Elevated Voltage w/ reference to 0 / GND)
    I   -> INSTANT OUTPUT CURRENT (Load Current)
    P   -> INSTANT LOAD POWER CONSUMPTION
    E   -> ENERGY CONSUMED BY LOAD (OP)
    OM  -> OPERATING MODE (BBCMR Register)
    TM  -> PB_MOSFET TEMPERATURE
    ~PB -> INSTANT PWM VALUE (P BOOST)
    ~NB -> INSTANT PWM VALUE (N BOOST)
    VS  -> INSTANT SHUNT VOLTAGE
    VL  -> INSTANT LOAD VOLTAGE (ie, V(output_terminals) + V(shunt))
    EF  -> INSTANT EFFICIENCY
    LE  -> ENERGY TRANSFERRED TO LOAD (IP)
*/
#define SR              1 << 15
#define SR_Millis       1 << 14
#define SR_Vout         1 << 13
#define SR_TargetParam  1 << 12
#define SR_VNB          1 << 11
#define SR_Current      1 << 10
#define SR_Power        1 << 09
#define SR_Energy       1 << 08
#define SR_Mode         1 << 07
#define SR_Temperature  1 << 06
#define SR_PB_PWM       1 << 05
#define SR_NB_PWM       1 << 04
#define SR_ShuntV       1 << 03
#define SR_Vload        1 << 02
#define SR_Efficiency   1 << 01
#define SR_LoadEnergy   1 << 00

unsigned int SRB = SR | SR_Vout | SR_Current | SR_Power | SR_Efficiency | SR_CCV;


// sotres current cursor location
static int cursor_x, cursor_y;

// returns if screen is touched or not
bool touched()
{
    TSPoint point = touchscreen.getPoint();
    pinMode(YP, OUTPUT);
    pinMode(XM, OUTPUT);
    digitalWrite(YP, 1);
    digitalWrite(XM, 1);

    bool pressed = (point.z > 40 && < 1000);

    if (pressed)
    {
        cursor_x = map(point.y, TS_LEFT, TS_RT, 0, screen.width());
        cursor_y = map(point.x, TS_TOP, TS_BOT, 0, screen.height());
    }

    return pressed;
}

// screen color defines
#define BLACK   0x0000
#define BLUE    0x001F
#define RED     0xF800
#define GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0
#define WHITE   0xFFFF

// returns the appropriate color value for RGB value
int colorFromRGB(int red, int green, int blue)
{
    return (int(red * 0.125) << 11) | (int(green * 0.25) << 5) | int(blue * 0.125);
}

typedef const int PIN;
static PIN PIN_FET_BOOST    = 10;
static PIN PIN_FET_BUCK     = 11;
static PIN PIN_VIN_SENSE    = A6;
static PIN PIN_NBOOST_SENSE = A7;
static PIN PIN_RELAY        = 12;
static PIN_STATUS_LED       = 13

// Initializes the Input Output pins and updates timer registers
void InitializeIO() 
{
    // set timer register's prescalers of FET control pins to maximize performance
    TCCR2A = TCCR2A & B11111000 | B00000001;
    TCCR1B = TCCR1B & B11111000 | B00000001;

    Serial.println("[1] Updated Timer Register Prescalers.");

    // set pin modes of IO pins (other device's pins initialized and handled by libraries)
    pinMode(PIN_FET_BOOST, OUTPUT);
    pinMode(PIN_FET_BUCK, OUTPUT);
    
    analogWrite(PIN_FET_BOOST, 0);
    analogWrite(PIN_FET_BUCK, 0);

    pinMode(PIN_PBOOST_SENSE, INPUT);
    pinMode(PIN_NBOOST_SENSE, INPUT);
    
    pinMode(PIN_RELAY, OUTPUT);
    pinMode(PIN_STATUS_LED, OUTPUT);

    digitalWrite(PIN_RELAY, LOW);
    digitalWrite(PIN_STATUS_LED, HIGH);

    Serial.println("[1] Updated IO registers");
}

void InitializeSystem() 
{    
    Serial.begin(115200);
    
    Serial.println("AUXPIS POWER SUPPLY");
    Serial.println("Version 2020.02.16 [Alpha]");
    Serial.println("Product Licensed under MIT License. See LICENSE.md at: https://github.com/rithviknishad/auxpis-bps/ \n");

    Serial.println("Initializing system...");
    
    InitializeIO();

    power_meter.begin();
    Serial.println("[1] Power Meter [INA219] sensor initialized.");

    screen.begin(screen.readID() == 0xD3D3 ? 0x9486 : screen.readID());
    screen.setRotation(1);
    screen.fillScreen(colorFromRGB(20, 20, 20));
    Serial.println("[1] Built-in display initialized.");

    /// add restriction code for low inupt voltage...
}

void setup() 
{
    InitializeSystem();

    delay(1000);
    Serial.print("AUXPIS Power Supply is ready for use.\n>");
    digitalWrite(PIN_STATUS_LED, 0);

}


// stores the last update time for external activities
unsigned long external_last_millis = 0;
unsigned long internal_last_millis = 0;

/*
    BUCK BOOST CONSTANTS MODE REGISTER

    +-------------------------------------------+
    |     |     |     |     | CV | CC | BS | BK |
    |  7  |  6  |  5  |  4  | 3  | 2  |  1 | 0  |
    +-------------------------------------------+
*/

#define BUCK    1 << 0
#define BOOST   1 << 1
#define CC      1 << 2
#define CV      1 << 3

unsigned char BBCMR = BUCK | CV;

float Vin = 0;  // input source voltage.
float UVLOT = 7;

// user control params
float VoutMax = 0;
float IoutMax_mA = 1e+3;

float Vnb = 0;

float Vout = 0;
float Iout_mA = 0;
float Vshunt_mV = 0;
float Power = 0;
float Energy = 0;

float Vload = 0;
float LoadPower = 0;
float LoadEnergy = 0;

float Efficiency = 0;

short NB_PWM = 0;
short PB_PWM = 0;

void UpdateSerialReport()
{
    if (SerialReport)
    {
        if (SerialReport_Millis)
        {
            Serial.print(millis());
            Serial.print(" ");
        }

        // report cc cv state...

        if (SerialReport_Vout)
        {
            Serial.print("VO = ");
            /// report voltage...
            Serial.print(" ");
        }

        if (SerialReport_VPB)
        {
            Serial.print("VPB = ");
            /// report voltage...
            Serial.print(" ");
        }

        if (SerialReport_VNB)
        {
            Serial.print("VNB = ");
            /// report voltage...
            Serial.print(" ");
        }

        if (SerialReport_Current)
        {
            Serial.print("I = ");
            /// report voltage...
            Serial.print(" ");
        }

        if (SerialReport_Power)
        {
            Serial.print("PWR = ");
            /// report voltage...
            Serial.print(" ");
        }

        if (SerialReport_Energy)
        {
            Serial.print("E = ");
            /// report voltage...
            Serial.print(" ");
        }


        Serial.println(";");
    }
}

void UpdateDisplay()
{
    
}

void UpdateExternals()
{
    Vin = analogRead(PIN_VIN_SENSE) * k1; /// edit
    if (Vin < UVLOT)
    {
        BBCMR &= ~(BOOST | BUCK);
        return;
    }

    Vnb = analogRead(PIN_NBOOST_SENSE) * k2; /// edit
    
    // sets BUCK or BOOST mode w/ ref to input w/ crossover point compensation being considered.
    BBCMR = VoutMax < Vin - 0.5 ? BBCMR & ~BOOST | BUCK : BBCMR & ~BUCK | BOOST;


    Vshunt_mV = power_meter.getShuntVoltage_mV();
    Power = Vout * Iout_mA mA;
    Vload = Vout + (Vshunt_mV mV);
    LoadPower = Vload * Iout_mA mA;
    Efficiency = Power / LoadPower;

    UpdateSerial();
    UpdateDisplay();

    // shuts BOOST and BUCK channel if Vin less than UVLO Threshold
    

    digitalWrite(PIN_STATUS_LED, !digitalRead(PIN_STATUS_LED));
}


// BUCK AND BOOST PWM WRITE COMMANDS w/ BOUNDARY LOCKING
#define BUCK_HIGHER analogWrite(PIN_FET_BUCK, NB_PWM == 255 ? NB_PWM : ++NB_PWM)
#define BUCK_LOWER analogWrite(PIN_FET_BUCK, NB_PWM ? --NB_PWM : NB_PWM)
#define BOOST_HIGHER analogWrite(PIN_FET_BOOST, PB_PWM == 220 ? PB_PWM : ++PB_PWM)
#define BOOST_LOWER analogWrite(PIN_FET_BOOST, PB_PWM ? --PB_PWM : PB_PWM)

void UpdateInternal()
{
    // get delta time from last update
    static unsigned short delta_millis_internal = millis() - internal_last_millis;

    // read priority parameters (V and I)
    Vout = power_meter.getBusVoltage_V() - (BBCMR & BUCK ? analogRead(PIN_NBOOST_SENSE) * k2 : 0);
    Iout_mA = power_meter.getCurrent_mA();
    
    // CV register update
    BBCMR = (Vout >= VoutMax ? BBCMR | CV : BBCMR & ~CV);
    // CC register update
    BBCMR = (Iout_mA >= IoutMax_mA ? BBCMR | CC : BBCMR & ~CC);


    // update buck channel
    if (BBCMR & BUCK)
    {
        if (Iout_mA > IoutMax_mA || Vout > VoutMax)
            BUCK_LOWER; // decrements BUCK PWM if MAX limit is hit by any (V or I)
        else if (Vout < VoutMax && Iout_mA < IoutMax_mA)
            BUCK_HIGHER; // increments BUCK PWM if both max limit is not hit by any (V or I)
    }
    else if (NB_PWM) // single channel locking
        analogWrite(PIN_FET_BUCK, NB_PWM = 0);


    // update boost channel
    if (BBCMR & BOOST)
    {
        if (Iout_mA > IoutMax_mA || Vout > VoutMax)
            BOOST_LOWER; // decrements BOOST PWM if MAX limit is hit by any (V or I)
        else if (Vout < VoutMax && Iout_mA < IoutMax_mA)
            BOOST_HIGHER; // increments BOOST PWM if both max limit is not hit by any (V or I)
    }
    else if (PB_PWM) // single channel locking
        analogWrite(PIN_FET_BOOST, PB_PWM = 0);


    // integral Power over time -> Energy update
    Energy += Vout * Iout_mA mA * delta_millis ms;
    // update internal_last_millis for next internal update
    internal_last_millis += delta_millis_internal;
}

void loop() 
{
    UpdateInternal();

    if (millis() - external_last_millis > 200)
    {
        UpdateExternals();
        external_last_millis = millis();
    }
}

