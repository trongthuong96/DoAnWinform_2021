using DoanWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanWinform
{
    public partial class frmCustomer : Form
    {
        QuanLyBanHang dbContext;
        List<KhachHang> listKhachHang = null;

        public frmCustomer()
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

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            listKhachHang = dbContext.KhachHangs.ToList();
            ShowDgvCustomer(listKhachHang);
        }

        // sửa dataGridView
        private void EditGridView(int index)
        {
            dgvCustomer.Rows[index].Cells[1].Value = txtCustomerID.Text.Trim();
            dgvCustomer.Rows[index].Cells[2].Value = txtCustomerName.Text.Trim();
            dgvCustomer.Rows[index].Cells[3].Value = txtAddress.Text.Trim();
            dgvCustomer.Rows[index].Cells[4].Value = mtbPhoneNumber.Text.Trim();
            dgvCustomer.Rows[index].Cells[5].Value = txtEmail.Text.Trim();

            if (rdbMale.Checked)
            {
                dgvCustomer.Rows[index].Cells[6].Value = "Nam";
            }
            else if (rdbFemale.Checked)
            {
                dgvCustomer.Rows[index].Cells[6].Value = "Nữ";
            }
            else
            {
                dgvCustomer.Rows[index].Cells[6].Value = "Khác";
            }

            dgvCustomer.Rows[index].Cells[7].Value = dtpBirthday.Value.ToString("dd/MM/yyyy");

        }

        // hiện danh sách
        private void ShowDgvCustomer(List<KhachHang> listKhachHang)
        {
            dgvCustomer.Rows.Clear();
            int index;

            foreach(KhachHang khachHang in listKhachHang)
            {
                index = dgvCustomer.Rows.Add();
                dgvCustomer.Rows[index].Cells[0].Value = index + 1;
                dgvCustomer.Rows[index].Cells[1].Value = khachHang.MaKH;
                dgvCustomer.Rows[index].Cells[2].Value = khachHang.TenKH;
                dgvCustomer.Rows[index].Cells[3].Value = khachHang.DiaChi;
                dgvCustomer.Rows[index].Cells[4].Value = khachHang.SDT;
                dgvCustomer.Rows[index].Cells[5].Value = khachHang.Email;

                if (khachHang.GioiTinh == 0)
                {
                    dgvCustomer.Rows[index].Cells[6].Value = "Nữ";
                }
                else if(khachHang.GioiTinh == 1)
                {
                    dgvCustomer.Rows[index].Cells[6].Value = "Nam";
                }
                else
                {
                    dgvCustomer.Rows[index].Cells[6].Value = "Khác";
                }
                
                dgvCustomer.Rows[index].Cells[7].Value = khachHang.NgaySinh.ToString("dd/MM/yyyy");
            }
        }

        // Kiểm tra khách hàng
        private bool CheckCustomer()
        {
            if (txtCustomerID.Text.Trim() == "" || txtCustomerName.Text.Trim() == "" || txtAddress.Text.Trim()==""
                
                || txtEmail.Text.Trim()=="" || mtbPhoneNumber.Text.Trim() == "")
            {
                MessageBox.Show("Không đc để trống!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if(mtbPhoneNumber.Text.Trim().Length != 10)
            {
                MessageBox.Show("Nhập đủ 10 số điện thoại!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // thêm
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCustomer())
                {
                    string maKH = txtCustomerID.Text.Trim();
                    KhachHang khachHang = listKhachHang.Find(k => k.MaKH.Equals(maKH));

                    if (khachHang == null)
                    {
                        khachHang = new KhachHang();

                        khachHang.MaKH = maKH;
                        khachHang.TenKH = txtCustomerName.Text.Trim();
                        khachHang.DiaChi = txtAddress.Text.Trim();
                        khachHang.NgaySinh = dtpBirthday.Value.Date;

                        // Kiểm tra mail
                        if (listKhachHang.Any(s => s.Email.Equals(txtEmail.Text.Trim())))
                        {
                            MessageBox.Show("Đã có email này!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        khachHang.Email = txtEmail.Text.Trim();

                        // Kiểm tra SĐT
                        if (listKhachHang.Any(s => s.SDT.Equals(mtbPhoneNumber.Text.Trim())))
                        {
                            MessageBox.Show("Đã có số điện thoại này!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        khachHang.SDT = mtbPhoneNumber.Text.Trim();

                        if (rdbMale.Checked == true)
                        {
                            khachHang.GioiTinh = 1;
                        }
                        else if (rdbFemale.Checked == true)
                        {
                            khachHang.GioiTinh = 0;
                        }
                        else
                        {
                            khachHang.GioiTinh = -1;
                        }

                        dbContext.KhachHangs.AddOrUpdate(khachHang);
                        dbContext.SaveChanges();

                        listKhachHang = dbContext.KhachHangs.ToList();

                        // thêm dòng gridView
                        int index = dgvCustomer.Rows.Add();
                        dgvCustomer.Rows[index].Cells[0].Value = index + 1;
                        EditGridView(index);

                        MessageBox.Show("Thêm khách hàng thành công!","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có mã khách hàng này rồi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // tìm dòng chứa khách trên dataGridView
        private int FindRowCustomer(string CustomerID)
        {
            for(int i=0; i<dgvCustomer.Rows.Count; i++)
            {
                if (dgvCustomer.Rows[i].Cells != null)
                {
                   if( dgvCustomer.Rows[i].Cells[1].Value.Equals(CustomerID))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        // sửa thông tin khách hàng
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCustomer())
                {
                    string maKH = txtCustomerID.Text.Trim();
                    KhachHang khachHang = listKhachHang.Find(k => k.MaKH.Equals(maKH));

                    if (khachHang != null)
                    {
                        // kiểm tra mail
                        if (listKhachHang.Any(s => s.Email.Equals(txtEmail.Text.Trim())) && txtEmail.Text.Trim() != khachHang.Email)
                        {
                            MessageBox.Show("Đã có email này!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        khachHang.Email = txtEmail.Text.Trim();

                        // kiểm tra SĐT
                        if (listKhachHang.Any(s => s.SDT.Equals(mtbPhoneNumber.Text.Trim())) && mtbPhoneNumber.Text.Trim() != khachHang.SDT)
                        {
                            MessageBox.Show("Đã có số điện thoại này!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        khachHang.SDT = mtbPhoneNumber.Text.Trim();

                        if (rdbMale.Checked == true)
                        {
                            khachHang.GioiTinh = 1;
                        }
                        else if (rdbFemale.Checked == true)
                        {
                            khachHang.GioiTinh = 0;
                        }
                        else
                        {
                            khachHang.GioiTinh = -1;
                        }

                        // Hỏi trước khi sửa
                        DialogResult dialogResult = MessageBox.Show("Bạn muốn có muốn sửa đổi thông tin này?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            khachHang.MaKH = maKH;
                            khachHang.TenKH = txtCustomerName.Text.Trim();
                            khachHang.DiaChi = txtAddress.Text.Trim();
                            khachHang.NgaySinh = dtpBirthday.Value.Date;

                            // sửa trong data
                            dbContext.KhachHangs.AddOrUpdate(khachHang);
                            dbContext.SaveChanges();


                            listKhachHang = dbContext.KhachHangs.ToList();
                            // sửa lại trong grid
                            int index = FindRowCustomer(txtCustomerID.Text.Trim());
                            EditGridView(index);

                            MessageBox.Show("Sửa thông tin khách hàng thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm khách hàng này rồi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đổ dữ liệu từ dataGridView lên lại textbox
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvCustomer.CurrentRow.Selected = true;
                    txtCustomerID.Text = dgvCustomer.Rows[e.RowIndex].Cells["dgvCustomerID"].FormattedValue.ToString();
                    txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells["dgvCustomerName"].FormattedValue.ToString();
                    txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells["dgvAddress"].FormattedValue.ToString();
                    txtEmail.Text = dgvCustomer.Rows[e.RowIndex].Cells["dgvEmail"].FormattedValue.ToString();
                    mtbPhoneNumber.Text = dgvCustomer.Rows[e.RowIndex].Cells["dgvPhoneNumber"].FormattedValue.ToString();
                    dtpBirthday.Value = DateTime.ParseExact(dgvCustomer.Rows[e.RowIndex].Cells["dgvBirthday"].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    
                    string gender = dgvCustomer.Rows[e.RowIndex].Cells["dgvGender"].FormattedValue.ToString();
                    if (gender.Equals("Nữ"))
                    {
                        rdbFemale.Checked = true;
                    }    
                    else if (gender.Equals("Nam"))
                    {
                        rdbMale.Checked = true;
                    }
                    else
                    {
                        rdbOrder.Checked = true;
                    }

                }

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtCustomerID.Text.Trim();
                KhachHang khachHang = listKhachHang.Find(k => k.MaKH.Equals(maKH));

                if (khachHang != null)
                {

                    // Hỏi trước khi xóa
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn có muốn xóa khách hàng này?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // xóa trong data
                        dbContext.KhachHangs.Remove(khachHang);
                        dbContext.SaveChanges();

                        // 
                        listKhachHang = dbContext.KhachHangs.ToList();

                        // xóa trong gridView
                        int index = FindRowCustomer(txtCustomerID.Text.Trim());
                        dgvCustomer.Rows.Remove(dgvCustomer.Rows[index]);

                        // xếp lại số thứ tự
                        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                        {
                            dgvCustomer.Rows[i].Cells[0].Value = i + 1;
                        }

                        MessageBox.Show("Xóa thông tin khách hàng thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm khách hàng này rồi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
