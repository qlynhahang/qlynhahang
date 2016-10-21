using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    public class Mon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<ThucDon> LayDanhSachMon()
        {
            IEnumerable<ThucDon> query = from m in dbContext.ThucDons select m;
            return query;
        }

        public void ThemMonMoi(ThucDon mon)
        {

            dbContext.ThucDons.InsertOnSubmit(mon);
            dbContext.SubmitChanges();
        }

        public void CapNhatMon(ThucDon m)
        {
            ThucDon _mon = dbContext.ThucDons.Single<ThucDon>(x => x.id_mon == m.id_mon);
            _mon.tenmon = m.tenmon;
            _mon.LoaiMon= dbContext.LoaiMons.Single<LoaiMon>(l => l.id_loaimon == m.id_loaimon);
            _mon.gia = m.gia;
            _mon.tenviettat = m.tenviettat;
            _mon.trangthai = m.trangthai;
            // update 
            dbContext.SubmitChanges();
        }
        public bool KiemTraMonTonTai(string _MaMon, string _TenMon)
        {
            IEnumerable<ThucDon> query = from m in dbContext.ThucDons
                                         where m.tenmon == _TenMon || m.id_loaimon == _MaMon
                                         select m;

            return true;
        }
    }
}
