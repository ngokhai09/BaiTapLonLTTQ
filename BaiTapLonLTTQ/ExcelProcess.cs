using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace BaiTapLonLTTQ
{
    class ExcelProcess
    {
        OpenFileDialog fdlg;
        SaveFileDialog sd;
        private void openSaveDialog()
        {
            sd = new SaveFileDialog();
            sd.Title = "Select file";
            sd.InitialDirectory = @"D:\Year_3\Lập trinh trực quan\Doc\Dữ liệu";
            sd.FileName = "";
            sd.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            sd.FilterIndex = 1;
            sd.RestoreDirectory = true;
        }
        private void openDialog()
        {
            fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"D:\Year_3\Lập trinh trực quan\Doc\Dữ liệu";
            fdlg.FileName = "";
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
        }
        public DataTable readExcel(string sql)
        {
            openDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string constr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" +
                    fdlg.FileName + ";User Id=admin;Password=;;Extended Properties =" + "\"Excel 12.0 Xml;HDR=YES;\"";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand(sql, con);
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            return null;            
        }
        public void writeExcel(DataGridView g, string className, string Name, List<string> a)
        {
            openSaveDialog();
            if (sd.ShowDialog() == DialogResult.OK)
            {
                
                App exApp = new App();
                Workbook exBook = exApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet exSheet = (Worksheet)exBook.Worksheets[1];
                string x = ((char)(65 + a.Count)).ToString();
                Range header = (Range)exSheet.Cells[2, 1];
                exSheet.get_Range("A2:" + x + "2").Merge(true);                
                exSheet.get_Range("A2:" + x + "2").HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                
                exSheet.get_Range("A6:" + x + (g.Rows.Count + 5).ToString()).Borders.Color = Color.Black;
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.White;
                header.Interior.Color = Color.DeepSkyBlue;
                header.Value = "DANH SÁCH " + Name;

                exSheet.get_Range("A6:" + (x + "6")).Font.Bold = true;
                exSheet.get_Range("A6:" + (x + "6")).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A6").Value = "STT";
                for (int i = 0; i < a.Count; i++)
                {
                    exSheet.get_Range(((char)(65 + i + 1)).ToString() + "6").Value = a[i];
                }

                for (int i = 0; i < g.Rows.Count - 1; i++)
                {
                    exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 11).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 7).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 7).ToString()).Value = className;
                    exSheet.get_Range("B" + (i + 7).ToString()).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    for (int j = 1; j < a.Count; j++)
                    {
                        x = ((char)(65 + j + 1)).ToString();
                        exSheet.get_Range(x + (i + 7).ToString()).Value = g.Rows[i].Cells[j - 1].Value;
                       
                    }
                }
                exSheet.Columns.AutoFit();

                exSheet.Name = "Sheet1";
                exBook.Activate();


                try
                {
                    exSheet.SaveAs(sd.FileName.ToString());
                }
                catch (Exception ex) { }



                exApp.Quit();

            }
        }
    }
}
