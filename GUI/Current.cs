using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SD_GUI
{
    public partial class Current : Form
    {
       
        public Current()
        {
            InitializeComponent();

            //Buck values
            chart1.Series["Current"].Points.AddXY("11:20am", 3.3);
            chart1.Series["Current"].Points.AddXY("11:25am", 3.7);
            chart1.Series["Current"].Points.AddXY("11:30am", 3.1);
            chart1.Series["Current"].Points.AddXY("11:35am", 3.3);
            chart1.Series["Current"].Points.AddXY("11:40am", 5);
            chart1.Series["Current"].Points.AddXY("11:45am", 4.1);

            //Battery
            chart2.Series["Current"].Points.AddXY("11:20am", 4.61);
            chart2.Series["Current"].Points.AddXY("11:25am", 3.27);
            chart2.Series["Current"].Points.AddXY("11:30am", 1.12);
            chart2.Series["Current"].Points.AddXY("11:35am", 0);
            chart2.Series["Current"].Points.AddXY("11:40am", 0);
            chart2.Series["Current"].Points.AddXY("11:45am", 0);

            //PV
            chart3.Series["Current"].Points.AddXY("11:20am", 7.42);
            chart3.Series["Current"].Points.AddXY("11:25am", 7.17);
            chart3.Series["Current"].Points.AddXY("11:30am", 6.08);
            chart3.Series["Current"].Points.AddXY("11:35am", 7.63);
            chart3.Series["Current"].Points.AddXY("11:40am", 4.7);
            chart3.Series["Current"].Points.AddXY("11:45am", 5.4);

            //Load
            chart4.Series["Current"].Points.AddXY("11:20am", 6.8);
            chart4.Series["Current"].Points.AddXY("11:25am", 6.57);
            chart4.Series["Current"].Points.AddXY("11:30am", 7.11);
            chart4.Series["Current"].Points.AddXY("11:35am", 6.29);
            chart4.Series["Current"].Points.AddXY("11:40am", 7.04);
            chart4.Series["Current"].Points.AddXY("11:45am", 6.3);

            //Overall System
            //Buck Converter Output
            chart5.Series["Buck Converter Output"].Points.AddXY("11:20am", 3.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:25am", 3.7);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:30am", 3.1);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:35am", 3.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:40am", 5);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:45am", 4.1);
            //Baattery Output
            chart5.Series["Battery Output"].Points.AddXY("11:20am", 4.61);
            chart5.Series["Battery Output"].Points.AddXY("11:25am", 3.27);
            chart5.Series["Battery Output"].Points.AddXY("11:30am", 1.12);
            chart5.Series["Battery Output"].Points.AddXY("11:35am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:40am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:45am", 0);
            //PV Panel Output
            chart5.Series["PV Panel Output"].Points.AddXY("11:20am", 7.42);
            chart5.Series["PV Panel Output"].Points.AddXY("11:25am", 7.17);
            chart5.Series["PV Panel Output"].Points.AddXY("11:30am", 6.08);
            chart5.Series["PV Panel Output"].Points.AddXY("11:35am", 7.63);
            chart5.Series["PV Panel Output"].Points.AddXY("11:40am", 4.7);
            chart5.Series["PV Panel Output"].Points.AddXY("11:45am", 5.4);
            //Load Output
            chart5.Series["Load Output"].Points.AddXY("11:20am", 6.8);
            chart5.Series["Load Output"].Points.AddXY("11:25am", 6.57);
            chart5.Series["Load Output"].Points.AddXY("11:30am", 7.11);
            chart5.Series["Load Output"].Points.AddXY("11:35am", 6.29);
            chart5.Series["Load Output"].Points.AddXY("11:40am", 7.04);
            chart5.Series["Load Output"].Points.AddXY("11:45am", 6.3);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Turn On System
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //Refresh/ get charts
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            //export chart as picture file
            chartPage.Export(@"C:\Dumpster\testcsv.bmp", "BMP", misValue);

          //  pictureBox1.Image = new Bitmap(@"C:\Dumpster\testcsv.bmp");

            xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\csharp-Excel.xls");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Voltage v = new Voltage();
            v.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Power p = new Power();
            p.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            string mySheet = @"C:\Dumpster\testcsv.csv";
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbooks powers = excelApp.Workbooks;
            Excel.Workbook sheet = powers.Open(mySheet);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
