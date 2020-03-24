#ifndef __GPIO_H
#define __GPIO_H

#include <Arduino.h>

typedef struct _GPIO {
    volatile uint8_t *op_port = nullptr;
    volatile uint8_t *ip_port = nullptr;
    uint8_t pin = 0;
    uint8_t bit = 0;

    _GPIO(uint8_t physical_pin, bool pinmode, bool init_write = LOW) {        
        pin = physical_pin;
        bit = digitalPinToBitMask(pin);
        ip_port = portInputRegister(digitalPinToPort(pin));
        op_port = portOutputRegister(digitalPinToPort(pin));

        pinMode(pin, pinmode);

        if (pinmode == OUTPUT)
            write(init_write);
    }

    bool read() { *ip_port & bit; }

    void write_low()        { *op_port |=  bit;  }
    void write_high()       { *op_port &= ~bit; }
    void write(bool value)  { value ? write_high() : write_low(); }

} GPIO;

#endif