using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDeTai.DAL;
using QLDeTai.ViewModel;
namespace QLDeTai.BLL
{
    internal class MonHocBLL
    {
        public static List<MonHoc> GetList()
        {
            QLDeTaiModel model = new QLDeTaiModel();
            var ls = model.MonHocs.ToList();//select* from LopHoc
            return ls;

        }

        public static List<MonHocViewModel> GetListViewModel()
        {
            QLDeTaiModel model = new QLDeTaiModel();
            var ls = model.MonHocs.Select(e => new MonHocViewModel
            {
                ID = e.ID,
                Name = e.Name,
                TotalDeTai = e.DeTais.Count,
            }).ToList();
            return ls;
        }

        public static bool Delete(long idMonhoc)
        {
            QLDeTaiModel model = new QLDeTaiModel();
            var lopHoc = model.MonHocs.Where(e => e.ID == idMonhoc).FirstOrDefault();
            if (lopHoc.DeTais.Count == 0)
            {
                model.MonHocs.Remove(lopHoc);
                model.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
