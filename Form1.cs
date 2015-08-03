using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace DiskManager
{
    public partial class Form1 : Form
    {
        DiskManager diskManager;
        char diskLetter;
        const int columns = 55;
        const int rows = 37;
        byte[] buffer;
        bool hasRead;

        public Form1()
        {
            InitializeComponent();                                                                                                                                                                                                        
            diskManager = new DiskManager();
            diskLetter = this.letterTextBox.Text.ToCharArray()[0];
            hasRead = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            if (letterTextBox.Text.ToCharArray()[0]!=diskLetter || hasRead==false)
            {
                hasRead = true;
                diskLetter = letterTextBox.Text.ToCharArray()[0];
                buffer = diskManager.readDisk(diskLetter);
                dataGridView1.Enabled = true;
            }
            
            try
            {
                diskManager.createImage(pathTextBox.Text.ToString(), buffer);
            }
            catch(UnauthorizedAccessException ex)
            {
                FileInfo fileInfo = new FileInfo(pathTextBox.Text.ToString());
                string message = "Nie masz uprawnień aby dokonywać zapisów w folderze " + fileInfo.Directory;
                string caption = "Brak uprawnień";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            saveButton.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.draw();
        }

        private void showSector(object sender, EventArgs e)
        {
            int r = dataGridView1.SelectedCells[0].RowIndex + 1;
            int c = dataGridView1.SelectedCells[0].ColumnIndex + 1;
            int sectorNumber = (r - 1) * columns + c- 1;
            ShowSectorForm form = new ShowSectorForm(sectorNumber, buffer, pathTextBox.Text.ToString(), letterTextBox.Text.ToString(), diskManager);
            form.Show();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            hasRead = true;
            readButton.Enabled = false;
            buffer = diskManager.readDisk(letterTextBox.Text.ToCharArray()[0]);
            readButton.Enabled = true;
            dataGridView1.Enabled = true;
        }

    }
}
