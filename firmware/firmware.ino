#include <Adafruit_GFX.h>
#include <MCUFRIEND_kbv.h>
#include <TouchScreen.h>

#include <Fonts/Org_01.h>

#include "units.h"

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


/*  GLOBAL SYSTEM PARAMETERS  */
#define VOUT_MIN_LIMIT  2   V
#define VOUT_MAX_LIMIT  30  V
#define IOUT_MIN_LIMIT  100 mA
#define IOUT_MAX_LIMIT  26  A


/*------------------------  I / O  PINOUT  MAPPING  ------------------------*/

#define PIN_STATUS_LED      13

#define PIN_BOOST_GATE      10
#define PIN_BUCK_GATE       11

#define PIN_RELAY_N         22
#define PIN_RELAY_P         23

#define PIN_ACS712_SENSE    A4
#define PIN_PBOOST_SENSE    A5
#define PIN_NBOOST_SENSE    A6
#define PIN_VIN_SENSE       A7

#define PIN_LM35_REG_SENSE  A8
#define PIN_LM35_FET0_SENSE A9
#define PIN_LM35_FET1_SENSE A10




/*------------------------  SERIAL REPORT BIT REGISTER  ------------------------*/

#define SR_REPORT             (1 << 15) //  [ 15 ]  SERIAL REPORT ON / OFF STATE
#define SR_SRR_BINVAL         (1 << 14) //  [ 14 ]  SRR BIN VAL
#define SR_UPTIME             (1 << 13) //  [ 13 ]  MILLISECONDS UPTIME
#define SR_VOUT               (1 << 12) //  [ 12 ]  OP VOLTAGE
#define SR_IOUT               (1 << 11) //  [ 11 ]  OP CURRENT
#define SR_VSHUNT             (1 << 10) //  [ 10 ]  SHUNT mV
#define SR_PWR                (1 << 9)  //  [ 09 ]  OP POWER
#define SR_ENERGY             (1 << 8)  //  [ 08 ]  OP ENERGY
#define SR_VIN                (1 << 7)  //  [ 07 ]  INPUT VOLTAGE
#define SR_TARGET_PARAMETERS  (1 << 6)  //  [ 06 ]  TARGET PARAMETERS (V-MAX, I-MAX)
#define SR_P_N_VBOOST         (1 << 5)  //  [ 05 ]  P / N BOOST VOLTAGES
#define SR_                   (1 << 4)  //  [ 04 ] 
#define SR_BBCMR_BINVAL       (1 << 3)  //  [ 03 ]  OPERATING MODE (BBCMR)
#define SR_MOSFET_PWM         (1 << 2)  //  [ 02 ]  MOSFET PWM VALUE
#define SR_THERMALS           (1 << 1)  //  [ 01 ]  THERMALS
#define SR_EFFICIENCY         (1 << 0)  //  [ 00 ]  EFFICIENCY

unsigned int SRR = SR_REPORT | SR_UPTIME | SR_VOUT | SR_IOUT | SR_VSHUNT | SR_PWR | SR_ENERGY | SR_VIN | SR_TARGET_PARAMETERS | SR_P_N_VBOOST | SR_BBCMR_BINVAL | SR_MOSFET_PWM | SR_THERMALS | SR_EFFICIENCY;

/*----------------------  OPERATING MODE BIT REGISTER  ----------------------*/

#define BUCK    (1 << 0)
#define BOOST   (1 << 1)
#define CV      (1 << 2)
#define CC      (1 << 3)
#define UVLO    (1 << 4)
#define THLO    (1 << 5)

unsigned char BBCMR = 0;

unsigned int ACS712_ZeroError = 0;

float Vin = 0 V;
float UVLOT = 7 V;

float Vout_max = VOUT_MIN_LIMIT V;
float Iout_max = 500 mA;

float Vnb = 0 V;
float Vpb = 0 V;

float Vshunt = 0 V;
float Vout = 0 V;
float Iout = 0 A;

float Power = 0 W;
float Energy = 0 Wh;

short PWM_BUCK = 0;
short PWM_BOOST = 0;



