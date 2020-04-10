using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCartDumper
{
    class Cart
    {
        RomHeader header;
        byte[] raw;
        
    }


    enum ExtraMemoryType : byte
    {
        /* The RAM type is used to indicate whether the data is saved when turning off the console and what kind of accesses (byte or word) are allowed:
            List of SRAM types Type Saves?	Usage
                $A0 No	16-bit
                $B0 No	8-bit (even addresses)
                $B8 No	8-bit (odd addresses)
                $E0 Yes	16-bit
                $F0 Yes	8-bit (even addresses)
                $F8 Yes	8-bit (odd addresses) 
        */
        Unknown = 0,
        NoSave16bit = 0xA0,
        NoSave8bitEven = 0xB0,
        NoSave8bitOdd = 0xB8,
        Save16bit = 0xE0,
        Save8bitEven = 0xF0,
        Save8bitOdd = 0xF8
    }

    class ExtraMemory
    {
        /* $1B0
            2 bytes	Always "RA"
            1 byte	RAM type
            1 byte	Always $20
            4 bytes	Start address
            4 bytes	End address
        */

        private ExtraMemoryType extraMemoryType;
        private uint startAddress;
        private uint endAddress;


        public uint StartAddress { get { return startAddress; } }
        public uint EndAddress { get { return endAddress; } }

        /// <summary>
        /// Parse the extra memory (save game) format based on a raw sega genesis cart header
        /// </summary>
        /// <param name="raw">The raw byte header (e.g. date coming from address 0x50 on the ROM / 0x100 on an 8 bit addressable system</param>
        public void parse(byte[] raw)
        {
            extraMemoryType = (ExtraMemoryType)raw[0xB0 + 2];
            startAddress = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xB0 + 4));
            endAddress = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xB0 + 8));
        }

    }

    class RomHeader
    {
        /*
            $100	16 bytes	System type
            $110	16 bytes	Copyright and release date
            $120	48 bytes	Game title (domestic)
            $150	48 bytes	Game title (overseas)
            $180	14 bytes	Serial number
            $18E	2 bytes	ROM checksum
            $190	16 bytes	Device support
            $1A0	8 bytes	ROM address range
            $1A8	8 bytes	RAM address range
            $1B0	12 bytes	Extra memory
            $1BC	12 bytes	Modem support
            $1C8	40 bytes	(reserved, fill with spaces)
            $1F0	3 bytes	Region support
            $1F3	13 bytes	(reserved, fill with spaces) 
        */

        private string systemType;
        private string copyright;
        private string domesticGameTitle;
        private string overseasGameTitle;
        private string serialNumber;
        private ushort checksum;
        private string deviceSupport;
        private uint romAddressStart;
        private uint romAddressEnd;
        private uint ramAddressStart;
        private uint ramAddressEnd;
        private ExtraMemory extraMemory;
        private string modemSupport;
        private string regionSupport;
        private byte[] raw;


        public string DomesticGameTitle { get { return domesticGameTitle; } }
        public string Copyright { get { return copyright; } }
        public uint RomAddressStart { get { return romAddressStart; } }
        public uint RomAddressEnd { get { return romAddressEnd; } }
        public string Region { get { return regionSupport; } }
        public string SerialNumber { get { return serialNumber; } }
        public ExtraMemory SaveChip { get { return extraMemory; } }


        public void parse(byte[] raw)
        {
            this.raw = (byte[])raw.Clone();

            systemType = Encoding.ASCII.GetString(raw, 0, 16).TrimEnd();
            copyright = Encoding.ASCII.GetString(raw, 0x10, 16).TrimEnd();
            domesticGameTitle = Encoding.ASCII.GetString(raw, 0x20, 48).TrimEnd();
            overseasGameTitle = Encoding.ASCII.GetString(raw, 0x50, 48).TrimEnd();
            serialNumber = Encoding.ASCII.GetString(raw, 0x80, 14).TrimEnd();
            checksum = MegaDumper.SwapBytes(BitConverter.ToUInt16(raw, 0x8E));
            deviceSupport = Encoding.ASCII.GetString(raw, 0x90, 16).TrimEnd();
            romAddressStart = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xA0));
            romAddressEnd = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xA0 + 4));
            ramAddressStart = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xA8));
            ramAddressEnd = MegaDumper.SwapBytes(BitConverter.ToUInt32(raw, 0xA8 + 4));
            modemSupport = Encoding.ASCII.GetString(raw, 0xBC, 12).TrimEnd();
            regionSupport = Encoding.ASCII.GetString(raw, 0xF0, 3).TrimEnd();

            extraMemory = new ExtraMemory();
            extraMemory.parse(raw);

            return;
        }

        public RomHeader()
        {

        }


    }
}
