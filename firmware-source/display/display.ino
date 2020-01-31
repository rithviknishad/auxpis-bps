#include <Adafruit_GFX.h>
#include <MCUFRIEND_kbv.h>
MCUFRIEND_kbv tft;
#include <TouchScreen.h>


#define TOUCH_MINPRESSURE 0
#define TOUCH_MAXPRESSURE 1000

// TFT Touchscreen calibration values
const int XP=8, XM=A2, YP=A3, YM=9; //320x480 ID=0x9486
const int TS_LEFT=919, TS_RT=98, TS_TOP=866, TS_BOT=190;

// PORTRAIT CALIBRATION     320 x 480
// x = map(p.x, LEFT=190, RT=866, 0, 320)
// y = map(p.y, TOP=919, BOT=98, 0, 480)
// Touch Pin Wiring XP=8 XM=A2 YP=A3 YM=9
// LANDSCAPE CALIBRATION    480 x 320
// x = map(p.y, LEFT=919, RT=98, 0, 480)
// y = map(p.x, TOP=866, BOT=190, 0, 320)

TouchScreen ts = TouchScreen(XP, YP, XM, YM, 300);

Adafruit_GFX_Button testButton;

int pixel_x, pixel_y;     //Touch_getXY() updates global vars
bool Touch_getXY(void)
{
    TSPoint p = ts.getPoint();
    pinMode(YP, OUTPUT);
    pinMode(XM, OUTPUT);
    digitalWrite(YP, HIGH);
    digitalWrite(XM, HIGH);
    Serial.println(p.z ? 1/p.z : 0);
    bool pressed = (p.z > TOUCH_MINPRESSURE && p.z < TOUCH_MAXPRESSURE);
    if (pressed) {
        pixel_x = map(p.y, TS_LEFT, TS_RT, 0, tft.width());
        pixel_y = map(p.x, TS_TOP, TS_BOT, 0, tft.height());
    }
    return pressed;
}

#define BLACK   0x0000
#define BLUE    0x001F
#define RED     0xF800
#define GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0
#define WHITE   0xFFFF

void setup(void)
{
    Serial.begin(9600);
    uint16_t ID = tft.readID();
    Serial.print("TFT ID = 0x");
    Serial.println(ID, HEX);
    
    if (ID == 0xD3D3) ID = 0x9486; // write-only shield

    tft.begin(ID);
    tft.setRotation(1);            //PORTRAIT
    tft.fillScreen(BLACK);
    testButton.initButton(&tft,  60, 200, 100, 40, BLACK, YELLOW, BLACK, "TEST", 2);
    testButton.drawButton(false);
    tft.fillRect(40, 80, 160, 80, RED);
}


void loop(void)
{
    bool down = Touch_getXY();
    testButton.press(down && testButton.contains(pixel_x, pixel_y));
    if (testButton.justReleased())
        testButton.drawButton();
    if (testButton.justPressed()) {
        testButton.drawButton(true);
        tft.fillRect(40, 80, 160, 80, GREEN);
    }
}
