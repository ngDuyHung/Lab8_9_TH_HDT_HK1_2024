using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_9_TH_HDT
{
    [Serializable]
    internal class XuLyNhaSanXuat
    {
        private List<NhaSanXuat> dsNhaSanXuat;

        public XuLyNhaSanXuat()
        {
            TruyCapDuLieu duLieu = TruyCapDuLieu.KhoiTao();
            this.dsNhaSanXuat = duLieu.getDanhSachNhaSanXuat();
        }

        public List<NhaSanXuat> getDanhSachNhaSanXuat()
        {
            return this.dsNhaSanXuat;
        }

        public NhaSanXuat Tim(string maNSX)
        {
            foreach (NhaSanXuat nsx in dsNhaSanXuat)
            {
                if (nsx.MaNSX.Equals(maNSX))
                {
                    return nsx;
                }
            }
            return null;
        }

        public bool Them(NhaSanXuat nhaSanXuat)
        {
            if (Tim(nhaSanXuat.MaNSX) != null)
            {
                return false;
            }
            this.dsNhaSanXuat.Add(nhaSanXuat);
            return true;
        }

        public bool Xoa(string maNSX)
        {
            if (Tim(maNSX) != null)
            {
                this.dsNhaSanXuat.Remove(Tim(maNSX));
                return true;
            }
            return false;
        }

        public bool Sua(NhaSanXuat nhaSanXuat)
        {
            NhaSanXuat nsx = Tim(nhaSanXuat.MaNSX);
            if (nsx != null)
            {
                nsx.TenNSX = nhaSanXuat.TenNSX;
                nsx.DienThoai = nhaSanXuat.DienThoai;
                nsx.DiaChi = nhaSanXuat.DiaChi;
                return true;
            }
            return false;
        }

        
    }
}
