using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskManager
{
    public partial class ShowSectorForm : Form
    {
        string currentHexText;
        string currentAsciiText;
        List<int> signsToReplace = new List<int>();
        int sectorNumber;
        byte[] buffer;
        string path;
        string letter;
        public DiskManager diskManager;

        public ShowSectorForm(int sectorNumber, byte [] buffer, string path, string letter, DiskManager diskManager)
        {
            this.diskManager = diskManager;
            this.path = path;
            this.letter = letter;
            this.buffer = buffer;
            this.sectorNumber = sectorNumber;
            InitializeComponent();
            var s = sectorNumber + 1;
            this.Text = "Sektor " + s;

            tabPage1.Text = "HEX";
            tabPage2.Text = "ASCII";

            currentHexText = "";
            byte[] subArray = new byte[4096];

            for (int i = 4096 * sectorNumber, j = 0; i < 4096 * (sectorNumber + 1)-1; i++, j++)
            {
                subArray[j] = buffer[i];
                currentHexText += byteToHex(buffer[i]);
            }
            this.richTextBox1.Text = currentHexText;

            currentAsciiText = Encoding.UTF8.GetString(subArray);
            StringBuilder sb = new StringBuilder(currentAsciiText);
            for (int i = 0; i < currentAsciiText.Length; i++)
            {
                if (currentAsciiText.ElementAt(i) == '\0')
                {
                   sb[i] = '_';
                }
            }
            currentAsciiText = sb.ToString();
            this.richTextBox2.Text = currentAsciiText;
        }

        string byteToHex(byte b)
        {
            string hx = Convert.ToString(b, 16).ToUpper();
            if (hx.Length < 2) hx = "0" + hx;
            return hx;
        }

        private void saveOnComputer_Click(object sender, EventArgs e)
        {
            /*
            currentAsciiText = richTextBox2.Text.ToString();
            StringBuilder sb = new StringBuilder(currentAsciiText);
            for (int i = 0; i < currentAsciiText.Length; i++)
            {
                if (currentAsciiText.ElementAt(i) == '_')
                {
                    sb[i] = '\0';
                }
            }
            currentAsciiText = sb.ToString();

            byte[] bytes = new byte[currentAsciiText.Length * sizeof(char)];
            System.Buffer.BlockCopy(currentAsciiText.ToCharArray(), 0, bytes, 0, bytes.Length);

            for (int i = 4096 * sectorNumber, j = 0; i < 4096 * (sectorNumber + 1) - 1; i++, j++)
            {
                buffer[i] = bytes[j];
            }

            this.diskManager.createImage(path, buffer);*/

        }

        private void saveToDisk_Click(object sender, EventArgs e)
        {
             /*
            currentAsciiText = richTextBox2.Text.ToString();
            StringBuilder sb = new StringBuilder(richTextBox2.Text.ToString());
            for (int i = 0; i < currentAsciiText.Length; i++)
            {
                //if (currentAsciiText.ElementAt(i) == '_')
                //{
               //     sb[i] = '\0';
                //}
            }
            currentAsciiText = sb.ToString();

            byte[] bytes = new byte[currentAsciiText.Length * sizeof(char)];
            System.Buffer.BlockCopy(currentAsciiText.ToCharArray(), 0, bytes, 0, bytes.Length);

            for (int i = 4096 * sectorNumber, j = 0; i < 4096 * (sectorNumber + 1) - 1; i++, j++)
            {
                buffer[i] = bytes[j];
            }
            diskManager.writeToDisk(bytes, sectorNumber);*/
        }
    }
}
