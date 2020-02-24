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
#define VOUT_LIMIT  30 V
#define IOUT_LIMIT  26 A


/* SERIAL REPORT BIT REGISTER */

#define SRBV_REPORT             (1 << 15) //  [ 15 ]  SERIAL REPORT ON / OFF STATE
#define SRBV_SRR_BINVAL         (1 << 14) //  [ 14 ]  SRR BIN VAL
#define SRBV_UPTIME             (1 << 13) //  [ 13 ]  MILLISECONDS UPTIME
#define SRBV_VOUT               (1 << 12) //  [ 12 ]  OP VOLTAGE
#define SRBV_IOUT               (1 << 11) //  [ 11 ]  OP CURRENT
#define SRBV_VSHUNT             (1 << 10) //  [ 10 ]  SHUNT mV
#define SRBV_PWR                (1 << 09) //  [ 09 ]  OP POWER
#define SRBV_E                  (1 << 08) //  [ 08 ]  OP ENERGY
#define SRBV_VIN                (1 << 07) //  [ 07 ]  INPUT VOLTAGE
#define SRBV_TARGET_PARAMETERS  (1 << 06) //  [ 06 ]  TARGET PARAMETERS (V-MAX, I-MAX)
#define SRBV_P_N_VBOOST         (1 << 05) //  [ 05 ]  P / N BOOST VOLTAGES
#define SRBV_                   (1 << 04) //  [ 04 ] 
#define SRBV_BBCMR_BINVAL       (1 << 03) //  [ 03 ]  OPERATING MODE (BBCMR)
#define SRBV_MOSFET_PWM         (1 << 02) //  [ 02 ]  MOSFET PWM VALUE
#define SRBV_THERMALS           (1 << 01) //  [ 01 ]  THERMALS
#define SRBV_EFFICIENCY         (1 << 00) //  [ 00 ]  EFFICIENCY


unsigned int SRR = SRBV_REPORT