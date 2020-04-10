#ifndef __GPIO_H
#define __GPIO_H

#include <Arduino.h>

class GPIO {

public:

    volatile uint8_t *op_port;
    volatile uint8_t *ip_port;
    int pin;
    uint8_t bit;

    GPIO(int physical_pin, int pinmode, bool init_write = LOW) {        
        pin = physical_pin;
        bit = digitalPinToBitMask(pin);
        ip_port = portInputRegister(digitalPinToPort(pin));
        op_port = portOutputRegister(digitalPinToPort(pin));

        pinMode(pin, pinmode);

        if (pinmode == OUTPUT)
            write(init_write);
    }

    bool read() const { return *ip_port & bit; }
    operator bool() const { return read(); }

    void write_low()  const { *op_port |=  bit;  }
    void write_high() const { *op_port &= ~bit; }
    void write(const bool new_state) const { new_state ? write_high() : write_low(); }
    void operator = (const bool new_state) { write(new_state); }

};

#endif