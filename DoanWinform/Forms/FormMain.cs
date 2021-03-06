using DoanWinform.Forms;
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
    public partial class frmMain : Form
    {
        QuanLyBanHang dbContext;

        public frmMain()
        {
            InitializeComponent();
            try
            {
                dbContext = new QuanLyBanHang();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        // hóa đơn
        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrder frmOrder = new frmOrder(maNV);
            frmOrder.MdiParent = this;
            frmOrder.Show();
        }

        // Đăng nhập
        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kiểm tra sự tồn tại form
            Form frm = this.MdiChildren.OfType<frmLogin>().FirstOrDefault();
            if(frm == null)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.DangNhapThanhCong += FrmLogin_DangNhapThanhCong;
                frmLogin.MdiParent = this;
                frmLogin.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        // Ẩn hiện nút khi đăng nhập
        string maNV;
        private void FrmLogin_DangNhapThanhCong(string maNV)
        {
            this.maNV = maNV;
            LoginToolStripMenuItem.Visible = false;
            ManageToolStripMenuItem.Visible = true;
            RegisterToolStripMenuItem.Visible = false;
            LogoutToolStripMenuItem.Visible = true;
            toolStripBtnCustomer.Enabled = true;
            toolStripBtnProduct.Enabled = true;
        }

        // Đăng ký
        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kiểm tra sự tồn tại form
            Form frm = this.MdiChildren.OfType<frmRegister>().FirstOrDefault();
            if (frm == null)
            {
                frmRegister frmRegister = new frmRegister();
                frmRegister.MdiParent = this;
                frmRegister.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        // Ẩn hiện nút khi đăng xuất
        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbContext = null;
            ManageToolStripMenuItem.Visible = false;
            RegisterToolStripMenuItem.Visible = true;
            LogoutToolStripMenuItem.Visible = false;
            LoginToolStripMenuItem.Visible = true;
            toolStripBtnCustomer.Enabled = false;
            toolStripBtnProduct.Enabled = false;
        }

        // khách hàng
        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kiểm tra sự tồn tại form
            Form frm = this.MdiChildren.OfType<frmCustomer>().FirstOrDefault();
            if (frm == null)
            {
                frmCustomer frmCustomer = new frmCustomer();
                frmCustomer.MdiParent = this;
                frmCustomer.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        // sản phẩm
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kiểm tra sự tồn tại form
            Form frm = this.MdiChildren.OfType<frmProduct>().FirstOrDefault();
            if (frm == null)
            {
                frmProduct frmProduct = new frmProduct();
                frmProduct.MdiParent = this;
                frmProduct.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        // loại sp
        private void ProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kiểm tra sự tồn tại form
            Form frm = this.MdiChildren.OfType<frmProductType>().FirstOrDefault();
            if (frm == null)
            {
                frmProductType frmProductType = new frmProductType();
                frmProductType.MdiParent = this;
                frmProductType.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // hiển thị giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Ngày {0} - Giờ {1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }
    }
}
