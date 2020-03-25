#include "units.h"
#include "GPIO.h"

#define VPOT_MIN        3       V
#define VPOT_MAX        20      V
#define IPOT_MIN        100     mA
#define IPOT_MAX        30      A
#define ISENSE_MAX      75.74   A
#define UVLOT           7       V

#define VINSENSEMAXVOLTAGE 24
#define VPBMAXSENSEVOLTAGE 24
#define VNBMAXSENSEVOLTAGE 24

GPIO StatusLED  = GPIO( 13, OUTPUT );
GPIO BoostGate  = GPIO( 10, OUTPUT );
GPIO BuckGate   = GPIO( 11, OUTPUT );
GPIO NRelay     = GPIO(  7, OUTPUT, HIGH );
GPIO PRelay     = GPIO(  8, OUTPUT, HIGH );
GPIO VPOTSense  = GPIO( A0, INPUT );
GPIO IPOTSense  = GPIO( A1, INPUT );
GPIO ISense     = GPIO( A2, INPUT );
GPIO VPBSense   = GPIO( A3, INPUT );
GPIO VNBSense   = GPIO( A4, INPUT );
GPIO VInSense   = GPIO( A5, INPUT );

/*----------------    STATE REGISTERS    ----------------*/
#define BOOST   (1 << 7)  //  [ 07 ]  --->  Boost Mask
#define CV      (1 << 6)  //  [ 06 ]  --->  CV Mask
#define CC      (1 << 5)  //  [ 05 ]  --->  CC Mask
#define UVLO    (1 << 4)  //  [ 04 ]  --->  UVLO Mask
uint8_t SR = 0;

void InitializeTimers() {
    TCCR2A = (TCCR2A & B11111000) | 1;
    TCCR1A = (TCCR1A & B11111000) | 1;
}

void setup() {
    InitializeTimers();
    Serial.begin(115200);
}

float VIn, MaxOPV, OPV, MaxOPI, OPI, OPPower, OPEnergy, VPB, VNB;
int GATE_PWM = 0;

void ReportSerial() {
    Serial.print(VIn);      Serial.print(',');  Serial.print(millis()); Serial.print(',');
    Serial.print(MaxOPV);   Serial.print(',');  Serial.print(OPV);      Serial.print(',');
    Serial.print(MaxOPI);   Serial.print(',');  Serial.print(OPI);      Serial.print(',');
    Serial.print(OPPower);  Serial.print(',');  Serial.print(OPEnergy); Serial.print(',');
    Serial.print(VPB);      Serial.print(',');  Serial.print(VNB);      Serial.print(',');
    Serial.print(GATE_PWM); Serial.print(',');  Serial.print(SR, BIN);  Serial.print(";\n");
}

void UpdateExternal(unsigned long deltaTime_millis) {
    MaxOPV = (analogRead(VPOTSense.pin) * (VPOT_MAX - VPOT_MIN) / 1023) + VPOT_MIN;
    MaxOPI = (analogRead(IPOTSense.pin) * (IPOT_MAX - IPOT_MIN) / 1023) + IPOT_MIN;
    if ( VIn < UVLOT )  SR |= UVLO;  else  SR &= ~UVLO;
    if ( MaxOPV > VIn )  SR |= BOOST;  else  SR &= ~BOOST;
    
    PRelay.write( MaxOPV > VIn );  NRelay.write( MaxOPV > VIn );

    OPPower = OPV * OPI;
    OPEnergy += OPPower * deltaTime_millis ms;
    ReportSerial();
}

void UpdateInternal() {
    VIn = analogRead(VInSense.pin) * VINSENSEMAXVOLTAGE / 1023;
    VPB = analogRead(VPBSense.pin) * VPBMAXSENSEVOLTAGE / 1023;
    VNB = analogRead(VNBSense.pin) * VNBMAXSENSEVOLTAGE / 1023;
    
    OPV = ((SR & BOOST) ? VPB : (VIn - VNB));
    OPI = (analogRead(ISense.pin) * ISENSE_MAX * 2 / 1023) - ISENSE_MAX;

    if (OPV < MaxOPV)  SR &= ~CV;  else  SR |= CV;
    if (OPI < MaxOPI)  SR &= ~CC;  else  SR |= CC;
    if (SR & (CV | CC))  --GATE_PWM;  else  ++GATE_PWM;

    analogWrite(BoostGate.pin, ((SR & BOOST) ? (GATE_PWM = min(220, GATE_PWM)) : 0));
    analogWrite(BuckGate.pin,  ((SR & BOOST) ? 0 : (GATE_PWM = min(255, GATE_PWM))));
}

void loop() {
    static unsigned long external_last_millis = 0, delta_external_miilis = 0;

    while(millis() - external_last_millis < 200)
        UpdateInternal();

    UpdateExternal(millis() - external_last_millis);
    external_last_millis = millis();
}