void InitializeIO()
{
    Serial.println("[ .. ] Initializing IO...");
    
    // set timer register's prescalers of FET control pins to maximize performance
    TCCR2A = (TCCR2A & B11111000) | B00000001;    // PIN_BOOST_GATE (PIN 10)
    TCCR1A = (TCCR1A & B11111000) | B00000001;    // PIN_BUCK_GATE  (PIN 11)
    Serial.println("      [ 1 / 5 ] Updated Timer Register Prescalers.");

    // set pin modes of IO pins (other device's pins initialized and handled by libraries)
    DDRB |= ((1 << 4) | (1 << 5) | (1 << 7));  // pinMode(PIN_BOOST_GATE, OUTPUT); pinMode(PIN_BUCK_GATE, OUTPUT); pinMode(PIN_STATUS_LED, OUTPUT);
    PORTB = (PORTB & ~((1 << 4) | (1 << 5))) | (1 << 7);  // digitalWrite(PIN_BOOST_GATE, LOW); digitalWrite(PIN_BUCK_GATE, LOW); digitalWrite(PIN_STATUS_LED, HIGH);
    Serial.println("      [ 2 / 5 ] Initialized { BOOST , BUCK } N-MOSFET_GATE_DRIVE_PIN registers.");

    DDRA |= ((1 << 0) | (1 << 1));  // pinMode(PIN_RELAY_P, OUTPUT); pinMode(PIN_RELAY_N, OUTPUT);
    PORTA |= ((1 << 0) | (1 << 1));  // digitalWrite(PIN_RELAY_P, HIGH); digitalWrite(PIN_RELAY_N, HIGH);
    Serial.println("      [ 3 / 5 ] Initialized PIN_RELAY { P , N } registers.");
    
    DDRF &= ~((1 << 4) | (1 << 5) | (1 << 6) | (1 << 7));   pinMode(PIN_VIN_SENSE, INPUT); pinMode(PIN_ACS712_SENSE, INPUT); pinMode(PIN_NBOOST_SENSE, INPUT); pinMode(PIN_PBOOST_SENSE, INPUT); 
    Serial.println("      [ 4 / 5 ] Initialized PIN_SENSE registers.");
    
    DDRK &= ~((1 << 0) | (1 << 1) | (1 << 2));  // pinMode(PIN_LM35_REG_SENSE, INPUT); pinMode(PIN_LM35_FET0_SENSE, INPUT); pinMode(PIN_LM35_FET1_SENSE, INPUT);
    Serial.println("      [ 5 / 5 ] Initialized PIN_LM35_THERMAL_SENSE registers.");
    
    Serial.println("[ OK ] IO registers initialized and updated.");
}

void InitializeACS712()
{
    Serial.println("[ .. ] Initializing ACS712 Bidirectional Current Sensor (ELC30A)");

    for (int i = 0; i < 100; ++i)
        ACS712_ZeroError += analogRead(PIN_ACS712_SENSE);
    ACS712_ZeroError /= 100;

    Serial.print("       Sensor::ACS712::Zero_Error=");
    Serial.println(ACS712_ZeroError);

    Serial.println("[ OK ] ACS712 Sensor Initialized.");
}


#define colorFromRGB(red, green, blue) (int(red * 0.125) << 11) | (int(green * 0.25) << 5) | int(blue * 0.125)

bool numpadIsOnScreen = false;
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
    buttons_current.initButtonUL(&screen, 20, 120, 200, 70, colorFromRGB(100, 100, 100), colorFromRGB(20, 20, 20), colorFromRGB(100, 100, 100), "        A", 3);

    Serial.println("[ OK ] Display initialized.");
}


void InitializeSystem()
{
    Serial.begin(115200);

    Serial.println("\n AUXPIS POWER SUPPLY");
    Serial.println("Version 2020.02.25 [ Beta ] --development-mode");
    Serial.println("Licensed under MIT License. See LICENSE.md at https://github.com/rithviknishad/auxpis-bps/\n");

    InitializeIO();
    InitializeACS712();
    InitializeDisplay();

    /// add restriction code for low inupt voltage...
}



static int cursor_x, cursor_y;
// returns if screen is touched or not
bool touched()
{
    TSPoint point = touchscreen.getPoint();
    pinMode(YP, OUTPUT); pinMode(XM, OUTPUT);
    digitalWrite(YP, 1); digitalWrite(XM, 1);

    if (point.z > 40 && point.z < 1000)
    {
        cursor_x = map(point.y, TS_LEFT, TS_RT, 0, screen.width());
        cursor_y = map(point.x, TS_TOP, TS_BOT, 0, screen.height());
        return true;
    }
    return false;
}

