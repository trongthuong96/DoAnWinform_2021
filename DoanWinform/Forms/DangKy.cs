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

namespace DoanWinform.Forms
{
    public partial class frmRegister : Form
    {
        QuanLyBanHang dbContext;

        public frmRegister()
        {
            InitializeComponent();
            try
            {
                dbContext = new QuanLyBanHang();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string tenTK = txtAccountName.Text.Trim();
                string matKhau = txtPassword1.Text.Trim();

                // kiểm tra hai mật khẩu lúc đăng nhập
                if (!matKhau.Equals(txtPassword2.Text.Trim())){
                    MessageBox.Show("Mật khẩu khác nhau. Vui lòng nhập lại");
                    return;
                }

                // kiểm tra xem tài khoản tồn tại chưa
                TaiKhoan taiKhoan = dbContext.TaiKhoans.FirstOrDefault(t => t.MaNV.Equals(txtStaffID.Text.Trim()));
                if (taiKhoan == null)
                {
                    NhanVien nhanVien = dbContext.NhanViens.FirstOrDefault(n => n.MaNV == txtStaffID.Text.Trim());

                    if (nhanVien == null)
                    {
                        MessageBox.Show("Vui lòng nhập đúng mã nhân viên!");
                        return;
                    }
                    if(dbContext.TaiKhoans.Any(t => t.TenDangNhap == txtAccountName.Text.Trim()))
                    {
                        MessageBox.Show("Trùng tên đăng nhập!");
                        return;
                    }

                    taiKhoan = new TaiKhoan();
                    taiKhoan.MaNV = txtStaffID.Text.Trim();
                    taiKhoan.TenDangNhap = tenTK;
                    taiKhoan.MatKhau = StringCipher.Encrypt(matKhau,"");

                    dbContext.TaiKhoans.Add(taiKhoan);
                    dbContext.SaveChanges();

                    MessageBox.Show("Đăng ký tài khoản thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nhân viên đã có tài khoản!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
