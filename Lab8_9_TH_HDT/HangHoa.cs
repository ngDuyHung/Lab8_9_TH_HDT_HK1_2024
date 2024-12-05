using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_9_TH_HDT
{
    [Serializable]
    internal class HangHoa
    {
        private string maHang;
        private string tenHang;
        private string donViTinh;
        private double donGia;
        private NhaSanXuat nhaNS;

        public HangHoa()
        {
            this.maHang = "";
            this.tenHang = "";
            this.donViTinh = "";
            this.donGia = 0;
            this.nhaNS = new NhaSanXuat();
        }
        public HangHoa(string maHang, string tenHang, string donViTinh, double donGia, NhaSanXuat nhaNS)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.donViTinh = donViTinh;
            this.donGia = donGia;
            this.nhaNS = nhaNS;
        }
        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public NhaSanXuat NhaNS { get => nhaNS; set => nhaNS = value; }
        
    }
}
