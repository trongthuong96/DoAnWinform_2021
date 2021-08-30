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
    public partial class frmLogin : Form
    {

        //delegate đăng nhập
        public delegate void DangNhap();
        public event DangNhap DangNhapThanhCong;

        QuanLyBanHang dbContext;

        public frmLogin()
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
            lblDangNhap.BackColor = Color.Transparent;
            lblMatKhau.BackColor = Color.Transparent;
            lblHeader.BackColor = Color.Transparent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txtAccountName.Text.Trim();
                string matKhau = txtPassword.Text.Trim();

                // kiểm tra xem đúng tài khoản không
                TaiKhoan taiKhoan = dbContext.TaiKhoans.FirstOrDefault(t => t.TenDangNhap.Equals(tenDangNhap));               
                if (taiKhoan != null)
                {
                    if (StringCipher.Decrypt(taiKhoan.MatKhau, "").Equals(matKhau))
                    {
                        DangNhapThanhCong();
                        MessageBox.Show("Đăng nhập tài khoản thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đăng nhập sai!");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập sai!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
