# GenDumper
An open-source Sega Genesis / Mega Drive cart dumper. This repository includes the sources for the hardware, the firmware running on the hardware, and computer programs used to interface with the dumper.

![Revision 1](https://github.com/tonyp7/GenDumper/raw/master/pictures/mega-dumper-sonic.jpg)

# Repository Structure

## firmware

Contains the source code that runs on the ATMEGA324PB micro-controller on the dumper's hardware.

## hardware

Contains the schematics, BOM, and anything else related to the hardware.

## software

Contains source code for programs to run on a PC to interact with the dumper. As of today there is only a c# winforms, but the communication with the hardware is simple enough that adding a variety of clients should be trivial.

### Note

GenDumper was originally named "MegaDumper". I later realized that there was a "universal mega dumper" project and the name were way too close and could lead to confusion -- prompting this rename to GenDumper.
