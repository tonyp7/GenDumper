# GenDumper Firmware
This contains the Arduino compatible firmware for the dumper.

# How to compile it?
GenDumper uses a ATMEGA324PB micro-controller, because it offers two full 8 bit ports that can be used to emulate the 16 bit port of the Mega Drive.

This micro-controller is not compatible by default with Arduino. You will need to download a core for it. This project uses the MighyCore.

Compile options should be:

* Micro-controller: ATMEGA324PB
* Clock: External 18.432Mhz
* Pinout: Standard

The MightyCore is available at: https://github.com/MCUdude/MightyCore
