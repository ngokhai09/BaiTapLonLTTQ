using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
        public void writeExcel(DataGridView g)
        {
            openSaveDialog();
            if(sd.ShowDialog() == DialogResult.OK)
            {
                App obj = new App();
                if (obj == null)
                {
                    MessageBox.Show("Khong the su dung thu vien Excel");
                    return;
                }
                Workbook wb = obj.Application.Workbooks.Add(Type.Missing);
                obj.Columns.ColumnWidth = 25;
                for (int i = 1; i <= g.Columns.Count; i++)
                {
                    obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
                    obj.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter; // căn chữ giữa
                }
                for (int i = 0; i < g.Rows.Count; i++)
                {
                    for (int j = 0; j < g.Columns.Count; j++)
                    {
                        if (g.Rows[i].Cells[j].Value != null)
                        {
                            obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                ////Lưu file excel xuống Ổ cứng
                obj.ActiveWorkbook.SaveCopyAs(sd.FileName);
                obj.ActiveWorkbook.Saved = true;

                //đóng file để hoàn tất quá trình lưu trữ
                //wb.Close(true, Type.Missing, Type.Missing);

                //thoát và thu hồi bộ nhớ cho COM
                obj.Quit();
                //releaseObject(wb);
                releaseObject(obj);

                //Mở File excel sau khi Xuất thành công
                System.Diagnostics.Process.Start(sd.FileName);
            }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
        /*private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonBanHang.Rows.Count > 0)
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                Excel.Range header = (Excel.Range)exSheet.Cells[2, 1];
                exSheet.get_Range("A2:D2").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH HÀNG HÓA";

                Range TenKH = exSheet.Cells[3, 1];
                exSheet.get_Range("A3:C3").Merge(true);
                TenKH.Font.Size = 14;
                TenKH.Font.Bold = true;
                TenKH.Value = "Tên khách hàng: " + txtTenKhachHang.Text + txtSoDienThoai.Text;

                Range TenNV = exSheet.Cells[4, 1];
                exSheet.get_Range("A4:C4").Merge(true);
                TenNV.Font.Size = 14;
                TenNV.Font.Bold = true;
                TenNV.Value = "Tên nhân viên: " + txtTenNhanVien.Text;

                Range TenNVi = exSheet.Cells[4, 1];
                exSheet.get_Range("A4:C4").Merge(true);
                TenNVi.Font.Size = 14;
                TenNVi.Font.Bold = true;
                TenNVi.Value = "Tên nhân viên: " + txtTenNhanVien.Text;

                Range Ngay = exSheet.Cells[5, 1];
                exSheet.get_Range("A5:C5").Merge(true);
                Ngay.Font.Size = 14;
                Ngay.Font.Bold = true;
                Ngay.Value = "Ngày: " + dtpNgayBan.Text;

                Range TongTien = exSheet.Cells[dgvHoaDonBanHang.Rows.Count + 8, 1];
                TongTien.Font.Size = 14;
                TongTien.Font.Bold = true;
                TongTien.Value = "Tổng Tiền: " + txtTongTien.Text;


                exSheet.get_Range("A7:G7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã hàng";
                exSheet.get_Range("C7").Value = "Tên hàng";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Đơn giá bán";
                exSheet.get_Range("D7").ColumnWidth = 20;
                exSheet.get_Range("E7").Value = "Số lượng";
                exSheet.get_Range("F7").Value = "Giảm giá ";
                exSheet.get_Range("G7").Value = "Thành tiền";


                for (int i = 0; i < dgvHoaDonBanHang.Rows.Count - 1; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 11).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[0].Value;
                    exSheet.get_Range("B" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[1].Value;
                    exSheet.get_Range("C" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("D" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[3].Value;
                    exSheet.get_Range("E" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("F" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[4].Value;
                    exSheet.get_Range("G" + (i + 8).ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    exSheet.get_Range("G" + (i + 8).ToString()).Value = dgvHoaDonBanHang.Rows[i].Cells[5].Value;
                }
                exSheet.Name = "Hoa Đơn";
                exBook.Activate();

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(.xls)|.xls|Word Document(.doc)|.doc|All files(.)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xlsx";
                dlgSave.FileName = txtMaHoaDon.Text;
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        exSheet.SaveAs(dlgSave.FileName.ToString());
                    }
                    catch (Exception ex) { }
                }


                exApp.Quit();
            }
            else
            {

            }
        }*/
    }
}
