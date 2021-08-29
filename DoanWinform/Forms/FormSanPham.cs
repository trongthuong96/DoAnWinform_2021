using DoanWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanWinform
{
    public partial class frmProduct : Form
    {
        QuanLyBanHang dbContext;
        List<SanPham> listSanPham;

        public frmProduct()
        {
            InitializeComponent();
            dbContext = new QuanLyBanHang();
        }

        // chọn ảnh
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduct.Image = Image.FromFile(opf.FileName);
                pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // tìm dòng chứa sản phẩm trên dataGridView
        private int FindRowProduct(string productID)
        {
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                if (dgvProduct.Rows[i].Cells != null)
                {
                    if (dgvProduct.Rows[i].Cells[1].Value.Equals(productID))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        // kiểm tra nhập sản phẩm
        private bool CheckProduct()
        {
            decimal num;
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "" || txtProductPrice.Text.Trim() == "" || txtQuality.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống: Mã, Tên, Giá, Số lượng sản phẩm!");
                return false;
            }
            else if(!decimal.TryParse(txtProductPrice.Text.Trim(), out num))
            {
                MessageBox.Show("Hãy nhập giá sản phẩm là số tiền!");
                return false;
            }
            else if(!decimal.TryParse(txtQuality.Text.Trim(), out num))
            {
                MessageBox.Show("Hãy nhập số lượng sản phẩm!");
                return false;
            }
            return true;
        }
       

        private void frmProduct_Load(object sender, EventArgs e)
        {
            //create a DataGridView Image Column
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            //set a header test to DataGridView Image Column
            dgvImage.HeaderText = "Hình Ảnh";
            dgvImage.Name = "dgvImage";
            dgvImage.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dgvProduct.Columns.Add(dgvImage);

            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.RowTemplate.Height = 120;

            dgvProduct.AllowUserToAddRows = false;

            // thêm vào list
            listSanPham = dbContext.SanPhams.ToList();
            List<LoaiSanPham> listLoaiSP = dbContext.LoaiSanPhams.ToList();
            ShowCBB(listLoaiSP);

            // hiện lên dataGridView khi mới load
            ShowDgvProduct(listSanPham);

        }

        // sửa dataGridView
        private void EditGridView(int index, byte[] img)
        {
            dgvProduct.Rows[index].Cells[1].Value = txtProductID.Text.Trim();
            dgvProduct.Rows[index].Cells[2].Value = cbbProductType.Text;
            dgvProduct.Rows[index].Cells[3].Value = txtProductName.Text.Trim();
            dgvProduct.Rows[index].Cells[4].Value = txtProductPrice.Text.Trim();
            dgvProduct.Rows[index].Cells[5].Value = txtQuality.Text.Trim();
            dgvProduct.Rows[index].Cells[6].Value = rtbDetail.Text.Trim();
            dgvProduct.Rows[index].Cells[7].Value = img;

        }

        // hiện danh sách
        private void ShowDgvProduct(List<SanPham> listSanPham)
        {
            dgvProduct.Rows.Clear();
            int index;

            foreach (SanPham sanPham in listSanPham)
            {
                index = dgvProduct.Rows.Add();
                dgvProduct.Rows[index].Cells[0].Value = index + 1;
                dgvProduct.Rows[index].Cells[1].Value = sanPham.MaSP;
                dgvProduct.Rows[index].Cells[2].Value = sanPham.LoaiSanPham.TenLoaiSP;
                dgvProduct.Rows[index].Cells[3].Value = sanPham.TenSP;
                dgvProduct.Rows[index].Cells[4].Value = Math.Round(sanPham.GiaSP);
                dgvProduct.Rows[index].Cells[5].Value = sanPham.SoLuong;
                dgvProduct.Rows[index].Cells[6].Value = sanPham.ChiTietSP;
                dgvProduct.Rows[index].Cells[7].Value = sanPham.HinhAnh;
            }
        }

        // hiện combobox
        private void ShowCBB(List<LoaiSanPham> listLoaiSP)
        {
            cbbProductType.DataSource = listLoaiSP;
            cbbProductType.DisplayMember = "TenLoaiSP";
            cbbProductType.ValueMember = "MaLSP";
        }

        // hiện lại textbox
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvProduct.CurrentRow.Selected = true;
                    txtProductID.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvProductID"].FormattedValue.ToString();
                    txtProductName.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvProductName"].FormattedValue.ToString();
                    cbbProductType.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvProductType"].FormattedValue.ToString();
                    txtProductPrice.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvPrice"].FormattedValue.ToString();
                    txtQuality.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvQuanlityInStock"].FormattedValue.ToString();
                    rtbDetail.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvDetail"].FormattedValue.ToString();
                    txtProductName.Text = dgvProduct.Rows[e.RowIndex].Cells["dgvProductName"].FormattedValue.ToString();

                    // ảnh
                    if (dgvProduct.SelectedRows[0].Cells["dgvImage"].Value != null)
                    {
                        pictureBoxProduct.Text = dgvProduct.SelectedRows[0].Cells["dgvImage"].Value.ToString();
                        byte[] bytes = (byte[])dgvProduct.SelectedRows[0].Cells["dgvImage"].Value;
                        MemoryStream ms = new MemoryStream(bytes);
                        pictureBoxProduct.Image = Image.FromStream(ms);
                        pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBoxProduct.Image = null;
                    }
                   
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }

        // thêm sản phẩm
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckProduct())
                {
                    byte[] img = null;
                    if (pictureBoxProduct.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBoxProduct.Image.Save(ms, pictureBoxProduct.Image.RawFormat);
                        img = ms.ToArray();
                    }

                    SanPham sanPham = listSanPham.FirstOrDefault(t => t.MaSP.Equals(txtProductID.Text.Trim()));
                    if (sanPham == null)
                    {
                        bool checkName = listSanPham.Any(t => t.TenSP.ToLower().Equals(txtProductName.Text.Trim()));
                        if (checkName)
                        {
                            MessageBox.Show("Trùng tên sản phẩm");
                            return;
                        }

                        sanPham = new SanPham();
                        sanPham.MaSP = txtProductID.Text.Trim();
                        sanPham.TenSP = txtProductName.Text.Trim();
                        sanPham.GiaSP = decimal.Parse(txtProductPrice.Text.Trim());
                        sanPham.HinhAnh = img;
                        sanPham.SoLuong = int.Parse(txtQuality.Text.Trim());
                        sanPham.MaLSP = cbbProductType.SelectedValue.ToString();
                        sanPham.ChiTietSP = rtbDetail.Text.Trim();

                        dbContext.SanPhams.Add(sanPham);
                        dbContext.SaveChanges();

                        listSanPham = dbContext.SanPhams.ToList();

                        int index = dgvProduct.Rows.Add();
                        EditGridView(index, img);
                        MessageBox.Show("Thêm sản phẩm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Đã có sản phẩm này!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //nút Sửa thông tin
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //
            try
            {
                if (CheckProduct())
                {
                    byte[] img = null;
                    if (pictureBoxProduct.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBoxProduct.Image.Save(ms, pictureBoxProduct.Image.RawFormat);
                        img = ms.ToArray();
                    }

                    SanPham sanPham = listSanPham.FirstOrDefault(t => t.MaSP.Equals(txtProductID.Text.Trim()));
                    if (sanPham != null)
                    {
                        if(listSanPham.Any(t=>t.TenSP.Equals(txtProductName.Text.Trim()) && t.TenSP != sanPham.TenSP))
                        {
                            MessageBox.Show("Trùng tên sản phẩm khác!");
                            return;
                        }

                        DialogResult dialogResult = MessageBox.Show("Bạn muốn có muốn sửa đổi thông tin này?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            sanPham.MaSP = txtProductID.Text.Trim();
                            sanPham.TenSP = txtProductName.Text.Trim();
                            sanPham.GiaSP = decimal.Parse(txtProductPrice.Text.Trim());
                            sanPham.HinhAnh = img;
                            sanPham.SoLuong = int.Parse(txtQuality.Text.Trim());
                            sanPham.MaLSP = cbbProductType.SelectedValue.ToString();
                            sanPham.ChiTietSP = rtbDetail.Text.Trim();


                            dbContext.SaveChanges();

                            listSanPham = dbContext.SanPhams.ToList();

                            int index = FindRowProduct(txtProductID.Text.Trim());
                            EditGridView(index, img);
                            MessageBox.Show("Sửa sản phẩm thành công!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm này!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // nút xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtProductID.Text.Trim();
                SanPham sanPham = listSanPham.Find(k => k.MaSP.Equals(maSP));

                if (sanPham != null)
                {

                    // Hỏi trước khi xóa
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn có muốn xóa sản phẩm này?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // xóa trong data
                        dbContext.SanPhams.Remove(sanPham);
                        dbContext.SaveChanges();

                        // 
                        listSanPham = dbContext.SanPhams.ToList();

                        // xóa trong gridView
                        int index = FindRowProduct(txtProductID.Text.Trim());
                        dgvProduct.Rows.Remove(dgvProduct.Rows[index]);

                        // xếp lại STT
                        for(int i=0; i<dgvProduct.Rows.Count; i++)
                        {
                            dgvProduct.Rows[i].Cells[0].Value = i + 1;
                        }

                        MessageBox.Show("Xóa thông tin sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm sản phẩm này!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
