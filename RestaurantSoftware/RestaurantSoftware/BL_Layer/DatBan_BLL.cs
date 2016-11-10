using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class DatBan_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<Ban> LayDanhSachBan(DateTime ngaydat)
        {
            var query = from ban in dbContext.Bans
                        where
                          !
                            (from DatBans in dbContext.DatBans
                             where
                               DatBans.thoigian == ngaydat.Date
                             select new
                             {
                                 DatBans.id_ban
                             }).Contains(new { id_ban = (System.Int32?)ban.id_ban })
                        select ban;
            return query;
        }


        public void LayDanhSachMon(GridControl grid)
        {
            var query = from
                            m in dbContext.Mons
                        join
                            lm in dbContext.LoaiMons
                        on
                        m.id_loaimon equals lm.id_loaimon
                        select new
                        {
                            tenmon = m.tenmon,
                            tenviettat = m.tenviettat,
                            gia = m.gia,
                            tenloaimon = lm.tenloaimon
                                
                        };
                       
            grid.DataSource = query;
        }

        public void LayDsDatBan(GridControl grid)
        {
            var query = from db in dbContext.DatBans
                        select new
                        {
                            db.id_datban,
                            db.Ban.tenban,
                            db.trangthai,
                            db.thoigian,
                            db.NhanVien.tennhanvien,
                            db.KhachHang.tenkh,
                            db.KhachHang.sdt
                        };
            grid.DataSource = query;
        }
        public IEnumerable<KhachHang> LayDsKhachHang()
        {
            var query = from kh in dbContext.KhachHangs select kh;
            return query;
        }

        public void ThemMoiPhieuDatBan(DatBan db)
        {
            dbContext.DatBans.InsertOnSubmit(db);
            dbContext.SubmitChanges();
        }
    }
}
