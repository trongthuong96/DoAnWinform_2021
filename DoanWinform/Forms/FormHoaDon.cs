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
        List<CTHD> listCTHD;

        public frmOrder(string maNV)
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
            txtStaffID.Text = maNV;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            listInvoice = dbContext.HoaDons.ToList();
            listCTHD = dbContext.CTHDs.ToList();
            // combox data
            listProduct = dbContext.SanPhams.ToList();

            dgvProductID.DataSource = listProduct;
            dgvProductID.DisplayMember = "TenSP";
            dgvProductID.ValueMember = "MaSP";

            // combo
            List<KhachHang> listCustomer = dbContext.KhachHangs.ToList();
            ShowCombo(listCustomer, listInvoice);
        }

        // combobox begin
        private void ShowCombo(List<KhachHang> listCustomer, List<HoaDon> listInvoice)
        {
            cbbCustomerID.DataSource = listCustomer;
            cbbCustomerID.DisplayMember = "MaKH";
            cbbCustomerID.ValueMember = "MaKH";

            cbbCustomerName.DataSource = listCustomer;
            cbbCustomerName.DisplayMember = "TenKH";
            cbbCustomerName.ValueMember = "MaKH";

            cbbInvoiceID.DataSource = listInvoice;
            cbbInvoiceID.DisplayMember = "MaHD";
            cbbInvoiceID.ValueMember = "MaHD";
            cbbInvoiceID.SelectedIndex = -1;
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
            if(cbbInvoiceID.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã hóa đơn!");
                return false;
            }
            if(dgvOrder.Rows[0].Cells == null || dgvOrder.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Hãy chọn ít nhất 1 sản phẩm!");
                return false;
            }
            if (dtpOrderDate.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày lập hóa đơn phải nhỏ hơn ngày hiện tại!");
                return false;
            }
            return true;
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvOrder.Rows[row].Cells != null && dgvOrder.Rows[row].Cells[0].Value != null && dgvOrder.Rows[row].Cells[1].Value == null)
                {
                    dgvOrder.Rows[row].Cells[1].Value = 1;
                }

                if (dgvOrder.Rows[row].Cells != null && dgvOrder.Rows[row].Cells[1].Value != null && dgvOrder.Rows[row].Cells[2].Value != null)
                {
                    string numS = dgvOrder.Rows[row].Cells[1].Value.ToString();
                    int num;
                    if (int.TryParse(numS, out num) == false || num <= 0)
                    {
                        MessageBox.Show("Hãy nhập số lượng là số và lớn hơn 0");
                        dgvOrder.Rows[row].Cells[1].Value = 1;
                    }

                    string a = (int.Parse(dgvOrder.Rows[row].Cells[1].Value.ToString()) * decimal.Parse(dgvOrder.Rows[row].Cells[2].Value.ToString())).ToString();
                    dgvOrder.Rows[row].Cells[3].Value = a;
                    sum();
                    
                }
            }
            catch (Exception)
            {

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
            dgvOrder.Rows.Clear();
            cbbInvoiceID.SelectedIndex = -1;
            txtSum.Text = "";
        }

        // hiện report
        private void btnShowInvoice_Click(object sender, EventArgs e)
        {

        }

        // thêm hóa đơn
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maHD = cbbInvoiceID.Text.Trim();
            HoaDon hoaDon = listInvoice.FirstOrDefault(m => m.MaHD == maHD);
            if (Checkin())
            {
                if (hoaDon == null)
                {
                    hoaDon = new HoaDon();
                    hoaDon.MaHD = maHD;
                    hoaDon.MaNV = txtStaffID.Text;
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
                        dgvOrder.Rows[i].Cells[4].Value = cthd.MaCTHD.ToString();

                        dbContext.CTHDs.Add(cthd);
                        dbContext.SaveChanges();
                    }
                    listCTHD = dbContext.CTHDs.ToList();
                    listInvoice = dbContext.HoaDons.ToList();
                    cbbInvoiceID.DataSource = listInvoice;

                    MessageBox.Show("Đã tạo xong hóa đơn!");
                }
                else
                {
                    MessageBox.Show("Đã có mã hóa đơn này!");
                    return;
                }
            }
        }

        // tìm hóa đơn
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Clear();
            string maHD = cbbInvoiceID.Text.Trim();
            HoaDon hoaDon = listInvoice.FirstOrDefault(m => m.MaHD == maHD);

            if (hoaDon != null)
            {
                cbbCustomerID.Text = hoaDon.MaKH;
                dtpOrderDate.Value = hoaDon.NgayLapHD;

                List<CTHD> tempCTHD = listCTHD.Where(m => m.MaHD == maHD).ToList();
                int index;
                foreach(CTHD cthd in tempCTHD)
                {
                    index = dgvOrder.Rows.Add();
                    dgvOrder.Rows[index].Cells[0].Value = cthd.MaSP.ToString();
                    dgvOrder.Rows[index].Cells[1].Value = cthd.SLMua.ToString();
                    dgvOrder.Rows[index].Cells[2].Value = Math.Round(cthd.GiaBan).ToString();
                    dgvOrder.Rows[index].Cells[3].Value = Math.Round(cthd.SLMua * cthd.GiaBan).ToString();
                    dgvOrder.Rows[index].Cells[4].Value = cthd.MaCTHD.ToString();
                }
            }
            else
            {
                MessageBox.Show("Không có hóa đơn này!");
                return;
            }
        }

        // sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Checkin())
                {
                    string maHD = cbbInvoiceID.Text.Trim();
                    HoaDon hoaDon = listInvoice.FirstOrDefault(m => m.MaHD == maHD);

                    if (hoaDon != null)
                    {
                        hoaDon.MaNV = txtStaffID.Text;
                        hoaDon.MaKH = cbbCustomerID.Text;
                        hoaDon.NgayLapHD = dtpOrderDate.Value;

                        listInvoice = dbContext.HoaDons.ToList();
                    }

                    int maCTHD;
                    bool a = false;

                    for (int i = 0; i < dgvOrder.Rows.Count - 1; i++)
                    {
                        //kiểm tra maCTHD 
                        if (dgvOrder.Rows[i].Cells[4].Value == null)
                        {
                            maCTHD = -1;
                        }
                        else
                        {
                            a = int.TryParse(dgvOrder.Rows[i].Cells[4].Value.ToString(), out maCTHD);
                        }

                        CTHD cthd = listCTHD.FirstOrDefault(m => m.MaCTHD == maCTHD);
                        if (cthd != null)
                        {
                            cthd.SLMua = int.Parse(dgvOrder.Rows[i].Cells[1].Value.ToString());
                            cthd.GiaBan = decimal.Parse(dgvOrder.Rows[i].Cells[2].Value.ToString());
                            cthd.ThanhTien = cthd.SLMua * cthd.GiaBan;
                        }
                        else
                        {
                            cthd = new CTHD();
                            cthd.MaHD = maHD;
                            cthd.MaSP = dgvOrder.Rows[i].Cells[0].Value.ToString();
                            cthd.SLMua = int.Parse(dgvOrder.Rows[i].Cells[1].Value.ToString());
                            cthd.GiaBan = decimal.Parse(dgvOrder.Rows[i].Cells[2].Value.ToString());
                            cthd.ThanhTien = cthd.SLMua * cthd.GiaBan;
                            dgvOrder.Rows[i].Cells[4].Value = cthd.MaCTHD.ToString();

                            dbContext.CTHDs.Add(cthd);
                        }
                        dbContext.SaveChanges();
                    }
                    listCTHD = dbContext.CTHDs.ToList();
                    listInvoice = dbContext.HoaDons.ToList();
                    cbbInvoiceID.DataSource = listInvoice;
                    MessageBox.Show("Đã sửa xong hóa đơn!");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
