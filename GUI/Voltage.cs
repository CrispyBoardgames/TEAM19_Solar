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
    //class Chart1
    //{
    //    static void Main(string[] args)
    //    {
    //        Excel.Application xlApp;
    //        Excel.Workbook xlWorkbook;
    //        Excel.Worksheet xlWorkSheet;
    //        object misValue = System.Reflection.Missing.Value;

    //        xlApp = new Excel.Application();
    //        xlWorkbook = xlApp.Workbooks.Add(misValue);
    //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

    //        //Data columns
    //        xlWorkSheet.Cells[1, 1]= "Time";
    //        xlWorkSheet.Cells[1, 2] = "Voltage (V)";

    //        Excel.Application xlApp1 = new Excel.Application();
    //        Excel.Workbook xlWorkbook = xlApp1.Workbooks.Open(@"C:\Voltages.xlsx");
    //        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
    //        Excel.Range xlRange = xlWorksheet.UsedRange;

    //        int rowCount = xlRange.Rows.Count;
    //        int colCount = xlRange.Columns.Count;

    //        for (int i = 1; i <= rowCount; i++)
    //        {
    //            for (int j = 1; j <= colCount; j++)
    //            {
    //                Console.WriteLine(xlRange.Cells[i, j]
    //                   .Value2.ToString());
    //                xlWorkSheet.Cells[i, j] = xlRange.Cells[i, j]
    //                   .Value2.ToString();
    //            }
    //        }

    //        Console.ReadLine();

    //        Excel.Range chartRange;

    //        Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    //        Excel.ChartObject myChart =
    //           (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
    //        Excel.Chart chartPage = myChart.Chart;

    //        chartRange = xlWorkSheet.get_Range("A1", "R22");
    //        chartPage.SetSourceData(chartRange, misValue);
    //        chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

    //        // Export chart as picture file
    //        chartPage.Export(@"C:\Sample\EmployeeExportData.bmp", "BMP",
    //           misValue);
    //        xlWorkBook.SaveAs("EmployeeExportData.xls",
    //           Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
    //           misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive,
    //           misValue, misValue, misValue, misValue, misValue);
    //        xlWorkBook.Close(true, misValue, misValue);
    //        xlApp.Quit();
    //    }
    //}
    public partial class Voltage : Form
    {
        public Voltage()
        {
            InitializeComponent();

            //Buck values
            chart1.Series["Voltage"].Points.AddXY("11:20am", 12.3);
            chart1.Series["Voltage"].Points.AddXY("11:25am", 12.7);
            chart1.Series["Voltage"].Points.AddXY("11:30am", 12.1);
            chart1.Series["Voltage"].Points.AddXY("11:35am", 12.3);
            chart1.Series["Voltage"].Points.AddXY("11:40am", 14);
            chart1.Series["Voltage"].Points.AddXY("11:45am", 11.1);

            //Battery
            chart2.Series["Voltage"].Points.AddXY("11:20am", 12.61);
            chart2.Series["Voltage"].Points.AddXY("11:25am", 3.27);
            chart2.Series["Voltage"].Points.AddXY("11:30am", 5.12);
            chart2.Series["Voltage"].Points.AddXY("11:35am", 0);
            chart2.Series["Voltage"].Points.AddXY("11:40am", 0);
            chart2.Series["Voltage"].Points.AddXY("11:45am", 0);

            //PV
            chart3.Series["Voltage"].Points.AddXY("11:20am", 20.36);
            chart3.Series["Voltage"].Points.AddXY("11:25am", 20.67);
            chart3.Series["Voltage"].Points.AddXY("11:30am", 19.1);
            chart3.Series["Voltage"].Points.AddXY("11:35am", 20.3);
            chart3.Series["Voltage"].Points.AddXY("11:40am", 18.7);
            chart3.Series["Voltage"].Points.AddXY("11:45am", 19.4);

            //Load
            chart4.Series["Voltage"].Points.AddXY("11:20am", 14.8);
            chart4.Series["Voltage"].Points.AddXY("11:25am", 14.57);
            chart4.Series["Voltage"].Points.AddXY("11:30am", 15.11);
            chart4.Series["Voltage"].Points.AddXY("11:35am", 14.29);
            chart4.Series["Voltage"].Points.AddXY("11:40am", 16.04);
            chart4.Series["Voltage"].Points.AddXY("11:45am", 14.3);

            //Overall System
            //Buck Converter Output
            chart5.Series["Buck Converter Output"].Points.AddXY("11:20am", 12.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:25am", 12.7);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:30am", 12.1);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:35am", 12.3);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:40am", 14);
            chart5.Series["Buck Converter Output"].Points.AddXY("11:45am", 11.1);
            //Baattery Output
            chart5.Series["Battery Output"].Points.AddXY("11:20am", 12.61);
            chart5.Series["Battery Output"].Points.AddXY("11:25am", 3.27);
            chart5.Series["Battery Output"].Points.AddXY("11:30am", 5.12);
            chart5.Series["Battery Output"].Points.AddXY("11:35am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:40am", 0);
            chart5.Series["Battery Output"].Points.AddXY("11:45am", 0);
            //PV Panel Output
            chart5.Series["PV Panel Output"].Points.AddXY("11:20am", 20.36);
            chart5.Series["PV Panel Output"].Points.AddXY("11:25am", 20.67);
            chart5.Series["PV Panel Output"].Points.AddXY("11:30am", 19.1);
            chart5.Series["PV Panel Output"].Points.AddXY("11:35am", 20.3);
            chart5.Series["PV Panel Output"].Points.AddXY("11:40am", 18.7);
            chart5.Series["PV Panel Output"].Points.AddXY("11:45am", 19.4);
            //Load Output
            chart5.Series["Load Output"].Points.AddXY("11:20am", 14.8);
            chart5.Series["Load Output"].Points.AddXY("11:25am", 14.57);
            chart5.Series["Load Output"].Points.AddXY("11:30am", 15.11);
            chart5.Series["Load Output"].Points.AddXY("11:35am", 14.29);
            chart5.Series["Load Output"].Points.AddXY("11:40am", 16.04);
            chart5.Series["Load Output"].Points.AddXY("11:45am", 14.3);
        }

        private void BatteryPack1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Home button hides Battery Pack 1 form and goes to main form
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Power p = new Power();
            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Current c = new Current();
            c.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            string mySheet = @"C:\Dumpster\testcsv.csv";
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbooks powers = excelApp.Workbooks;
            Excel.Workbook sheet = powers.Open(mySheet);
        }
    }
}
