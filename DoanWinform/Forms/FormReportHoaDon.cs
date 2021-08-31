using DoanWinform.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanWinform.Forms
{
    public partial class frmReportHoaDon : Form
    {
        QuanLyBanHang dbContext;
        public frmReportHoaDon()
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
        }

        public frmReportHoaDon(string maHD)
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
            txtInvoiceID.Text = maHD;
        }

        private void FormReportHoaDon_Load(object sender, EventArgs e)
        {
            List<CTHD> listDetail = dbContext.CTHDs.Where(h => h.MaHD == txtInvoiceID.Text.Trim()).ToList();

            List<HoaDonReport> listHoaDonReport = new List<HoaDonReport>();
            
            foreach(var item in listDetail)
            {
                HoaDonReport cthd = new HoaDonReport();
                cthd.MaHD = item.MaHD;
                cthd.MaSP = item.MaSP;
                cthd.TenSP = item.SanPham.TenSP;
                cthd.SLMua = item.SLMua;
                cthd.GiaBan = item.GiaBan;
                cthd.ThanhTien = item.ThanhTien;
                cthd.MaKH = item.HoaDon.KhachHang.MaKH;
                cthd.TenKH = item.HoaDon.KhachHang.TenKH;

                listHoaDonReport.Add(cthd);
            }


            ReportParameter[] param = new ReportParameter[1];
            HoaDon hoaDon = dbContext.HoaDons.FirstOrDefault(t => t.MaHD == txtInvoiceID.Text);
            if (hoaDon != null)
            {
                param[0] = new ReportParameter("NgayLapHD", string.Format("Ngày lập hóa đơn " + hoaDon.NgayLapHD.ToString("dd/MM/yyyy")));
            }
            else
            {
                param[0] = new ReportParameter("NgayLapHD","1");
            }


            reportViewer1.LocalReport.ReportPath = "./Report/ReportHoaDon.rdlc";
            reportViewer1.LocalReport.SetParameters(param);
            ReportDataSource reportDataSource = new ReportDataSource("DataSetHoaDon", listHoaDonReport);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DisplayName = "Danh Sách Hóa Đơn"; //tên hiển thị
            this.reportViewer1.RefreshReport();
        }
    }
}
