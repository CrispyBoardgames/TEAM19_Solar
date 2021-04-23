using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

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
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}
