using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_9_TH_HDT
{
    [Serializable]
    internal class XuLyHangHoa
    {
        private List<HangHoa> dsHangHoa;
        private List<NhaSanXuat> dsNhaSanXuat;
        public XuLyHangHoa()
        {
            dsHangHoa= new List<HangHoa>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.KhoiTao();
            this.dsHangHoa = duLieu.getDanhSachHangHoa();
            this.dsNhaSanXuat=duLieu.getDanhSachNhaSanXuat();
        }

        public List<HangHoa> getDanhSachHangHoa()
        {
            return dsHangHoa;
        }

        public List<NhaSanXuat> getDanhSachNhaSanXuat()
        {
            return this.dsNhaSanXuat;
        }


        public bool Them(HangHoa hangHoa)
        {
            if(Tim(hangHoa.MaHang) != null)
            {
                return false;
            }
            this.dsHangHoa.Add(hangHoa);
            return true;
        }

        public bool Xoa(string maHang)
        {
           if (Tim(maHang) != null)
            {
                this.dsHangHoa.Remove(Tim(maHang));
                return true;
            }
            return false;
        }   

        public bool Sua(HangHoa hangHoa)
        {
            HangHoa hangHoaTim= Tim(hangHoa.MaHang);
            if (hangHoaTim != null)
            {
                hangHoaTim.TenHang = hangHoa.TenHang;
                hangHoaTim.DonViTinh = hangHoa.DonViTinh;
                hangHoaTim.DonGia = hangHoa.DonGia;
                hangHoaTim.NhaNS = hangHoa.NhaNS;
                return true;
            }
            return false;
        }

        public HangHoa Tim(string maHang)
        {

            foreach(HangHoa hangHoa in dsHangHoa)
            {
                if (hangHoa.MaHang.Equals(maHang))
                {
                    return hangHoa;
                }
            }
            return null;    
        }
    }
}
