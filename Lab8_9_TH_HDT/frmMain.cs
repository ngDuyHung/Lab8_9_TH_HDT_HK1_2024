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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            TruyCapDuLieu.docFile("HangHoa.dat");
        }

        private void quảnLýNhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhaSanXuat frmQuanLyNhaSanXuat = new frmQuanLyNhaSanXuat();
            frmQuanLyNhaSanXuat.ShowDialog();
        }

        private void quảnLýHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyHangHoa frmQuanLyHangHoa = new frmQuanLyHangHoa();
            frmQuanLyHangHoa.ShowDialog();
        }

        private void ghiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ketQuaGhiFile= TruyCapDuLieu.ghiFile("HangHoa.dat");   
            if(ketQuaGhiFile==true)
            {
                MessageBox.Show("Ghi file thành công");
            }
            else
            {
                MessageBox.Show("Ghi file thất bại");
            }
        }
    }
}
