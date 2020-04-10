/*
Copyright (c) 2020 Tony Pottier

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

@file MegaDumper.ino
@author Tony Pottier
@brief Firmware for a Sega Mega Drive cart dumper

@see https://idyl.io
@see https://github.com/tonyp7/MegaDumper


THIS CODE IS INTENDED TO BE COMPILED WITH THE MIGHTYCORE ARDUINO CORE

Micro-controller: ATMEGA324PB
Clock: External 18.432Mhz
Pinout: Standard

*/


#include <SPI.h>

/* IO used in the cart dumper */
#define PIN_CART_DETECT                           PB0
#define PIN_WRITE_ENABLE_LOW                      PD2
#define PIN_WRITE_ENABLE_HIGH                     PD3
#define PIN_CART_OUTPUT_ENABLE                    PB2
#define PIN_CART_CHIP_ENABLE                      PB3


/* SHIFT REGISTERS PIN */
#define PIN_SHIFT_REGISTERS_OE                    PB1
#define PIN_SHIFT_REGISTERS_RCK                   PB4
#define PIN_SHIFT_REGISTERS_SCK                   PB7
#define PIN_SHIFT_REGISTERS_DATA                  PB5


/* 18.432 Mhz: 1nop = 54 ns */
#define NOP __asm__ __volatile__ ("nop\n\t")


typedef union {
  uint8_t   bytes[4];
  uint32_t  word32;
} word32_t;

typedef union {
  uint8_t   bytes[2];
  uint16_t  word16;  
} word16_t;


/* global const */
const uint32_t ROM_HEADER_START = (uint32_t)0x80;
const uint32_t ROM_HEADER_END = (uint32_t)0x100;
const uint32_t ROM_MAX = (uint32_t)0x0FFFFF;

/* address and data bus */
word32_t address;
uint8_t command;
word16_t data;
word32_t sz;
const char* version = "MEGA DUMPER v1.0";


/* The 16 bit databus is made of two 8 bit bus on the ATEMEGA: Port A and Port C. This sets the whole port as inputs */
void set_data_bus_input(){
  DDRA = B00000000;
  DDRC = B00000000;
}

/* The 16 bit databus is made of two 8 bit bus on the ATEMEGA: Port A and Port C. This sets the whole port as outputs */
void set_data_bus_output(){
  DDRA = B11111111;
  DDRC = B11111111;
}

/* roughly a 200ns delay */
inline volatile void wait200ns(){
  NOP;
  NOP;
  NOP;
  NOP;
}



void setup() {

  /* init values */
  address.word32 = 0ULL;
  data.word16 = (uint16_t)0;
  command = 0x00;

  /* set data bus as input by default */
  set_data_bus_input();

  /* pin setup */
  pinMode(PIN_CART_DETECT, INPUT);
  pinMode(PIN_CART_OUTPUT_ENABLE, OUTPUT);
  pinMode(PIN_CART_CHIP_ENABLE, OUTPUT);

  /* shift register pins */
  pinMode(PIN_SHIFT_REGISTERS_OE, OUTPUT);
  pinMode(PIN_SHIFT_REGISTERS_RCK, OUTPUT);
  pinMode(PIN_SHIFT_REGISTERS_SCK, OUTPUT);
  pinMode(PIN_SHIFT_REGISTERS_DATA, OUTPUT);

  /* default values */
  digitalWrite(PIN_SHIFT_REGISTERS_OE, HIGH);
  digitalWrite(PIN_SHIFT_REGISTERS_RCK, HIGH);
  digitalWrite(PIN_SHIFT_REGISTERS_SCK, LOW);
  digitalWrite(PIN_SHIFT_REGISTERS_DATA, LOW);

  /* arduino SPI lib. We run at its max speed which is the CPU clock / 2 */
  SPI.begin();
  SPI.setClockDivider(SPI_CLOCK_DIV2);
  
  /* UART. Also running at its maximum stable speed with a 18.432Mhz clock */
  Serial.begin(460800);

}

void loop() {

  data.word16 = 0x0000;

  if (Serial.available() > 0) {
    command = Serial.read();

    switch(command){

      case 'v': /* challenge for auto detection */

        sz.word32 = (uint32_t)strlen(version);
        Serial.write(sz.bytes, 4); /* number of bytes to be sent */
        Serial.write(version);
        break;
        
      case 'i': /* cart info */
        sz.word32 = (uint32_t)256;
        data.word16 = (uint16_t)0;

        digitalWrite(PIN_SHIFT_REGISTERS_OE, LOW);

        Serial.write(sz.bytes, 4); /* number of bytes to be sent */
        
        for(address.word32 = ROM_HEADER_START; address.word32 < ROM_HEADER_END; address.word32++){
          digitalWrite(PIN_SHIFT_REGISTERS_RCK, LOW);
          SPI.transfer(address.bytes[2]);
          SPI.transfer(address.bytes[1]);
          SPI.transfer(address.bytes[0]);
          digitalWrite(PIN_SHIFT_REGISTERS_RCK, HIGH);

          /* 200 ns wait */
          wait200ns();

          /* read data */
          data.bytes[0] = PINA;
          data.bytes[1] = PINC;

          Serial.write(data.bytes[1]);
          Serial.write(data.bytes[0]);
        }
        digitalWrite(PIN_SHIFT_REGISTERS_OE, HIGH);
      
        break;
      case 'd': /* dump cart */
        word32_t to;
        uint8_t params[8];
        address.word32 = 0ULL;
        to.word32 = 0ULL;
        data.word16 = (uint16_t)0;
        
        /* read from address and to address */
        Serial.readBytes(params, 8);
        address.bytes[0] = params[0];
        address.bytes[1] = params[1];
        address.bytes[2] = params[2];
        address.bytes[3] = params[3];
        to.bytes[0] = params[4];
        to.bytes[1] = params[5];
        to.bytes[2] = params[6];
        to.bytes[3] = params[7];
        
        digitalWrite(PIN_SHIFT_REGISTERS_OE, LOW);

        sz.word32 = (to.word32 - address.word32) * 2; /* number of bytes sent is twice the to-from address because we send 16 bit for each address */
        Serial.write(sz.bytes, 4); /* number of bytes to be sent */
        
        for(; address.word32 <= to.word32; address.word32++){

          PORTB &= (uint8_t)B11101111; /* Set RCK low. Arduino's digitalWrite is unnecessarily slow for this operation. We need speed. */
          SPI.transfer(address.bytes[2]);
          SPI.transfer(address.bytes[1]);
          SPI.transfer(address.bytes[0]);
          PORTB |= (uint8_t)B00010000; /* Set RCK high. */

          /* wait ~100 ns for the ROM to show data */
          NOP;
          NOP;

          /* read data */
          data.bytes[0] = PINA;
          data.bytes[1] = PINC;

          /* push it over the UART */
          Serial.write(data.bytes[1]);
          Serial.write(data.bytes[0]);
        }
        digitalWrite(PIN_SHIFT_REGISTERS_OE, HIGH);
        break;
      case 'S': /* dump save game if any */
      default:
        break;
    }
    
  }

}
