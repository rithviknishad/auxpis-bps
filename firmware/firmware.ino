#include <Wire.h>
#include <Adafruit_INA219.h>
#include <Adafruit_GFX.h>
#include <MCUFRIEND_kbv.h>
#include <TouchScreen.h>

// fonts included
#include <Fonts/Org_01.h>


/*
    Units Definitions
*/

#define unit  * 1
#define milli *(1e-3)

#define s   unit
#define ms  milli

#define A   unit
#define mA  milli

#define V   unit
#define mV  milli

#define W   unit
#define mW  milli

#define Wh  unit
#define mWh milli

typedef Adafruit_GFX_Button button;

// touchscreen parameters
#define XP      8
#define XM      A2
#define YP      A3
#define YM      9
#define TS_LEFT 919
#define TS_RT   98
#define TS_TOP  866
#define TS_BOT  190

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
    VI  -> VOLTAGE INPUT
    PWM -> PWM SIGNALS
    VS  -> INSTANT SHUNT VOLTAGE
    VL  -> INSTANT LOAD VOLTAGE (ie, V(output_terminals) + V(shunt))
    EF  -> INSTANT EFFICIENCY
    LE  -> ENERGY TRANSFERRED TO LOAD (IP)
*/
#define SR              (1 << 15)
#define SR_Millis       (1 << 14)
#define SR_Vout         (1 << 13)
#define SR_TargetParam  (1 << 12)
#define SR_VNB          (1 << 11)
#define SR_Current      (1 << 10)
#define SR_Power        (1 << 9)
#define SR_Energy       (1 << 8)
#define SR_Mode         (1 << 7)
#define SR_Temperature  (1 << 6)
#define SR_VIN          (1 << 5)
#define SR_PWM          (1 << 4)
#define SR_ShuntV       (1 << 3)
#define SR_Vload        (1 << 2)
#define SR_Efficiency   (1 << 1)
#define SR_LoadEnergy   (1 << 0)

unsigned int SRR = SR | SR_Millis | SR_Vout | SR_TargetParam | SR_VNB | SR_Current | SR_Power | SR_Energy | SR_Mode | SR_Temperature | SR_PWM | SR_VIN | SR_ShuntV | SR_Vload | SR_Efficiency | SR_LoadEnergy;

/*
    BUCK BOOST CONSTANTS MODE REGISTER

    +-------------------------------------------+
    |     |     |     |UVLO| CV | CC | BS | BK |
    |  7  |  6  |  5  |  4 | 3  | 2  |  1 | 0  |
    +-------------------------------------------+
*/

#define BUCK    (1 << 0)
#define BOOST   (1 << 1)
#define CC      (1 << 2)
#define CV      (1 << 3)
#define UVLO    (1 << 4)

unsigned char BBCMR = 0;


float Vin = 0;
float UVLOT = 4;

// user control params
float VoutMax = 0;
float IoutMax_mA = 0;

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

    if (point.z > 40 && point.z < 1000)
    {
        cursor_x = map(point.y, TS_LEFT, TS_RT, 0, screen.width());
        cursor_y = map(point.x, TS_TOP, TS_BOT, 0, screen.height());

        return true;
    }

    return false;
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
#define colorFromRGB(red, green, blue) (int(red * 0.125) << 11) | (int(green * 0.25) << 5) | int(blue * 0.125)

#define PIN_FET_BOOST       10
#define PIN_FET_BUCK        11
#define PIN_VIN_SENSE       A7
#define PIN_NBOOST_SENSE    A6
#define PIN_RELAY_P         23 // PORTA 4
#define PIN_RELAY_N         22
#define PIN_STATUS_LED      13

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

    pinMode(PIN_VIN_SENSE, INPUT);
    pinMode(PIN_NBOOST_SENSE, INPUT);
    
    pinMode(PIN_RELAY_P, OUTPUT);
    pinMode(PIN_RELAY_N, OUTPUT);
    pinMode(PIN_STATUS_LED, OUTPUT);

    digitalWrite(PIN_RELAY_P, LOW);
    digitalWrite(PIN_RELAY_N, LOW);
    digitalWrite(PIN_STATUS_LED, HIGH);

    Serial.println("[1] Updated IO registers");
}


