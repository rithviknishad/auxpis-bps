#define VERSION "Version 2020.5.3 [ Build 256 ] --release-build"

#include "units.h"

/*  GLOBAL SYSTEM PARAMETERS  */
#define VOUT_MIN_LIMIT  2   V
#define VOUT_MAX_LIMIT  30  V
#define IOUT_MIN_LIMIT  100 mA
#define IOUT_MAX_LIMIT  26  A


/*------------------------  I / O  PINOUT  MAPPING  ------------------------*/

#define PIN_STATUS_LED      13

#define PIN_BOOST_GATE      10
#define PIN_BUCK_GATE       11
#define PORT_BUCK           PORTB
#define BV_BUCK             3

#define PIN_RELAY_N         9
#define PIN_RELAY_P         9

#define PIN_ACS712_SENSE    A2
#define PIN_PBOOST_SENSE    A0
#define PIN_NBOOST_SENSE    A1
#define PIN_VIN_SENSE       A3   


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

unsigned int SRR = SR_REPORT | SR_UPTIME | SR_VOUT | SR_IOUT | SR_VIN | SR_TARGET_PARAMETERS | SR_P_N_VBOOST | SR_BBCMR_BINVAL | SR_MOSFET_PWM | SR_THERMALS | SR_EFFICIENCY;

/*----------------------  OPERATING MODE BIT REGISTER  ----------------------*/

#define BUCK    (1 << 0)
#define BOOST   (1 << 1)
#define CV      (1 << 2)
#define CC      (1 << 3)
#define UVLO    (1 << 4)
#define THLO    (1 << 5)

unsigned char BBCMR = 0;

long ACS712_ZeroError = 0;

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

char char_buff_20b[20];  // a handy global buffer space
int iterator_buff_20b = -1; // corresponding iterator for it :/


