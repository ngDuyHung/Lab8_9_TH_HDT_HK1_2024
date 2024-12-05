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
    public partial class frmQuanLyHangHoa : Form
    {
        private XuLyHangHoa xuLyHang;
        public frmQuanLyHangHoa()
        {
            InitializeComponent();
         
        }

        private void frmQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            xuLyHang = new XuLyHangHoa();
            hienThiDanhSachNhaSanXuat(cboNSX, xuLyHang.getDanhSachNhaSanXuat());
            hienThiDanhSachHangHoa(dgvHangHoa, xuLyHang.getDanhSachHangHoa());

        }
        private void hienThiDanhSachNhaSanXuat(ComboBox cbo,List<NhaSanXuat> ds)
        {
            cbo.DisplayMember = "tenNSX";
            cbo.ValueMember = "maNSX";
            cbo.DataSource = ds;
        }
        private void hienThiDanhSachHangHoa(DataGridView dgv, List<HangHoa> ds)
        {
           // dgv.DataSource = null;
            dgv.DataSource = ds.ToList();
          //  dgv.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHang=txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string donViTinh = txtDonVT.Text;
            if(!double.TryParse(txtDonGia.Text, out double donGia))
            {
                MessageBox.Show("Đơn giá phải là số");
                return;
            }
            NhaSanXuat nsx = new NhaSanXuat();
            nsx.TenNSX = cboNSX.Text;
            nsx.MaNSX=cboNSX.SelectedValue.ToString();


            HangHoa hh=new HangHoa(maHang, tenHang, donViTinh, donGia, nsx);
            if (this.xuLyHang.Them(hh))
            {
                MessageBox.Show("Thành công");
                hienThiDanhSachHangHoa(dgvHangHoa, xuLyHang.getDanhSachHangHoa());
            }
            else { MessageBox.Show("Thất bại"); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            if (this.xuLyHang.Xoa(maHang))
            {
                MessageBox.Show("Thành công");
                hienThiDanhSachHangHoa(dgvHangHoa, xuLyHang.getDanhSachHangHoa());
            }
            else { MessageBox.Show("Thất bại"); }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index>=0&&index < dgvHangHoa.Rows.Count)
            {
         
                string ma = dgvHangHoa.Rows[index].Cells[0].Value.ToString();

                HangHoa hh = xuLyHang.Tim(ma);
                if (hh != null)
                {
                    txtMaHang.Text = hh.MaHang;
                    txtTenHang.Text = hh.TenHang;
                    txtDonVT.Text = hh.DonViTinh;
                    txtDonGia.Text = hh.DonGia.ToString();
                    cboNSX.Text = hh.NhaNS.TenNSX;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string donVT = txtDonVT.Text;
            string donGia = txtDonGia.Text;
            NhaSanXuat nsx = new NhaSanXuat();
            nsx.TenNSX = cboNSX.Text;
            nsx.MaNSX = cboNSX.SelectedValue.ToString();
            HangHoa hh = new HangHoa(maHang, tenHang, donVT, double.Parse(donGia), nsx);
            if (this.xuLyHang.Sua(hh))
            {
                MessageBox.Show("Thành công");
                hienThiDanhSachHangHoa(dgvHangHoa, xuLyHang.getDanhSachHangHoa());
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