button buttons_numpad[4][3];
button buttons_voltage;
button buttons_current;

void InitializeDisplay()
{
    screen.begin(screen.readID() == 0xD3D3 ? 0x9486 : screen.readID());
    screen.setRotation(3);

    //screen.setFont(&Org_01);

#define npX 240
#define npY 20
#define npHeight 70
#define npWidth 70
#define npSize npWidth, npHeight
#define npSpacing 4
#define getNPPos(i, j) npX + ((npWidth + npSpacing) * j), npY + ((npHeight + npSpacing) * i)

    screen.fillScreen(colorFromRGB(20, 20, 20));

    for (int i = 0; i < 4; ++i)
    {
        for (int j = 0; j < 3; ++j)
        {
            char npstr[2];
            int npVal = i * 3 + j + 1;

            if (npVal == 10)
                buttons_numpad[i][j].initButtonUL(&screen, getNPPos(i, j), npSize, colorFromRGB(19, 19, 24), colorFromRGB(40, 41, 45), colorFromRGB(47, 163, 196), "X", 4);
            else if (npVal == 11)
                buttons_numpad[i][j].initButtonUL(&screen, getNPPos(i, j), npSize, colorFromRGB(19, 19, 24), colorFromRGB(40, 41, 45), colorFromRGB(47, 163, 196), "0", 4);
            else if (npVal == 12)
                buttons_numpad[i][j].initButtonUL(&screen, getNPPos(i, j), npSize, colorFromRGB(19, 19, 24), colorFromRGB(40, 41, 45), colorFromRGB(47, 163, 196), ">", 4);
            else
                buttons_numpad[i][j].initButtonUL(&screen, getNPPos(i, j), npSize, colorFromRGB(19, 19, 24), colorFromRGB(40, 41, 45), colorFromRGB(47, 163, 196), itoa(npVal, npstr, 10), 4);
        }
    }

    buttons_voltage.initButtonUL(&screen, 20, 20, 200, 70, colorFromRGB(100, 100, 100), colorFromRGB(20, 20, 20), colorFromRGB(100, 100, 100), "        V", 3);
    buttons_current.initButtonUL(&screen, 20, 120, 200, 70, colorFromRGB(100, 100, 100), colorFromRGB(20, 20, 20), colorFromRGB(100, 100, 100), "       mA", 3);

    Serial.println("[1] Built-in display initialized.");
}

void InitializeSystem() 
{    
    Serial.begin(115200);
    
    Serial.println("AUXPIS POWER SUPPLY");
    Serial.println("Version 2020.02.16 [Alpha]");
    Serial.println("Product Licensed under MIT License. See LICENSE.md at: https://github.com/rithviknishad/auxpis-bps/ \n");

    Serial.println("Initializing system...");
    
    InitializeIO();

    //power_meter.begin();
    //Serial.println("[1] Power Meter [INA219] sensor initialized.");

    InitializeDisplay();

    /// add restriction code for low inupt voltage...
}

void DrawNumpad()
{
    for (int i = 0; i < 4; ++i)
        for (int j = 0; j < 3; ++j)
            buttons_numpad[i][j].drawButton();
}


void __drawParam_voltage(char* buff)
{
    static int last_pcnt = 0;
}