void DrawNumpad()
{
    for (int i = 0; i < 4; ++i)
        for (int j = 0; j < 3; ++j)
            buttons_numpad[i][j].drawButton();

    numpadIsOnScreen = true;
}

void __drawParam_voltage(float value, char mode = 0)
{
    static char previous_strlen = 0;
    
    if (!mode || mode)
        screen.setTextColor(colorFromRGB(200, 200, 200), colorFromRGB(20, 20, 20));

    screen.setTextSize(4);
    screen.setCursor(40, 40);
    
    int str_count = screen.print(value);

    if (str_count < previous_strlen)
    {
        buttons_voltage.drawButton();
        screen.setTextSize(4);
        screen.setCursor(40, 40);
        screen.print(value);
    }
    previous_strlen = str_count;
}

void __drawParam_current(float value, char mode = 0)
{
    static char previous_strlen = 0;

    if (!mode || mode)
        screen.setTextColor(colorFromRGB(200, 200, 200), colorFromRGB(20, 20, 20));

    screen.setTextSize(4);
    screen.setCursor(40, 140);
    int str_count = screen.print(value);

    if (str_count < previous_strlen)
    {
        buttons_current.drawButton();
        screen.setTextSize(4);
        screen.setCursor(40, 140);
        screen.print(value);
    }
    previous_strlen = str_count;
}

void __drawParams()
{
    __drawParam_voltage(Vout);
    __drawParam_current(Iout);

    screen.setCursor(40, 200);
    screen.setTextSize(1);
    screen.print(BBCMR, BIN);

}

void DrawHomeScreen()
{
    buttons_voltage.drawButton();
    buttons_current.drawButton();

    __drawParams();

    DrawNumpad();
}

void setup()
{
    InitializeSystem();

    Serial.println("AUXPIS Power Supply is ready for use.");

    DrawHomeScreen();
    PORTB &= ~(1 << 7);
}


float set_Vout_max(float value)
{
    if (value > VOUT_MAX_LIMIT)
        return Vout_max = VOUT_MAX_LIMIT;
    else if (value < VOUT_MIN_LIMIT)
        return Vout_max = VOUT_MIN_LIMIT;
    else
        return Vout_max = value;
}

float getValueFromString(char * str)
{
    float value = 0;
    unsigned char decimalOffset = strlen(str);

    for (int i = 0; i < strlen(str); ++i)
    {
        if (str[i] > 47 && str[i] < 58)
        {
            value *= 10;
            value += str[i] - 48;
        }
        else if (str[i] == '.')
            decimalOffset = i + 1;
        else
            return -1;
    }
    return (value * pow(0.1, strlen(str) - decimalOffset));
}

float set_Iout_max(float value)
{
    if (value > IOUT_MAX_LIMIT)
        return Iout_max = IOUT_MAX_LIMIT;
    else if (value < IOUT_MIN_LIMIT)
        return Iout_max = IOUT_MIN_LIMIT;
    else
        return Iout_max = value;
}

char char_buff_20b[20];  // a global buffer space
int iterator_buff_20b = -1;
char* readStringFromStream(Stream &stream, char* buffer, int max_size = 20)
{
    int i = -1;
    while(i < max_size)
    {
        if (stream.available() > 0)
        {
            Serial.print(buffer[++i] = stream.read());
            if (buffer[i] == ';' || buffer[i] == '\n' || buffer[i] == '\r')
            {
                buffer[i] = '\0';
                return buffer;
            }
        }
    }
    return buffer = "";
}


