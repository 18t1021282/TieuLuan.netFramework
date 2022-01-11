using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDeTai.DAL;

namespace QLDeTai.BLL
{
    internal class DeTaiBLL
    {
        public static List<DeTai> GetList(long maMon)
        {
            QLDeTaiModel model = new QLDeTaiModel();
            var ls = model.DeTais.Where(e => e.IDMonHoc == maMon).ToList();//select* from SinhVien where IDLopHoc=maLop
            return ls;

        }

        public static int Count(long maMon)
        {
            //dếm trong DB
            QLDeTaiModel model = new QLDeTaiModel();
            var d = model.DeTais.Where(e => e.IDMonHoc == maMon).Count();
            return d;
            //return 0; lấy dl ra r đêm
        }

        public static void Delete(long id)
        {
            QLDeTaiModel model = new QLDeTaiModel();
            var deTai = model.DeTais.Where(e => e.ID == id).FirstOrDefault();

            model.DeTais.Remove(deTai);
            model.SaveChanges();
            return;
        }
    }
}