void DrawHomeScreenParams()
{
    char buff[10];

    static int last_vpcnt = 0;
    static int pcnt = 0;

    pcnt = 0;
    screen.setTextColor(colorFromRGB(200, 200, 200), colorFromRGB(20, 20, 20));
    screen.setTextSize(4);
    
    // Voltage
    screen.setCursor(40, 40);
    pcnt += screen.print(itoa((int)Vout % 30, buff, 10));
    pcnt += screen.print(".");
    pcnt += screen.print(itoa((int)(Vout * 100) % 100, buff, 10));

    if (pcnt < last_vpcnt)
        buttons_voltage.drawButton();

    last_vpcnt = pcnt;

    pcnt = 0;

    // Current
    static int last_ipcnt = 0;
    screen.setCursor(40, 140);
    pcnt += screen.print(itoa((int)Iout_mA, buff, 10));

    if (pcnt < last_ipcnt)
        buttons_current.drawButton();

    last_ipcnt = pcnt;

    screen.setCursor(40, 200);
    screen.setTextSize(1);
    screen.print(BBCMR, BIN);

}

void DrawHomeScreen()
{
    buttons_voltage.drawButton();
    buttons_current.drawButton();

    DrawHomeScreenParams();

    DrawNumpad();
}

void setup() 
{
    InitializeSystem();

    delay(1000);
    Serial.println("AUXPIS Power Supply is ready for use.");

    DrawHomeScreen();
    digitalWrite(PIN_STATUS_LED, 1);

}


// stores the last update time for external activities
unsigned long external_last_millis = 0;
unsigned long internal_last_millis = 0;


void UpdateSerialReport()
{
    if (Serial.available() > 0)
    {
        static int readByte = 0;
        switch (Serial.read())
        {
        case 'V':
        case 'v':
            VoutMax = 0;
            Serial.print("\nSet Max Voltage [V] : ");
            
            while((readByte = Serial.read()) != ';')
            {
                readByte -= 48;
                if (readByte > -1 && readByte < 10)
                {
                    Serial.print(readByte);
                    VoutMax *= 10;
                    VoutMax += readByte;
                }
            }

            Serial.print("\nSet Max Voltage [mV] : ");
            
            static int milliVolts = 0;
            while((readByte = Serial.read()) != ';')
            {
                readByte -= 48;
                if (readByte > -1 && readByte < 10)
                {
                    Serial.print(readByte);
                    milliVolts *= 10;
                    milliVolts += readByte;
                }
            }

            VoutMax += milliVolts mV;

            Serial.print("\nVmax set to : ");
            Serial.println(VoutMax);
            break;
        

        case 'I':
        case 'i':
            IoutMax_mA = 0;
            Serial.print("\nSet Max Current [mA] : ");
            while((readByte = Serial.read()) != ';')
            {
                readByte -= 48;
                if (readByte > -1 && readByte < 10)
                {
                    Serial.print(readByte);
                    IoutMax_mA *= 10;
                    IoutMax_mA += readByte;
                }
            }

            Serial.print("\nMax Current set to : ");
            Serial.println(IoutMax_mA);
            break;

        case 'S':
            SRR = 0;
            Serial.print("\nEnter SRR Register Values: ");
            
            for (int i = 15; i > -1; --i)
            {
                if (Serial.available() > 0)
                    SRR |= ((Serial.read() - 48 ? 1 : 0) << i);
            }

            Serial.print("\nSRR=");
            Serial.println(SRR, BIN);

        default:
            break;
        }
    }


    if (SRR & SR)
    {
        if (SRR & SR_Millis)
        {
            Serial.print(millis());
            Serial.print("ms  ");
        }

        if (SRR & SR_Vout)
        {
            Serial.print("Vout=");
            Serial.print(Vout);
            Serial.print(" V  ");
        }

        if (SRR & SR_Current)
        {
            Serial.print("Iout=");
            Serial.print(Iout_mA);
            Serial.print(" mA  ");
        }

        if (SRR & SR_Power)
        {
            Serial.print("PWR=");
            Serial.print(Power);
            Serial.print(" W  ");
        }

        if (SRR & SR_Energy)
        {
            Serial.print("E=");
            Serial.print(Energy);
            Serial.print(" Wh  ");
        }

        if (SRR & SR_Mode)
        {
            Serial.print("BBCMR=");
            Serial.print(BBCMR, BIN);
            Serial.print("  ");
        }

        if (SRR & SR_Temperature)
        {
            //Serial.print("Temp= N/A"); // temperature feature
        }

        if (SRR & SR_VIN)
        {
            Serial.print("Vin=");
            Serial.print(Vin);
            Serial.print(" V  ");
        }

        if (SRR & SR_PWM)
        {
            Serial.print("~PB=0x");
            Serial.print(PB_PWM, HEX);
            Serial.print("  ~NB=0x");
            Serial.print(NB_PWM, HEX);
            Serial.print("  ");
        }

        if (SRR & SR_ShuntV)
        {
            Serial.print("Vshunt=");
            Serial.print(Vshunt_mV);
            Serial.print(" mV  ");
        }

        if (SRR & SR_Vload)
        {
            Serial.print("Vload=");
            Serial.print(Vload);
            Serial.print(" V  ");
        }

        if (SRR & SR_Efficiency)
        {
            Serial.print("ȵ=");
            Serial.print(Efficiency * 100);
            Serial.print("%  ");
        }

        if (SRR & SR_TargetParam)
        {
            Serial.print("Vmax=");
            Serial.print(VoutMax);
            Serial.print(" V  Imax=");
            Serial.print(IoutMax_mA);
            Serial.print(" mA  ");
        }

        if (SRR & SR_LoadEnergy)
        {
            Serial.print("Eload=");
            Serial.print(LoadEnergy);
            Serial.print(" Wh  ");
        }

        if (SRR & SR_VNB)
        {
            Serial.print("V(-Boost)=");
            Serial.print(Vnb);
            Serial.print(" V  ");
        }
        
        Serial.println("; ");
        
    }
}

