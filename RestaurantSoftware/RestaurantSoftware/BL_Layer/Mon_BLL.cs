using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    public class Mon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<Mon> LayDanhSachMon()
        {
            IEnumerable<Mon> query = from m in dbContext.Mons select m;
            return query;
        }

        public void ThemMonMoi(Mon mon)
        {

            dbContext.Mons.InsertOnSubmit(mon);
            dbContext.SubmitChanges();
        }

        public void CapNhatMon(Mon m)
        {
            Mon _mon = dbContext.Mons.Single<Mon>(x => x.id_mon == m.id_mon);
            _mon.tenmon = m.tenmon;
            _mon.LoaiMon= dbContext.LoaiMons.Single<LoaiMon>(l => l.id_loaimon == m.id_loaimon);
            _mon.gia = m.gia;
            _mon.tenviettat = m.tenviettat;
            _mon.trangthai = m.trangthai;
            // update 
            dbContext.SubmitChanges();
        }
        public bool KiemTraMonTonTai(int _MaMon, string _TenMon)
        {
            IEnumerable<Mon> query = from m in dbContext.Mons
                                         where m.tenmon == _TenMon || m.id_loaimon == _MaMon
                                         select m;

            return true;
        }
    }
}
