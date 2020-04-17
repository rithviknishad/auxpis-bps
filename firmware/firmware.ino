#include <Wire.h>
#include <LiquidCrystal_SR.h>

#include "units.h"
#include "GPIO.h"

#define SERIAL_DEBUG // comment this line to disable SERIAL DEBUGGING (for release build)
#define LCD_DISPLAY // comment this line to disable LCD display (for performance mode, when external system handles display)

GPIO StatusLED  = GPIO( 13, OUTPUT, HIGH );

GPIO UVLO       = GPIO( 12, OUTPUT, HIGH );
GPIO BuckGate   = GPIO( 11, OUTPUT );
GPIO BoostGate  = GPIO( 10, OUTPUT );
GPIO Boost      = GPIO(  9, OUTPUT, HIGH );
#ifdef LCD_DISPLAY
    #define LCD_D        8
    #define LCD_CLK      7
    #define LCD_SCK      6
#endif
GPIO CV         = GPIO(  5, OUTPUT, HIGH  ); //
GPIO CC         = GPIO(  4, OUTPUT, HIGH  ); //
GPIO VPBSense   = GPIO( A0, INPUT );
GPIO VNBSense   = GPIO( A1, INPUT );
GPIO ISense     = GPIO( A2, INPUT );
GPIO VInSense   = GPIO( A3, INPUT );
GPIO VPOTSense  = GPIO( A4, INPUT );
GPIO IPOTSense  = GPIO( A5, INPUT );

LiquidCrystal_SR screen(LCD_D, LCD_CLK, LCD_SCK);

#define VIN_MAX     24 V
#define VPB_MAX     24 V
#define VNB_MAX     24 V
#define VPOT_MIN    3  V
#define VPOT_MAX    50 V
#define IPOT_MIN    100 mA
#define IPOT_MAX    30 A
#define ISENSE_MAX  75.74 A
#define UVLOT       7 V

void InitializeTimers() {
    TCCR2A = (TCCR2A & B11111000) | 1;
    TCCR1A = (TCCR1A & B11111000) | 1;
}

void setup() {
    InitializeTimers();
    
#ifdef LCD_DISPLAY
    screen.begin(16, 2);
    screen.home();
    screen.print("     AUXPIS");
    screen.setCursor(0, 1);
    screen.print("PWR SPLY   v 1.2");
#endif
#ifdef SERIAL_DEBUG
    Serial.begin(115200);
#endif
}

float VIn, MaxOPV, OPV, MaxOPI, OPI, OPPower, OPEnergy, VPB, VNB;
int GATE_PWM = 0;

#ifdef SERIAL_DEBUG
    #define LOG(x)   Serial.print(x); Serial.print(',');
    #define LOGEnd(x)   Serial.print(x); Serial.print('\n')
    #define LOGCSV(a, b, c, d, e, f, g, h, i, j, k, l) LOG(a) LOG(b) LOG(c) LOG(d) LOG(e) LOG(f) LOG(g) LOG(h) LOG(i) LOG(j) LOG(k) LOGEnd(l)
#endif

#ifdef LCD_DISPLAY
void UpdateInfotainment(LiquidCrystal_SR &lcd) {    
    lcd.setCursor(0, 0);
    int remch = lcd.print("OP V = ");
    remch += lcd.print(OPV);
    remch += lcd.print(" V");
    while(remch < 17)
        remch += lcd.print(" ");

    lcd.setCursor(0, 1);
    remch -= lcd.print("OP I = ");
    remch -= lcd.print(OPI);
    remch -= lcd.print(" A");
    while (remch > 0)
        remch -= lcd.print(" ");
}
#endif

void UpdateExternal(unsigned long deltaTime_millis) {
    MaxOPV = (analogRead(VPOTSense.pin) * (VPOT_MAX - VPOT_MIN) / 1023.00) + VPOT_MIN;
    MaxOPI = (analogRead(IPOTSense.pin) * (IPOT_MAX - IPOT_MIN) / 1023.00) + IPOT_MIN;
    
    UVLO = VIn < UVLOT;   
    Boost = MaxOPV > VIn;

    OPPower = OPV * OPI;
    OPEnergy += OPPower * deltaTime_millis ms;

#ifdef LCD_DISPLAY
    UpdateInfotainment(screen);
#endif
#ifdef SERIAL_DEBUG
    LOGCSV(VIn, millis(), MaxOPV, OPV, MaxOPI, OPI, OPPower, OPEnergy, VPB, VNB, GATE_PWM, " ");
#endif
}

void UpdateInternal() {
    VIn = analogRead( VInSense.pin ) * VIN_MAX / 1023.00;
    VPB = analogRead( VPBSense.pin ) * VPB_MAX / 1023.00;
    VNB = analogRead( VNBSense.pin ) * VNB_MAX / 1023.00;
    
    OPV = (Boost ? VPB : (VIn - VNB));
    OPI = (analogRead(ISense.pin) * ISENSE_MAX * 2 / 1023.00) - ISENSE_MAX;

    CV = !(OPV < MaxOPV);
    CC = !(OPI < MaxOPI);

    if (CV | CC)  --GATE_PWM;  else  ++GATE_PWM;

    analogWrite( BoostGate.pin, (( Boost && !UVLO) ? (GATE_PWM = min(220, GATE_PWM)) : 0) );
    analogWrite( BuckGate.pin,  ((!Boost && !UVLO) ? (GATE_PWM = min(255, GATE_PWM)) : 0) );
} 

void loop() {
#if defined(SERIAL_DEBUG) || defined(LCD_DISPLAY)
    static unsigned long external_last_millis = 0, delta_external_miilis = 0;

    UpdateExternal( millis() - external_last_millis );
    external_last_millis = millis();

    while( millis() - external_last_millis < 200 )
        UpdateInternal();
#else
    UpdateInternal();
#endif
}
