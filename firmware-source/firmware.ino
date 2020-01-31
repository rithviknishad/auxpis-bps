/*

[ ] Electronics IO Ctrl
    - [ ] Read OpAmp
    - [ ] O/P MOSFET Drive
    - [ ] 

[ ] Screen Device Linkage
[ ] UI Pages

*/



// IO PINOUT

#define FET_V       // D~ OUT
#define FET_P       // D~ OUT
#define FET_N       // D~ OUT
#define OPAMP_V1    // A~ IN
#define OPAMP_V2    // A~ IN
#define LM35_SIG    // A~ IN
#define OPRELAY0    // D  OUT
#define OPRELAY1    // D  OUT
#define FAN         // D  OUT

#define PASSIVE 0
#define ACTIVE  1


// System Variables

float Vsrc = 0.0f, srcUVLO = 0.0f;  // Input Side Params
float Vmax = 0.0f, Imax = 0.0f;     // Control Params
float Vout = 0.0f, Iout = 0.0f;     // Output Side Params
bool OPReady = false;


// Thermal Variables
float temp = 0.0f;
bool fan_state = LOW, fan_mode = PASSIVE;
float trig0_temp = 0.0f; trig1_temp = 1.0f;

void SwitchFan(int state) {  }

void UpdateThermals()
{
    if (fan_mode && fan_state)
        return;
    else if (fan_mode && !fan_state)
        digitalWrite(FAN, fan_state = HIGH);
    else
        digitalWrite(FAN, fan_state = (temp < trig0_temp ? LOW : (temp > trig1_temp ? HIGH : fan_state) ));
}




void InitializeIO();


void ExecuteCommand(char param, float value)
{
    param = toupper(param);

    switch(param)
    {
        case 'V':   // Voltage

            break;

        case 'I':   // Current

            break;

        case 'T':   // O/P Type (DC, Square, Sine, SawTooth, Custom)

            break;

        case 'S':   // O/P Relay Switch state
            
            break;

        default:
            ThrowError("Unknown parameter."); // add custom parameter define option...
            break;
    }
}


void setup()
{
    InitializeIO();
    // InitializeWifi();
}

void loop()
{
    //UpdateCommands();
    UpdateThermals();
    //UpdateDisplay();
    
    for (int i = 0; i < 10; ++i)
    {
        digitalWrite(FET_V, (Vout = analogRead(OPAMP_V1) * k) < Vmax);   
    }
}



void InitializeIO()
{
    pinMode(FET_V, OUTPUT);
    pinMode(FET_P, OUTPUT);
    pinMode(FET_N, OUTPUT);
    pinMode(OPAMP_V1, INPUT);
    pinMode(OPAMP_V2, INPUT);
    pinMode(LM35_SIG, INPUT);
    pinMode(OPRELAY0, OUTPUT);
    pinMode(OPRELAY1, OUTPUT);
    pinMode(FAN, OUTPUT);
    
}