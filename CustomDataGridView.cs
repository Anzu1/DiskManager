using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    public class CustomDataGridView : DataGridView
    {
        const int columns = 55;
        const int rows = 37;

        public CustomDataGridView()
        {
            DoubleBuffered = true;
        }

        public void draw()
        {
            this.AutoGenerateColumns = false;

            for (int i = 0; i < columns; i++)
            {
                this.Columns.Add("col" + i, "column " + i);
                this.Columns[i].Width = 17;
            }
            for (int j = 0; j < rows; j++)
            {
                this.Rows.Add();
                this.Rows[j].Height = 17;
            }

            this.ClearSelection();
            this.CurrentCell = null;
        }
    }