void InitializeIO()
{
    Serial.println("[ .. ] Initializing IO...");
    
    // set timer register's prescalers of FET control pins to maximize performance
    TCCR2A = TCCR2A & B11111000 | B00000001;    // PIN_BOOST_GATE (PIN 10)
    TCCR1B = TCCR1B & B11111000 | B00000001;    // PIN_BUCK_GATE  (PIN 11)
    Serial.println("      [ 1 / 5 ] Updated Timer Register Prescalers.");    

    // set pin modes of IO pins (other device's pins initialized and handled by libraries)
    pinMode(PIN_BOOST_GATE, OUTPUT); pinMode(PIN_BUCK_GATE, OUTPUT); pinMode(PIN_STATUS_LED, OUTPUT); // DDRB |= ((1 << 4) | (1 << 5) | (1 << 7));
    digitalWrite(PIN_BOOST_GATE, LOW); digitalWrite(PIN_BUCK_GATE, LOW); digitalWrite(PIN_STATUS_LED, HIGH); // PORTB = (PORTB & ~((1 << 4) | (1 << 5))) | (1 << 7);  
    Serial.println("      [ 2 / 5 ] Initialized { BOOST , BUCK } N-MOSFET_GATE_DRIVE_PIN registers.");

    pinMode(PIN_RELAY_P, OUTPUT); pinMode(PIN_RELAY_N, OUTPUT); // DDRA |= ((1 << 0) | (1 << 1));  
    digitalWrite(PIN_RELAY_P, HIGH); digitalWrite(PIN_RELAY_N, HIGH); // PORTA |= ((1 << 0) | (1 << 1));  
    Serial.println("      [ 3 / 5 ] Initialized PIN_RELAY { P , N } registers.");
    
    pinMode(PIN_VIN_SENSE, INPUT); pinMode(PIN_ACS712_SENSE, INPUT); pinMode(PIN_NBOOST_SENSE, INPUT); pinMode(PIN_PBOOST_SENSE, INPUT);  // DDRF &= ~((1 << 4) | (1 << 5) | (1 << 6) | (1 << 7));   
    Serial.println("      [ 4 / 5 ] Initialized PIN_SENSE registers.");
    
    // pinMode(PIN_LM35_REG_SENSE, INPUT); pinMode(PIN_LM35_FET0_SENSE, INPUT); pinMode(PIN_LM35_FET1_SENSE, INPUT); // DDRK &= ~((1 << 0) | (1 << 1) | (1 << 2)); 
    // Serial.println("      [ 5 / 5 ] Initialized PIN_LM35_THERMAL_SENSE registers.");
    
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

void InitializeSystem()
{
    Serial.begin(115200);

    Serial.println("\n AUXPIS POWER SUPPLY");
    Serial.println(VERSION);
    Serial.println("Licensed under MIT License. See LICENSE.md at https://github.com/rithviknishad/auxpis-bps/\n");

    InitializeIO();
    InitializeACS712();
    delay(1000);
    /// add restriction code for low inupt voltage...
}


void setup()
{
    InitializeSystem();

    Serial.println("AUXPIS Power Supply is ready for use.");

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

void (*SYS_RESET) (void) = 0;

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

        case 'R':
        case 'r':
            SYS_RESET();
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
            Serial.print((float)((Iout < 0.0) ? 0 : Iout));
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

// stores the last update time for external activities
unsigned long external_last_millis = 0;
//unsigned long internal_last_millis = 0;

#define vin_mfact (0.0284330659387831)
#define vnb_mfact (0.0284330659387831)
#define vpb_mfact (0.5682193890319093)

#define analogVoltage(x)            ((x) * 5.00f / 1023.00f)
#define ACS712_SENSITIVITY          (66e-3)

float getCurrentFromACS712()
{
    Vshunt = (float)(ACS712_ZeroError - analogRead(PIN_ACS712_SENSE)) * 5.00 / 1023.00;
    return Vshunt / ACS712_SENSITIVITY;
}

#define IsCC (Iout >= Iout_max)
#define IsCV (Vout >= Vout_max * 0.98)

void UpdateExternals()
{
    static unsigned short delta_millis_external = millis() - external_last_millis;
    
    Power = Vout * Iout;
    Energy += (Power < 0 ? 0 : Vout * Iout * delta_millis_external / 3600);
    external_last_millis += delta_millis_external;

    UpdateSerialReport();
    
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

    digitalWrite(PIN_RELAY_N, !(BBCMR & BOOST));
    //PORTA = ((BBCMR & BUCK ) ? (PORTA & ~(1 << 0)) : (PORTA & ~(1 << 1)));  // SET RELAY SIGNAL ACCORDING TO BUCK / BOOST
    //PORTA = ((BBCMR & BOOST) ? (PORTA | (1 << 0)) : (PORTA | (1 << 1)));
}


#define BUCK_HIGHER     (PORT_BUCK |=  (1 << BV_BUCK))  //analogWrite(PIN_BUCK_GATE , (( PWM_BUCK >=  220) ? (PWM_BUCK=220 ) : (++PWM_BUCK ) ))
#define BUCK_LOWER      (PORT_BUCK &= ~(1 << BV_BUCK)) //analogWrite(PIN_BUCK_GATE , (( PWM_BUCK >    0 ) ? ( --PWM_BUCK  ) : (PWM_BUCK=0 ) ))
#define BOOST_HIGHER    analogWrite(PIN_BOOST_GATE, (( PWM_BOOST >= 220) ? (PWM_BOOST=220) : (++PWM_BOOST) ))
#define BOOST_LOWER     analogWrite(PIN_BOOST_GATE, ((PWM_BOOST >    0 ) ? ( --PWM_BOOST ) : (PWM_BOOST=0) ))

void UpdateInternals()
{
    // get delta time from last update
    //static unsigned short delta_millis_internal = millis() - internal_last_millis;

    Vin = analogRead(PIN_VIN_SENSE) * vin_mfact;
    Vpb = analogRead(PIN_PBOOST_SENSE) * vpb_mfact;
    Vnb = analogRead(PIN_NBOOST_SENSE) * vnb_mfact;
    
    Vout = (BBCMR & BOOST) ? Vpb : (Vin - Vnb);
    
    Iout = getCurrentFromACS712();

    BBCMR = ((Vout >= Vout_max) ? (BBCMR | CV) : (BBCMR & ~CV));  //CV register update
    BBCMR = ((Iout >= Iout_max) ? (BBCMR | CC) : (BBCMR & ~CC));  //CC register update

    // update buck channel
    if ((BBCMR & BUCK))
        ((IsCC || IsCV) ? BUCK_LOWER : BUCK_HIGHER);
    else if (PWM_BUCK)
        analogWrite(PIN_BUCK_GATE, PWM_BUCK = 0);  // single channel locking

    // update boost channel
    if ((BBCMR & BOOST))
        ((IsCC || IsCV) ? BOOST_LOWER : BOOST_HIGHER);
    else if (PWM_BOOST)
        analogWrite(PIN_BOOST_GATE, PWM_BOOST = 0);  // single channel locking
}

void loop()
{
    UpdateInternals();

    if (millis() - external_last_millis > 200)
    {
        UpdateExternals();
        external_last_millis = millis();
    }
}