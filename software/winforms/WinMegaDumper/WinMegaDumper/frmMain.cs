using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Timers;

namespace WinCartDumper
{

    public partial class frmMain : Form
    {

        /*
         * The winform icon is the work of Hopstarter (Jojo Mendoza)
            URL: http://hopstarter.deviantart.com
            License: CC Attribution-Noncommercial-No Derivate 4.0
        */


        public static string[] ports;
        MegaDumper megaDumper;

        public frmMain()
        {
            InitializeComponent();


            megaDumper = new MegaDumper();
            megaDumper.ProgressChanged += MegaDumper_ProgressChanged;
            megaDumper.DoWork += MegaDumper_DoWork;
            megaDumper.RunWorkerCompleted += MegaDumper_RunWorkerCompleted;

            ports = new string[0];
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        public enum LogType
        {
            Info,
            Warning,
            Success,
            Error
        }


        private static Color colorError = Color.FromArgb(192, 0, 0);
        private static Color colorDefault = Color.FromArgb(0, 0, 0);
        private static Color colorSuccess = Color.FromArgb(0, 192, 0);
        private static Color colorWarning = Color.FromArgb(192, 192, 0);
        public void log(string message, LogType logtype)
        {
            Color c;
            switch (logtype)
            {
                case LogType.Warning:
                    c = colorWarning;
                    break;
                case LogType.Error:
                    c = colorError;
                    break;
                case LogType.Success:
                    c = colorSuccess;
                    break;
                default:
                    c = colorDefault;
                    break;
            }

            int currentIndex = rtfLog.TextLength;
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sb.Append(": ");
            sb.Append(message);
            sb.AppendLine();

            rtfLog.Select(rtfLog.TextLength, 0);
            rtfLog.AppendText(sb.ToString());
            rtfLog.Select(currentIndex, sb.Length);
            rtfLog.SelectionColor = c;
            rtfLog.Select(rtfLog.TextLength, 0);
            rtfLog.ScrollToCaret();
        }

        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            Thread autoDetect = new Thread(AutoDetect);
            autoDetect.Start();
            autoDetect.Join();

            //cmdPorts.Items.AddRange(ports);
        }

        public static void AutoDetectEnd()
        {

        }


        

        private void AutoDetect()
        {
            lock (ports)
            {
                ports = SerialPort.GetPortNames();

                foreach(string p in ports)
                {
                    
                    megaDumper.Operation = MegaDumperOperation.Version;
                    megaDumper.Port = p;
                    megaDumper.RunWorkerAsync();

                }

            }
        }


        public static void Read()
        {

        }



        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            log("This is an error", LogType.Error);
            log("This is a success", LogType.Success);

            return;
            megaDumper.Port = "COM5";

            rtfLog.Text += "INFO: Cart header dump start\r\n";

            RomHeader h = megaDumper.getRomHeader();

            rtfLog.Text += "SUCCESS: Retrieved 256 bytes\r\n";

            txtGameTitle.Text = h.DomesticGameTitle;
            txtCopyright.Text = h.Copyright;
            txtRomSize.Text =   ((h.RomAddressEnd - h.RomAddressStart + 1) / 1024 ).ToString() + " kbytes";
            txtRegion.Text = h.Region;
            txtSerialNumber.Text = h.SerialNumber;
            txtSave.Text = ((h.SaveChip.EndAddress - h.SaveChip.StartAddress + 1) / 1024).ToString() + " kbytes";

            
        }
        


        private void btnDump_Click(object sender, EventArgs e)
        {
            megaDumper.Port = "COM5";

            megaDumper.ProgressChanged += MegaDumper_ProgressChanged;
            megaDumper.DoWork += MegaDumper_DoWork;
            megaDumper.RunWorkerCompleted += MegaDumper_RunWorkerCompleted;

            megaDumper.RunWorkerAsync();

        }

        private void MegaDumper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 100;
            rtfLog.Text += (string)e.Result;
        }

        private void MegaDumper_DoWork(object sender, DoWorkEventArgs e)
        {
            var fromDt = DateTime.Now;
            byte[] res = megaDumper.GetDump((uint)0, (uint)500000);
            //RomHeader h = megaDumper.getRomHeader();

            var toDt = DateTime.Now;
            var tm = toDt.Subtract(fromDt);
            string s = "Ended dump in " + tm.TotalSeconds + "s\r\n";
            s += "Data rate: " + ((float)500000 * 2.0f / 1024.0f) / tm.TotalSeconds + " kb/s";

            e.Result = s;
        }

        private void MegaDumper_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }


}
