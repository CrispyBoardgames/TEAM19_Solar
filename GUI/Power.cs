using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace SD_GUI
{
    public partial class Power : Form
    {
        public Power()
        {
            InitializeComponent();

            //Buck values
            chart1.Series["Power"].Points.AddXY("11:20am", 120.3);
            chart1.Series["Power"].Points.AddXY("11:25am", 121.7);
            chart1.Series["Power"].Points.AddXY("11:30am", 120.1);
            chart1.Series["Power"].Points.AddXY("11:35am", 120.3);
            chart1.Series["Power"].Points.AddXY("11:40am", 143);
            chart1.Series["Power"].Points.AddXY("11:45am", 111.1);

            //Battery
            chart2.Series["Power"].Points.AddXY("11:20am", 121.61);
            chart2.Series["Power"].Points.AddXY("11:25am", 93.27);
            chart2.Series["Power"].Points.AddXY("11:30am", 105.12);
            chart2.Series["Power"].Points.AddXY("11:35am", 0);
            chart2.Series["Power"].Points.AddXY("11:40am", 0);
            chart2.Series["Power"].Points.AddXY("11:45am", 0);

            //PV
            chart3.Series["Power"].Points.AddXY("11:20am", 175);
            chart3.Series["Power"].Points.AddXY("11:25am", 175.67);
            chart3.Series["Power"].Points.AddXY("11:30am", 172.1);
            chart3.Series["Power"].Points.AddXY("11:35am", 176.3);
            chart3.Series["Power"].Points.AddXY("11:40am", 168.7);
            chart3.Series["Power"].Points.AddXY("11:45am", 172.4);

            //Load
            chart4.Series["Power"].Points.AddXY("11:20am", 145.8);
            chart4.Series["Power"].Points.AddXY("11:25am", 145.57);
            chart4.Series["Power"].Points.AddXY("11:30am", 152.11);
            chart4.Series["Power"].Points.AddXY("11:35am", 146.29);
            chart4.Series["Power"].Points.AddXY("11:40am", 163.04);
            chart4.Series["Power"].Points.AddXY("11:45am", 140.3);

            //Overall System
            //Buck Converter Output
            chart5.Series["Buck Converter Output"].Points.AddXY("11:20am", 120.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:25am", 121.7);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:30am", 120.1);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:35am", 120.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:40am", 143);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:45am", 111.1);
            //Baattery Output
            chart5.Series["Battery Output"].Points.AddXY("11:20am", 121.61);
            chart5.Series["Battery Output"].Points.AddXY("11:25am", 93.27);
            chart5.Series["Battery Output"].Points.AddXY("11:30am", 105.12);
            chart5.Series["Battery Output"].Points.AddXY("11:35am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:40am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:45am", 0);
            //PV Panel Output
            chart5.Series["PV Panel Output"].Points.AddXY("11:20am", 175);
            chart5.Series["PV Panel Output"].Points.AddXY("11:25am", 175.67);
            chart5.Series["PV Panel Output"].Points.AddXY("11:30am", 172.1);
            chart5.Series["PV Panel Output"].Points.AddXY("11:35am", 176.3);
            chart5.Series["PV Panel Output"].Points.AddXY("11:40am", 168.7);
            chart5.Series["PV Panel Output"].Points.AddXY("11:45am", 172.4);
            //Load Output
            chart5.Series["Load Output"].Points.AddXY("11:20am", 145.8);
            chart5.Series["Load Output"].Points.AddXY("11:25am", 145.57);
            chart5.Series["Load Output"].Points.AddXY("11:30am", 152.11);
            chart5.Series["Load Output"].Points.AddXY("11:35am", 146.29);
            chart5.Series["Load Output"].Points.AddXY("11:40am", 163.04);
            chart5.Series["Load Output"].Points.AddXY("11:45am", 140.3);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings f = new Settings();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //Voltage Form
        {
            Voltage v = new Voltage();
            v.Show();
        }

        private void button4_Click(object sender, EventArgs e) //Current Form
        {
            Current c = new Current();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Home
        {
            this.Hide();
            Form1 F = new Form1();
            F.Show();
        }

        private void button6_Click(object sender, EventArgs e) //Actual Settings button
        {
            Settings f = new Settings();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           // FileStream order = new FileStream("TextFile1.txt", FileMode.Create, FileAccess.Write);
        }

        private void button7_Click(object sender, EventArgs e) //export
        {
            string mySheet = @"C:\Dumpster\testcsv.csv";
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbooks powers = excelApp.Workbooks;
            Excel.Workbook sheet = powers.Open(mySheet);

        }
    }
}
