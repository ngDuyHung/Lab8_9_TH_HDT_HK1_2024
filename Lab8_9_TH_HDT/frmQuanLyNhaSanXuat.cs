using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_9_TH_HDT
{
    public partial class frmQuanLyNhaSanXuat : Form
    {
        private XuLyNhaSanXuat xuLy;
        public frmQuanLyNhaSanXuat()
        {
            InitializeComponent();
            xuLy = new XuLyNhaSanXuat();
        }

        private void frmQuanLyNhaSanXuat_Load(object sender, EventArgs e)
        {
            List<NhaSanXuat> dsNhaSanXuat = xuLy.getDanhSachNhaSanXuat();
            hienThiDanhSachNhaSanXuat(dgvNhaSanXuat, dsNhaSanXuat);
        }

        private void hienThiDanhSachNhaSanXuat(DataGridView dgv, List<NhaSanXuat> ds)
        {
            // dgv.DataSource = null;
            dgv.DataSource = ds.ToList();
            // dgv.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNSX = txtMaNSX.Text;
            string teNSX = txtTenNSX.Text;
            string dienThoai = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            NhaSanXuat nsx = new NhaSanXuat(maNSX, teNSX, dienThoai, diaChi);
            if (this.xuLy.Them(nsx))
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                hienThiDanhSachNhaSanXuat(dgvNhaSanXuat, xuLy.getDanhSachNhaSanXuat());
            }
            else
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo");
            }
        }

        private void dgvNhaSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < dgvNhaSanXuat.RowCount)
            {

                if (dgvNhaSanXuat.Rows[index].Cells[0].Value != null)
                {

                    string maNSX = dgvNhaSanXuat.Rows[index].Cells[0].Value.ToString();

                    NhaSanXuat nsx = xuLy.Tim(maNSX);
                    if (nsx != null)
                    {
                        txtMaNSX.Text = nsx.MaNSX;
                        txtTenNSX.Text = nsx.TenNSX;
                        txtDiaChi.Text = nsx.DiaChi;
                        txtSDT.Text = nsx.DienThoai;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị ô không hợp lệ", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chỉ số hàng không hợp lệ", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNSX = txtMaNSX.Text;
            if (this.xuLy.Xoa(maNSX))
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                hienThiDanhSachNhaSanXuat(dgvNhaSanXuat, xuLy.getDanhSachNhaSanXuat());
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã để xóa", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNSX = txtMaNSX.Text;
            string tenNSX = txtTenNSX.Text;
            string diaChi = txtDiaChi.Text;
            string sDT = txtSDT.Text;
            NhaSanXuat nsx = new NhaSanXuat(maNSX, tenNSX, sDT, diaChi);
            if (this.xuLy.Sua(nsx))
            {
                MessageBox.Show("Sửa thành công", "Thông báo");
                hienThiDanhSachNhaSanXuat(dgvNhaSanXuat, xuLy.getDanhSachNhaSanXuat());
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã để sửa", "Thông báo");
            }
        }
    }
}
