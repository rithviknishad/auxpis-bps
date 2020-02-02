#include "Wire.h"


// IO Mappings
#define FET_V 
#define OPRELAY

int Vout = 0, Vmax = 0, Iout = 0, Imax = 0;

int maxDeltaV = 300; // allows Vout to deviate from Vmax by +/- specified value.


void setup()
{
    InitializeIO();
}

void loop()
{
    // cuts output relay, if vmax is 0.
    if (!Vmax && digitalRead(OPRELAY))
        digitalWrite(OPRELAY, HIGH);

    Vout < Vmax ? : digitalWrite(FET_V, HIGH) : digitalWrite(FET_V, LOW); // replace with bit register manipulation...
    
    // checks if voltage is within maximum acceptable error, and 
    if (Vout - Vmax > maxDeltaV || Vmax - Vout > maxDeltaV)
        digitalWrite(OPRELAY, LOW); // replace with bit register manipulation...
    else if (!digitalRead(OPRELAY))
        digitalWrite(OPRELAY, HIGH); // replace with bit register manipulation...


}