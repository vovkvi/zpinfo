using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ZPInfo
{
    public partial class Form1 : Form
    {
        private readonly string[] NACHNAME = { "OKLAD", "PREM", "RAZ", "STAG", "DOST", "MAST", "CLASS", "EOTP", "DOTP", "NO4", "VIH", "SVERH", "SOVM" };
        private readonly string[] UDERNAME = { "NDFL", "STRAH", "PROF", "THIRD", "ZAD" };
        private Color ON = Color.Navy;
        private Color ON_UDER = Color.Navy;
        private Color OFF = Color.Silver;

        public int Days 
        {
            get { return Convert.ToInt32(cbDay.Text); }
        }

        public Form1()
        {
            InitializeComponent();
            Text += " v." + Application.ProductVersion;
            cbDay.SelectedIndex = 20;
            btnExit.Click += (o, e) => { Close(); };
        }

        private void Calculate() 
        {
            double allnach = 0;
            double alluder = 0;
            double val = 0;
            // OKLAD
            cfg.CATVALUE["OKLAD"] = string.IsNullOrEmpty(tbOKLAD.Text) ? 0 : Convert.ToDouble(tbOKLAD.Text);
            cfg.CATTYPE["OKLAD"] = 1;
            lblOKLADM.Text = cfg.CATVALUE["OKLAD"].ToString(); 
            lblOKLADY.Text = Math.Round((cfg.CATVALUE["OKLAD"] * 12), 1).ToString();
            lblOKLADD.Text = Math.Round((cfg.CATVALUE["OKLAD"] / Days), 1).ToString();

            foreach (CheckBox ch in tlpResult.Controls.OfType<CheckBox>()) 
            {
                if (ch.Checked) 
                {
                    string name = ch.Name.Replace("ch", string.Empty);
                    if(NACHNAME.Contains(name))
                    {
                        val = cfg.CATTYPE[name] == 0 ? (cfg.CATVALUE["OKLAD"] / 100) * cfg.CATVALUE[name] : cfg.CATVALUE[name];
                        ((Label)tlpResult.Controls["lbl" + name + "P"]).Text = Math.Round((val / cfg.CATVALUE["OKLAD"]) * 100, 2).ToString() + " %";
                    }
                    else if(UDERNAME.Contains(name))
                    {
                        foreach (string n in NACHNAME) 
                        {
                            allnach += cfg.CATTYPE[n] == 0 ? (cfg.CATVALUE["OKLAD"] / 100) * cfg.CATVALUE[n] : cfg.CATVALUE[n];
                        }
                        val = cfg.CATTYPE[name] == 0 ? (allnach / 100) * cfg.CATVALUE[name] : cfg.CATVALUE[name];
                        ((Label)tlpResult.Controls["lbl" + name + "P"]).Text = Math.Round((val / allnach) * 100, 2).ToString() + " %";
                    }
                    ((Label)tlpResult.Controls["lbl" + name + "M"]).Text = Math.Round(val, 2).ToString();
                    ((Label)tlpResult.Controls["lbl" + name + "Y"]).Text = Math.Round(val * 12, 1).ToString();
                    ((Label)tlpResult.Controls["lbl" + name + "D"]).Text = Math.Round(val / Days).ToString();
                }
            }
            // RESULT
            allnach = 0;
            alluder = 0;
            foreach (string n in NACHNAME)
            {
                allnach += cfg.CATTYPE[n] == 0 ? (cfg.CATVALUE["OKLAD"] / 100) * cfg.CATVALUE[n] : cfg.CATVALUE[n];
            }
            foreach (string n in UDERNAME)
            {
                alluder += cfg.CATTYPE[n] == 0 ? (allnach / 100) * cfg.CATVALUE[n] : cfg.CATVALUE[n]; ;
            }
            // ALLNACH
            lblALLNACHM.Text = Math.Round(allnach, 2).ToString();
            lblALLNACHY.Text = Math.Round(allnach * 12, 1).ToString();
            lblALLNACHD.Text = Math.Round(allnach / Days, 1).ToString();
            // ALLUDER
            lblALLUDERM.Text = Math.Round(alluder, 2).ToString();
            lblALLUDERY.Text = Math.Round(alluder * 12, 1).ToString();
            lblALLUDERD.Text = Math.Round(alluder / Days, 1).ToString();
            lblALLUDERP.Text = Math.Round((alluder / allnach) * 100, 2).ToString() + " %";
            // POLUCH
            val = allnach - alluder;
            lblPOLUCHM.Text = Math.Round(val, 2).ToString();
            lblPOLUCHY.Text = Math.Round(val * 12, 1).ToString();
            lblPOLUCHD.Text = Math.Round(val / Days, 1).ToString();
        }

        private void ch_CheckedChanged(object sender, EventArgs e)
        {
            Color clr = OFF;
            CheckBox ch = (CheckBox)sender;
            string cat = ch.Name.Replace("ch", string.Empty);
            if (ch.Checked)
            {
                if (new Position(cat).ShowDialog() != DialogResult.OK)
                {
                    ch.Checked = false;
                    return;
                }
                clr = NACHNAME.Contains(cat) ? ON : ON_UDER;
            }
            else 
            {
                cfg.CATVALUE[cat] = 0;
                cfg.CATTYPE[cat] = 0;
            }
            ((Label)tlpResult.Controls["lbl" + cat + "M"]).ForeColor = clr;
            ((Label)tlpResult.Controls["lbl" + cat + "Y"]).ForeColor = clr;
            ((Label)tlpResult.Controls["lbl" + cat + "D"]).ForeColor = clr;
            ((Label)tlpResult.Controls["lbl" + cat + "P"]).ForeColor = clr;
            Calculate();
        }

        private void tb_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            if (e.KeyChar == 44 || e.KeyChar == 46)
            {
                (sender as TextBox).Text = ((sender as TextBox).Text.Contains(',') | (sender as TextBox).Text.Contains('.')) ? (sender as TextBox).Text : (sender as TextBox).Text + ",";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
        }

        private void tbTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void tbOKLAD_TextChanged(object sender, EventArgs e)
        {
            cfg.CATVALUE["OKLAD"] = Convert.ToDouble(tbOKLAD.Text);
            Calculate();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() 
            {
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                Filter = "HyperText Markup Language (*.html) | *.html",
                AddExtension = true,
                Title = "Сохранить отчёт как..."
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string filename = sfd.FileName;
            List<string> lines = new List<string>();
            // start Document
            lines.Add("<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Зарплатный Корешок</title><style type=\"text/css\">body{width:21cm;height:29.7cm;margin:0 auto;margin-bottom:0.5cm;}.txtC{text-align: center; height: 25px;}.txtR{text-align: right;}.user_head{text-align: right;}</style></head><body><br>");
            // table User
            lines.Add("<table width=\"100%\">");
            lines.Add(string.Format("<tr><td class=\"user_head\" width=\"50%\">Ф.И.О : &nbsp</td><td>{0}</td></tr>",tbUser.Text));
            lines.Add(string.Format("<tr><td class=\"user_head\" width=\"50%\">Таб.номер : &nbsp</td><td>{0}</td></tr>", tbTab.Text));
            lines.Add(string.Format("<tr><td class=\"user_head\" width=\"50%\">Рабочих дней : &nbsp</td><td width=\"100px\">{0}</td></tr>", cbDay.Text));
            lines.Add(string.Format("<tr><td class=\"user_head\" width=\"50%\">Должностной оклад : &nbsp</td><td width=\"100px\">{0} руб.</td></tr>", tbOKLAD.Text));
            lines.Add("</table><br>");
            // table Result
            lines.Add("<table width=\"85%\" border=\"1\" cellspacing=\"0\" align=\"center\">");
            lines.Add("<tr class=\"txtC\" style=\"font-weight: bold;\"><td colspan=\"2\" height=\"50px\">Статьи начислений/удержаний</td><td width=\"110px\">Сумма за месяц</td><td width=\"110px\">%</td><td width=\"110px\">Сумма за год</td><td width=\"110px\">Сумма за день</td></tr>");
            lines.Add("<tr class=\"txtC\"><td colspan=\"6\">НАЧИСЛЕНИЯ</td></tr>");
            foreach (string s in NACHNAME) 
            {
                lines.Add("<tr class=\"txtC\">");
                lines.Add(string.Format("<td class=\"txtR\" colspan=\"2\">{0}  &nbsp</td>", cfg.CAT[s]));
                string sM = ((Label)tlpResult.Controls["lbl" + s + "M"]).Text;
                string sY = ((Label)tlpResult.Controls["lbl" + s + "Y"]).Text;
                string sD = ((Label)tlpResult.Controls["lbl" + s + "D"]).Text;
                string sP = "";
                try { sP = ((Label)tlpResult.Controls["lbl" + s + "P"]).Text; }
                catch { }
                lines.Add(string.Format("<td>{0}&nbsp</td>", sM == "0" || sM == "" ? string.Empty : sM));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sP == "0" || sP == "" ? string.Empty : sP));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sY == "0" || sY == "" ? string.Empty : sY));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sD == "0" || sD == "" ? string.Empty : sD));
                lines.Add("</tr>");
            }
            lines.Add("<tr class=\"txtC\"><td colspan=\"6\">УДЕРЖАНИЯ</td></tr>");
            foreach (string s in UDERNAME)
            {
                lines.Add("<tr class=\"txtC\">");
                lines.Add(string.Format("<td class=\"txtR\" colspan=\"2\">{0}  &nbsp</td>", cfg.CAT[s]));
                string sM = ((Label)tlpResult.Controls["lbl" + s + "M"]).Text;
                string sY = ((Label)tlpResult.Controls["lbl" + s + "Y"]).Text;
                string sD = ((Label)tlpResult.Controls["lbl" + s + "D"]).Text;
                string sP = "";
                try { sP = ((Label)tlpResult.Controls["lbl" + s + "P"]).Text; }
                catch { }
                lines.Add(string.Format("<td>{0}&nbsp</td>", sM == "0" || sM == "" ? string.Empty : sM));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sP == "0" || sP == "" ? string.Empty : sP));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sY == "0" || sY == "" ? string.Empty : sY));
                lines.Add(string.Format("<td>{0}&nbsp</td>", sD == "0" || sD == "" ? string.Empty : sD));
                lines.Add("</tr>");
            }
            lines.Add("<tr class=\"txtC\"><td colspan=\"6\">ИТОГ</td></tr>");
            lines.Add("<tr class=\"txtC\" style=\"color: rgb(0,128,0); font-weight: bold;\"><td class=\"txtR\" colspan=\"2\">Всего начислено  &nbsp</td>");
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLNACHM.Text));
            lines.Add("<td>&nbsp</td>");
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLNACHY.Text));
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLNACHD.Text));
            lines.Add("</tr>");
            lines.Add("<tr class=\"txtC\" style=\"color: rgb(255,0,0); font-weight: bold;\"><td class=\"txtR\" colspan=\"2\">Всего удержано  &nbsp</td>");
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLUDERM.Text));
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLUDERP.Text));
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLUDERY.Text));
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblALLUDERD.Text));
            lines.Add("</tr>");
            lines.Add("<tr class=\"txtC\" style=\"color: rgb(0,0,128); font-weight: bold;\"><td class=\"txtR\" colspan=\"2\">Итого к получению  &nbsp</td>");
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblPOLUCHM.Text));
            lines.Add("<td>&nbsp</td>");
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblPOLUCHY.Text));
            lines.Add(string.Format("<td>{0}&nbsp</td>", lblPOLUCHD.Text));
            lines.Add("</tr>");
            lines.Add("</table><br>");
            // end Document
            lines.Add("<br><h4 style=\"text-align: center;\">Report generated using ZPInfo program by Vitalii Vovk, 2020.</h4></body></html>");
            // save Document
            File.WriteAllLines(filename, lines);
            DialogResult dr = MessageBox.Show("Отчёт сформирован успешно! Открыть файл отчёта?", "Отчёт сформирован!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;
            Process.Start(filename);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog();
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            new License().ShowDialog();
        }
    }
}
