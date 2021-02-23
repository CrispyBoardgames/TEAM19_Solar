using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Data Type", typeof(string));
            dt.Rows.Add("Voltage Levels");
            dt.Rows.Add("Current Levels");
            dt.Rows.Add("Power Flow");
            DataRow dr = dt.NewRow();
            dr["Data Type"] = "Choose your data type";
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Data Type";
            comboBox1.ValueMember = "Data Type";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Voltages
        {
            //Voltage f = new Voltage();
            //f.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using Excel = Microsoft.Office.Interop.Excel;

           if (comboBox1.SelectedValue.ToString() == "Voltage Levels")
                {
                 Voltage f = new Voltage();
                f.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Current Levels")
            {
                Current f = new Current();
                f.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Power Flow")
            {
                Power f = new Power();
                f.Show();
            }
        }
    }
}
