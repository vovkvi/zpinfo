using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZPInfo
{
    public partial class Position : Form
    {
        public string Category { get; set; }
        public double Value 
        {
            get 
			{ 
				double val;
				if(!double.TryParse(tb.Text.Trim().Replace(".",","), out val))
				{
					MessageBox.Show("Неверно заданое значение! Данные обнулены!",
						"Ошибка обработки данных.",
						MessageBoxButtons.OK, 
						MessageBoxIcon.Error);
				}
				return val; 
			} 
        }
        public int Type 
        {
            get { return rbProc.Checked == true ? 0 : 1; } 
        }

        public Position(string Category)
        {
            this.Category = Category;
            InitializeComponent();
            lbl.Text = cfg.CAT[Category];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            cfg.CATVALUE[Category] = Value;
            cfg.CATTYPE[Category] = Type;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cfg.CATVALUE[Category] = 0;
            cfg.CATTYPE[Category] = 0;
            Close();
        }
    }
}
