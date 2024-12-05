using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_9_TH_HDT
{
    [Serializable]
    internal class NhaSanXuat
    {
        private string maNSX;
        private string tenNSX;
        private string dienThoai;
        private string diaChi;

        public NhaSanXuat()
        {
            this.maNSX = "";
            this.tenNSX = "";
            this.dienThoai = "";
            this.diaChi = "";
        }
        public NhaSanXuat(string maNSX, string tenNSX, string dienThoai, string diaChi)
        {
            this.maNSX = maNSX;
            this.tenNSX = tenNSX;
            this.dienThoai = dienThoai;
            this.diaChi = diaChi;
        }

        public string MaNSX { get => maNSX; set => maNSX = value; }
        public string TenNSX { get => tenNSX; set => tenNSX = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }


    }
}
