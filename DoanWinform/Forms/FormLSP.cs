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
    public partial class frmProductType : Form
    {
        QuanLyBanHang dbContext;
        List<LoaiSanPham> listLSP;

        public frmProductType()
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
        }

        private void frmProductType_Load(object sender, EventArgs e)
        {
            listLSP = dbContext.LoaiSanPhams.ToList();
            ShowDgvProductType(listLSP);
        }

        // hiện danh sách
        private void ShowDgvProductType(List<LoaiSanPham> listLSP)
        {
            dgvProductType.Rows.Clear();
            int index;

            foreach(LoaiSanPham item in listLSP)
            {
                index = dgvProductType.Rows.Add();
                dgvProductType.Rows[index].Cells[0].Value = index + 1;
                dgvProductType.Rows[index].Cells[1].Value = item.MaLSP;
                dgvProductType.Rows[index].Cells[2].Value = item.TenLoaiSP;
            }
        }

        //check 
        private bool CheckProductType()
        {
            if (txtTypeName.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống!");
                return false;
            }

            return true;
        }

        //đổ từ gridView  về textbox
        private void dgvProductType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductType.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvProductType.CurrentRow.Selected = true;

                txtTypeID.Text = dgvProductType.Rows[e.RowIndex].Cells["dgvTypeID"].FormattedValue.ToString();
                txtTypeName.Text = dgvProductType.Rows[e.RowIndex].Cells["dgvProductTypeName"].FormattedValue.ToString();
            }
        }

        // thêm
        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            if (CheckProductType())
            {
                LoaiSanPham loaiSanPham = listLSP.FirstOrDefault(t => t.MaLSP == txtTypeID.Text.Trim());

                if (loaiSanPham == null)
                {
                    if (listLSP.Any(t => t.TenLoaiSP == txtTypeName.Text.Trim()))
                    {
                        MessageBox.Show("Trùng tên loại sản phẩm");
                        return;
                    }

                    loaiSanPham = new LoaiSanPham();

                    loaiSanPham.MaLSP = txtTypeID.Text.Trim();
                    loaiSanPham.TenLoaiSP = txtTypeName.Text.Trim();

                    dbContext.LoaiSanPhams.Add(loaiSanPham);
                    dbContext.SaveChanges();

                    frmProductType_Load(sender, e);
                    MessageBox.Show("Thêm loại sản phẩm thành công!");
                }
                else
                {
                    MessageBox.Show("Đã có sản phẩm rồi!");
                }
                
            }
        }

        // sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckProductType())
                {
                    LoaiSanPham loaiSanPham = listLSP.FirstOrDefault(t => t.MaLSP == txtTypeID.Text.Trim());

                    if (loaiSanPham != null)
                    {
                        if (listLSP.Any(t => t.TenLoaiSP == txtTypeName.Text.Trim() && t.TenLoaiSP != loaiSanPham.TenLoaiSP))
                        {
                            MessageBox.Show("Trùng tên loại sản phẩm");
                            return;
                        }

                        loaiSanPham.TenLoaiSP = txtTypeName.Text.Trim();

                        dbContext.SaveChanges();

                        frmProductType_Load(sender, e);
                        MessageBox.Show("Sửa loại sản phẩm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm!");
                    }
                }
            }
            catch (Exception) { }
        }

        // xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSanPham loaiSanPham = listLSP.FirstOrDefault(t => t.MaLSP == txtTypeID.Text.Trim());

                if (loaiSanPham != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dbContext.LoaiSanPhams.Remove(loaiSanPham);
                        dbContext.SaveChanges();

                        frmProductType_Load(sender, e);
                        MessageBox.Show("Xóa loại sản phẩm thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm!");
                }
            }
            catch (Exception) { }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
