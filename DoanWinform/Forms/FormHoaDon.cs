using DoanWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanWinform
{
    public partial class frmOrder : Form
    {
        QuanLyBanHang dbContext;
        List<HoaDon> listInvoice;
        List<SanPham> listProduct;
        public frmOrder()
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            listInvoice = dbContext.HoaDons.ToList();

            // combox data
            listProduct = dbContext.SanPhams.ToList();

            dgvProductID.DataSource = listProduct;
            dgvProductID.DisplayMember = "TenSP";
            dgvProductID.ValueMember = "MaSP";

            // combo
            List<KhachHang> listCustomer = dbContext.KhachHangs.ToList();
            List<NhanVien> listStaff = dbContext.NhanViens.ToList();
            ShowCombo(listCustomer, listStaff);
        }

        // combobox begin
        private void ShowCombo(List<KhachHang> listCustomer, List<NhanVien> listStaff)
        {
            cbbCustomerID.DataSource = listCustomer;
            cbbCustomerID.DisplayMember = "MaKH";
            cbbCustomerID.ValueMember = "MaKH";

            cbbCustomerName.DataSource = listCustomer;
            cbbCustomerName.DisplayMember = "TenKH";
            cbbCustomerName.ValueMember = "MaKH";

            cbbStaff.DataSource = listStaff;
            cbbStaff.DisplayMember = "MaNV";
            cbbStaff.ValueMember = "MaNV";
        }

        private void cbbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
                cbbCustomerName.DisplayMember = cbbCustomerID.Text;
        }

        private void cbbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
                cbbCustomerID.DisplayMember = cbbCustomerName.Text;
        }
        // combobox end

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maHD = txtOrderID.Text.Trim();
            HoaDon hoaDon = listInvoice.FirstOrDefault(m => m.MaHD == maHD);
            if (Checkin())
            {
                if (hoaDon == null)
                {
                    hoaDon = new HoaDon();
                    hoaDon.MaHD = maHD;
                    hoaDon.MaNV = cbbStaff.Text;
                    hoaDon.MaKH = cbbCustomerID.Text;
                    hoaDon.NgayLapHD = dtpOrderDate.Value;

                    dbContext.HoaDons.Add(hoaDon);
                    dbContext.SaveChanges();
                    listInvoice = dbContext.HoaDons.ToList();

                    for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
                    {
                        CTHD cthd = new CTHD();
                        cthd.MaHD = maHD;
                        cthd.MaSP = dgvOrder.Rows[i].Cells[0].Value.ToString();
                        cthd.SLMua = int.Parse(dgvOrder.Rows[i].Cells[1].Value.ToString());
                        cthd.GiaBan = decimal.Parse(dgvOrder.Rows[i].Cells[2].Value.ToString());
                        cthd.ThanhTien = cthd.SLMua * cthd.GiaBan;

                        dbContext.CTHDs.Add(cthd);
                        dbContext.SaveChanges();
                    }

                }
                else
                {
                    MessageBox.Show("Đã có mã hóa đơn này!");
                    return;
                }
            }
        }

        // cell
        int row = 0;
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        // tính tiền
        private void sum()
        {
            decimal sum = 0;
            for(int i = 0; i<dgvOrder.Rows.Count; i++)
            {
                if (dgvOrder.Rows[i].Cells[3].Value != null)
                {
                    sum += decimal.Parse(dgvOrder.Rows[i].Cells[3].Value.ToString());
                }
            }
            
            txtSum.Text = sum.ToString();
        }

        // check rỗng lúc nhập
        private bool Checkin()
        {
            if(txtOrderID.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã hóa đơn!");
                return false;
            }
            if(dgvOrder.Rows[0].Cells == null || dgvOrder.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Hãy chọn ít nhất 1 sản phẩm!");
                return false;
            }

            return true;
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvOrder.Rows[row].Cells != null && dgvOrder.Rows[row].Cells[0].Value != null && dgvOrder.Rows[row].Cells[1].Value == null)
            {
                dgvOrder.Rows[row].Cells[1].Value = 1;
            }

            if (dgvOrder.Rows[row].Cells != null && dgvOrder.Rows[row].Cells[1].Value != null && dgvOrder.Rows[row].Cells[2].Value != null)
            {
                try
                {
                    string numS = dgvOrder.Rows[row].Cells[1].Value.ToString();
                    int num;
                    if(int.TryParse(numS, out num) == false || num <= 0)
                    {
                        MessageBox.Show("Hãy nhập số lượng là số và lớn hơn 0");
                        dgvOrder.Rows[row].Cells[1].Value = 1;
                    }

                    string a = (int.Parse(dgvOrder.Rows[row].Cells[1].Value.ToString()) * decimal.Parse(dgvOrder.Rows[row].Cells[2].Value.ToString())).ToString();
                    dgvOrder.Rows[row].Cells[3].Value = a;
                    sum();
                }
                catch
                {

                }
            }

            try
            {
                if (dgvOrder.Rows[row].Cells != null && dgvOrder.Rows[row].Cells[0].Value != null)
                {
                    string maSP = dgvOrder.Rows[row].Cells[0].Value.ToString();
                    SanPham sanPham = listProduct.FirstOrDefault(s => s.MaSP.Equals(maSP));
                    decimal GiaSP = sanPham.GiaSP;
                    dgvOrder.Rows[row].Cells[2].Value = Math.Round(sanPham.GiaSP);
                }
            }
            catch
            {

            }
        }

        // thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFomat_Click(object sender, EventArgs e)
        {
            cbbCustomerID.SelectedIndex = 0;
            cbbStaff.SelectedIndex = 0;
            dgvOrder.Rows.Clear();
            txtOrderID.Text = "";
        }
    }
}
