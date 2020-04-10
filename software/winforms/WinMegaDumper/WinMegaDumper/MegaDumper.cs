using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinCartDumper
{
    public enum MegaDumperOperation : byte
    {
        None = (byte)'\0',
        Version = (byte)'v',
        Dump = (byte)'d',
        Header = (byte)'h'
    }



    class MegaDumper : BackgroundWorker
    {
        private SerialPort serialPort;
        private List<byte> bytesStream;
        private uint bytesToReceive;
        private string port;
        private MegaDumperOperation operation;

        private System.Object transmissionOverLock;
        private System.Object transmissionAliveLock;

        private static RomHeader romHeader;



        /// <summary>
        /// Because the Sega Mega Drive endianness does not match x86, we need to reverse bytes of any number conversion to get the actual value.
        /// Works for 16 bit and 32 bit unsigned integers.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The byteswipped value of the integer</returns>
        public static ushort SwapBytes(ushort x)
        {
            return (ushort)((ushort)((x & 0xff) << 8) | ((x >> 8) & 0xff));
        }

        /// <summary>
        /// Because the Sega Mega Drive endianness does not match x86, we need to reverse bytes of any number conversion to get the actual value.
        /// Works for 16 bit and 32 bit unsigned integers.
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The byteswipped value of the integer</returns>
        public static uint SwapBytes(uint x)
        {
            return ((x & 0x000000ff) << 24) +
                   ((x & 0x0000ff00) << 8) +
                   ((x & 0x00ff0000) >> 8) +
                   ((x & 0xff000000) >> 24);
        }


        public MegaDumper()
        {
            serialPort = new SerialPort();
            bytesStream = new List<byte>();
            port = "";
            bytesToReceive = 0;
            operation = MegaDumperOperation.None;

            this.WorkerReportsProgress = true;

            transmissionOverLock = new Object();
            transmissionAliveLock = new Object();

            romHeader = new RomHeader();

            serialPort.BaudRate = 460800;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public byte[] GetDump(uint from, uint to)
        {
            serialPort.PortName = port;
            bytesToReceive = 0;
            bytesStream.Clear();
            operation = MegaDumperOperation.Dump;

            /* build dump command */
            byte[] command = new byte[9];
            byte[] fb = BitConverter.GetBytes(from);
            byte[] tb = BitConverter.GetBytes(to);
            command[0] = (byte)'d';
            fb.CopyTo(command, 1); /* from address */
            tb.CopyTo(command, 5); /* to address */

            serialPort.Open();
            lock (transmissionOverLock)
            {
                serialPort.Write(command, 0, command.Length);
                if (!Monitor.Wait(transmissionOverLock))
                {
                    //timeout
                }
                else
                {
                    //business as normal
                }
            }
            serialPort.Close();

            return bytesStream.ToArray();

        }

        public RomHeader getRomHeader()
        {
            serialPort.PortName = port;
            bytesToReceive = 0;
            bytesStream.Clear();
            operation = MegaDumperOperation.Header;

            serialPort.Open();
            

            lock (transmissionOverLock)//waits N seconds for a condition variable
            {
                serialPort.Write("i");

                if (!Monitor.Wait(transmissionOverLock, 3000))
                {
                    //timeout
                }
                else
                {
                    //business as normal
                }
            }



            serialPort.Close();

            RomHeader header = new RomHeader();
            header.parse(bytesStream.ToArray());
            return header;


        }

       

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int intBuffer = serialPort.BytesToRead;
            byte[] byteBuffer = new byte[intBuffer];
            serialPort.Read(byteBuffer, 0, intBuffer);
            bytesStream.AddRange(byteBuffer);

            lock (transmissionAliveLock)
            {
                Monitor.Pulse(transmissionAliveLock);
            }



            if (bytesToReceive == 0)
            {
                //beginning of a new stream, the first 4 bytes contains a uint32 that contains the size of the stream
                if (bytesStream.Count >= 4)
                {
                    //convert the first 4 bytes to uint32
                    byte[] rawBytesToReceive = new byte[4];
                    rawBytesToReceive[0] = bytesStream[0];
                    rawBytesToReceive[1] = bytesStream[1];
                    rawBytesToReceive[2] = bytesStream[2];
                    rawBytesToReceive[3] = bytesStream[3];
                    bytesToReceive = BitConverter.ToUInt32(rawBytesToReceive, 0);

                    //remove the first four bytes from the stream
                    bytesStream.RemoveRange(0, 4);
                }

                this.ReportProgress(0);
            }
            else
            {
                int progress = (int) ( (float)bytesStream.Count / (float)bytesToReceive * 100.0f );
                this.ReportProgress((int)progress);

                
                //this.ReportProgress(50);
            }
            if (bytesStream.Count >= bytesToReceive)
            {


                lock (transmissionOverLock)
                {
                    Monitor.Pulse(transmissionOverLock);
                }
            }

            
        }
    }
}