void UpdateSerialReport()
{
    if (Serial.available() > 0)
    {
        static char readByte = 0;
        switch (readByte = Serial.read())
        {
        case 'V':
        case 'v':
            Serial.print("\nSet OP Voltage [V] : ");            
            Serial.print("\nVout_max set to : ");
            Serial.print(set_Vout_max(getValueFromString(readStringFromStream(Serial, char_buff_20b))));
            Serial.println(" V");
            break;
        

        case 'I':
        case 'i':
            Serial.print("\nSet Max Current [mA] : ");
            Serial.print("\nMax Current set to : ");
            Serial.print(set_Iout_max(getValueFromString(readStringFromStream(Serial, char_buff_20b))));
            Serial.println(" A");
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


    if (SRR & SR_REPORT)
    {
        if (SRR & SR_SRR_BINVAL)
        {
            Serial.print(SRR, BIN);
            Serial.print(" ");
        }

        if (SRR & SR_UPTIME)
        {
            Serial.print(millis());
            Serial.print("ms  ");
        }

        if (SRR & SR_VOUT)
        {
            Serial.print("V=");
            Serial.print(Vout);
            Serial.print(" V  ");
        }

        if (SRR & SR_IOUT)
        {
            Serial.print("I=");
            Serial.print(Iout);
            Serial.print(" A  ");
        }

        if (SRR & SR_VSHUNT)
        {
            Serial.print("Vshunt=");
            Serial.print(Vshunt);
            Serial.print(" mV  ");
        }

        if (SRR & SR_PWR)
        {
            Serial.print("P=");
            Serial.print(Power);
            Serial.print(" W  ");
        }

        if (SRR & SR_ENERGY)
        {
            Serial.print("E=");
            Serial.print(Energy);
            Serial.print(" Wh  ");
        }

        if (SRR & SR_VIN)
        {
            Serial.print("Vi=");
            Serial.print(Vin);
            Serial.print(" V  ");
        }

        if (SRR & SR_TARGET_PARAMETERS)
        {
            Serial.print("Vm=");
            Serial.print(Vout_max);
            Serial.print("V  Im=");
            Serial.print(Iout_max);
            Serial.print("A  ");
        }

        if (SRR & SR_P_N_VBOOST)
        {
            Serial.print("PB=");
            Serial.print(Vpb);
            Serial.print("V NB=");
            Serial.print(Vnb);
            Serial.print("V  ");
        }

        if (SRR & SR_BBCMR_BINVAL)
        {
            Serial.print("BBCMR=");
            Serial.print(BBCMR, BIN);
            Serial.print(" ");
        }
        
        if (SRR & SR_MOSFET_PWM)
        {
            Serial.print("~BUK=");
            Serial.print(PWM_BUCK, DEC);
            Serial.print(" ~BST=");
            Serial.print(PWM_BOOST, DEC);
            Serial.print(" ");
        }

        if (SRR & SR_THERMALS)
        {

        }

        if (SRR & SR_EFFICIENCY)
        {

        }

        Serial.println(";");
    }
}

void updateNumpad()
{
    static char itoa_buffspace[3];
    bool pressed = touched();

    for (int i = 0; i < 4; ++i)
    {
        for (j = 0; j < 3; ++j)
        {
            buttons_numpad[i][j].press(pressed && buttons_numpad[i][j].contains(cursor_x, cursor_y));

            buttons_numpad[i][j].drawButton(buttons_numpad[i][j].justPressed());

            if (buttons_numpad[i][j].justReleased())
            {
                int npVal = i * 3 + j + 1;

                if (npVal == 12) // >
                {
                    char_buff_20b[++iterator_buff_20b] = '\0';
                    /// add code to update the selected variable here
                    npVal = 10; // to reset the buffer space once done.
                }
                else if (iterator_buff_20b < 5 && npVal != 10) // maximum of five digits including decimal seperator
                {
                    if (iterator_buff_20b == 1) // automatically adds decimal seperator after two digits
                        char_buff_20b[++iterator_buff_20b] = '.';
                    char_buff_20b[++iterator_buff_20b] = itoa((npVal == 11 ? 0 : npVal), itoa_buffspace, 10);
                }

                if (npVal == 10) // X
                {
                    char_buff_20b = "";
                    iterator_buff_20b = -1;
                    /// add code to hide the numpad.
                }
            }
        }
    }
}

void updateButtons()
{
    static bool pressed = false;

    updateNumpad(pressed = touched());

    
}

void UpdateDisplay()
{ 
    updateButtons();
    __drawParams(); 
}


// stores the last update time for external activities
unsigned long external_last_millis = 0;
//unsigned long internal_last_millis = 0;

#define vin_mfact 0.032258064516
#define vnb_mfact 0.032258064516
#define vpb_mfact 0.069662815484

#define analogVoltage(x)            ((x) * 5 / 1023)
#define ACS712_SENSITIVITY          (66e-3)

float getCurrentFromACS712()
{
    Vshunt = analogVoltage(analogRead(PIN_ACS712_SENSE) - ACS712_ZeroError);
    return Vshunt / ACS712_SENSITIVITY;
}

void UpdateExternals()
{
    static unsigned short delta_millis_external = millis() - external_last_millis;

    Vin = analogRead(PIN_VIN_SENSE) * vin_mfact;
    Vpb = analogRead(PIN_PBOOST_SENSE) * vpb_mfact;
    Vnb = analogRead(PIN_NBOOST_SENSE) * vnb_mfact;
    
    Vout = Vpb - Vnb;
    
    Iout = getCurrentFromACS712();
    
    Power = Vout * Iout;
    Energy += (Power < 0 ? 0 : Vout * Iout * delta_millis_external / 3600);
    external_last_millis += delta_millis_external;

    UpdateSerialReport();
    UpdateDisplay();
    
    if (Vout_max < Vin)
    {
        BBCMR |= BUCK;
        BBCMR &= ~BOOST;
    }
    else
    {
        BBCMR |= BOOST;
        BBCMR &= ~BUCK;
    }

    BBCMR = ((Vin < UVLOT) ? ((BBCMR & ~(BOOST | BUCK)) | UVLO) : (BBCMR & ~UVLO)); // under voltage lockout protection

    if (BBCMR & BOOST)
        PORTA &= ~((1 << 0) | (1 << 1));
    else
        PORTA |= ((1 << 0) | (1 << 1));

    //PORTA = ((BBCMR & BUCK ) ? (PORTA & ~(1 << 0)) : (PORTA & ~(1 << 1)));  // SET RELAY SIGNAL ACCORDING TO BUCK / BOOST
    //PORTA = ((BBCMR & BOOST) ? (PORTA | (1 << 0)) : (PORTA | (1 << 1)));

    PORTB = (digitalRead(PIN_STATUS_LED) ? BBCMR & ~(1 << 7) : PORTB | (1 << 7));
}


#define BUCK_HIGHER     analogWrite(PIN_BUCK_GATE , (( PWM_BUCK >=  220) ? (PWM_BUCK=220 ) : (++PWM_BUCK ) ))
#define BUCK_LOWER      analogWrite(PIN_BUCK_GATE , (( PWM_BUCK >    0 ) ? ( --PWM_BUCK  ) : (PWM_BUCK=0 ) ))
#define BOOST_HIGHER    analogWrite(PIN_BOOST_GATE, (( PWM_BOOST >= 220) ? (PWM_BOOST=220) : (++PWM_BOOST) ))
#define BOOST_LOWER     analogWrite(PIN_BOOST_GATE, ((PWM_BOOST >    0 ) ? ( --PWM_BOOST ) : (PWM_BOOST=0) ))

void UpdateInternal()
{
    // get delta time from last update
    //static unsigned short delta_millis_internal = millis() - internal_last_millis;

    // read priority parameters ( V and I )
    Vout = (analogRead(PIN_PBOOST_SENSE) * vpb_mfact) - ((BBCMR & BUCK) ? analogRead(PIN_NBOOST_SENSE) * vnb_mfact : 0);
    Iout = getCurrentFromACS712();

    BBCMR = ((Vout >= Vout_max) ? (BBCMR | CV) : (BBCMR & ~CV));  //CV register update
    BBCMR = ((Iout >= Iout_max) ? (BBCMR | CC) : (BBCMR & ~CC));  //CC register update

    // update buck channel
    if ((BBCMR & BUCK))
        ((Iout > Iout_max || Vout > Vout_max) ? BUCK_LOWER : BUCK_HIGHER);
    else if (PWM_BUCK)
        analogWrite(PIN_BUCK_GATE, 0);  // single channel locking

    // update boost channel
    if ((BBCMR & BOOST))
        ((Iout > Iout_max || Vout > Vout_max) ? BOOST_LOWER : BOOST_HIGHER);
    else if (PWM_BOOST)
        analogWrite(PIN_BOOST_GATE, 0);  // single channel locking
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