#define k1 0.0322265625
#define k2 0.0322265625

void UpdateDisplay()
{
    DrawHomeScreenParams();
}

void UpdateExternals()
{
    Vin = analogRead(PIN_VIN_SENSE) * k1; /// edit
    Vnb = analogRead(PIN_NBOOST_SENSE) * k2; /// edit

    // update parameters
    Vshunt_mV = power_meter.getShuntVoltage_mV();
    Power = Vout * Iout_mA mA;
    Vload = Vout + (Vshunt_mV mV);
    LoadPower = Vload * Iout_mA mA;
    Efficiency = Power / LoadPower;

    UpdateSerialReport();
    UpdateDisplay();

    // shuts BOOST and BUCK channel if Vin less than UVLO Threshold and skips
    if (Vin < UVLOT)
    {
        BBCMR &= ~(BOOST | BUCK);
        BBCMR |= UVLO;
        return; //  B E W A R E , SKIPS ALL INSTRUCTIONS AFTER THIS IF UVLO ------
    }
    else if (BBCMR & UVLO)
        BBCMR &= ~UVLO;

    // sets BUCK or BOOST mode w/ ref to input w/ crossover point compensation being considered.
    BBCMR = ((VoutMax < (Vin - 0.5)) ? (BUCK | (BBCMR & ~BOOST)) : (BOOST | (BBCMR & ~BUCK)));

    // SET RELAY SIGNAL ACCORDING TO BUCK / BOOST
    PORTA = (BBCMR & BOOST ? (PORTA | _BV(0)) : (PORTA & ~_BV(0)));
    PORTA = (BBCMR & BOOST ? (PORTA | _BV(1)) : (PORTA & ~_BV(1)));

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
    
    //CV register update
    BBCMR = ((Vout >= VoutMax) ? (BBCMR | CV) : (BBCMR & ~CV));
    //CC register update
    BBCMR = ((Iout_mA >= IoutMax_mA) ? (BBCMR | CC) : (BBCMR & ~CC));


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
    Energy += Vout * Iout_mA mA * (delta_millis_internal ms / 3600);
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
