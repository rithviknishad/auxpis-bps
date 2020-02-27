/*

           db        ,ad8888ba,   ad88888ba     888888888888   88  ad888888b,
          d88b      d8"'    `"8b d8"     "8b            ,8P' ,d88 d8"     "88
         d8'`8b    d8'           Y8,                   d8" 888888         a8P
        d8'  `8b   88            `Y8aaaaa,           ,8P'      88      ,d8P" 
       d8YaaaaY8b  88              `"""""8b,        d8"        88    a8P"    
      d8""""""""8b Y8,                   `8b      ,8P'         88  a8P'      
     d8'        `8b Y8a.    .a8P Y8a     a8P     d8"           88 d8"        
    d8'          `8b `"Y8888Y"'   "Y88888P"     8P'            88 88888888888


    ACS712 SENSOR LIBRARY
    Author: RITHVIK NISHAD (https://github.com/rithviknishad)

     _    _  _____         _____ ______ 
    | |  | |/ ____|  /\   / ____|  ____|
    | |  | | (___   /  \ | |  __| |__   
    | |  | |\___ \ / /\ \| | |_ |  __|  
    | |__| |____) / ____ \ |__| | |____ 
     \____/|_____/_/    \_\_____|______|


    1)  #define PIN_ACS712_SENSE w/ the pin connected to the ACS712 OUT pin, before including this library.
        otherwise skip, to use A0 by default.

        example:
            #define PIN_ACS712_SENSE A7
            // library will read analog value from PIN A7 connected to you ACS712 OUT.

    2)  #define your ACS712 variant.
        Available variants:
            - ACS712_x05B
            - ACS712_x20A
            - ACS712_x30A

        example:
            #define ACS712_x30A
            // accordingly uses sensitivity and other params specific to the variant.


*/

#ifndef (__ACS712_H)
#define __ACS712_H

#ifndef ( PIN_ACS712_SENSE )
#define PIN_ACS712_SENSE  A0
#endif



#endif