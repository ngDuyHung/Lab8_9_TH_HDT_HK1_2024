using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_9_TH_HDT
{
    [Serializable]
    internal class TruyCapDuLieu
    {
        private static TruyCapDuLieu instance=null;
        private List<NhaSanXuat> dsNhaSanXuat;
        private List<HangHoa> dsHangHoa;
        private TruyCapDuLieu()
        {
            dsNhaSanXuat = new List<NhaSanXuat>();
            dsHangHoa = new List<HangHoa>();
        }

        public static TruyCapDuLieu KhoiTao()
        {
            if (instance == null)
            {
                instance = new TruyCapDuLieu();
            }
            return instance;
        }

        public List<HangHoa> getDanhSachHangHoa()
        {
            return dsHangHoa;
        }

        public List<NhaSanXuat> getDanhSachNhaSanXuat()
        {
            return dsNhaSanXuat;
        }

        public static bool docFile(string tenFile)
        {
            try
            {
                using (FileStream fs = new FileStream(tenFile, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    instance = (TruyCapDuLieu)bf.Deserialize(fs);
                    
                }
                return true;
            }catch(Exception err)
            {
                return false;
            }
           
        }

        public static bool ghiFile(string tenFile)
        {
            try
            {
                FileStream fs=new FileStream(tenFile,FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, instance);
                fs.Close();
                return true;
            }catch(Exception err)
            {
                throw err;
            }
        }


    }
}
