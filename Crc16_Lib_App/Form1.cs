using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SunCRC.CRCGeneric;
using SunCRC.CrcTest;
using SunCRC.CrcTest.Crc8Test;
using SunCRC.CrcTest.Crc16Test;
using SunCRC.CrcTest.Crc32Test;
using SunCRC.CrcTest.Crc64Test;
using SunCRC.CrcGeneric;
using SunCRC.CRCGeneric.BaseGeneric;
using SunCRC.Crc.Crc8;
using SunCRC.Crc.Crc16;
using SunCRC.Crc;
using System.Diagnostics;


namespace Crc16_Lib_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string newgtin = "00097111974689180143180313";
            tbGTIN.Text = newgtin;

        }

        private void button1_Click(object sender, EventArgs e)
        {
                ushort ResultCrc;
                string value = tbGTIN.Text;
                byte[] a = new byte[value.Length];
                char[] b = new char[value.Length];
                b = value.ToCharArray();
                byte [] GtinBytes = new byte[value.Length];


            System.Collections.IEnumerable collection = Enumerable.Range(100, 10);

            foreach (var ch in b.OfType<object>().Select((x, i) => new { x, i }))
            {
                int index = ch.i;
                try
                {
                        byte _GtinBytes = Convert.ToByte(ch.x);
                        GtinBytes[index] = _GtinBytes;

                }
                
                catch (OverflowException)
                {
                    Console.WriteLine("Unable to convert u+{0} to a byte.",
                                      Convert.ToInt16(ch).ToString("X4"));
                }

            }

                Crc16Model getVPCModel = new Crc16Model(0x8005, 0x0, 0x0, true, true);
                Crc16 getVPCDB = new Crc16(getVPCModel);
                ResultCrc = getVPCDB.Compute(GtinBytes);
            tbCrcResults.Text = ResultCrc.ToString();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/Adam-Shehadeh/Voice-Pick-Code-Calculator");
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://www.producetraceability.org/resources/voicecode");
        }

        private void gS1DocumentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://www.gs1.org/docs/barcodes/GS1_General_Specifications.pdf");
        }
    }
}
