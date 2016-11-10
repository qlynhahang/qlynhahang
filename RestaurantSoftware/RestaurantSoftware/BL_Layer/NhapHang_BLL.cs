using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class NhapHang_BLL
    {
        RestaurantDBDataContext dbContext = null;
        public NhapHang_BLL()
        {
            dbContext = new RestaurantDBDataContext();
        }
        public void LayThongTinHangHoa(GridControl gridcontrol)
        {
            //var query = (from hh in dbContext.GetTable<HangHoa>()
            //             from lhh in dbContext.GetTable<LoaiHangHoa>()
            //             where (hh.id_hanghoa == lhh.id_loaihang)
            //             select new ThongTinHangHoa
            //             {
            //                 Tenhanghoa=hh.tenhanghoa,
            //                 Tenloaihanghoa=lhh.tenloaihang,
            //                 Soluong=(int)hh.soluong
            //             });
            //gridcontrol.DataSource = query;2
            //return query;
            var query = (from hh in dbContext.GetTable<HangHoa>()
                         from lhh in dbContext.GetTable<LoaiHangHoa>()
                         where (hh.id_hanghoa == lhh.id_loaihang)
                         select new
                         {
                             hh.tenhanghoa,
                             lhh.tenloaihang,
                             hh.soluong
                         });
           gridcontrol.DataSource = query;
           
        }
        public IEnumerable<HoaDonNhapHang> LayDanhSachHoaDonNhapHang()
        {
            IEnumerable<HoaDonNhapHang> query = from hd in dbContext.HoaDonNhapHangs select hd;
            return query;
        }
        public void LayDanhSachNguyenLieu(GridControl gridcontrol)
        {
            var query = from hanghoa in dbContext.GetTable<HangHoa>()
                        select hanghoa;
            gridcontrol.DataSource = query;
        }
        public void LayDanhSachPhieuNhap(GridControl grid)
        {

            var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
                         from nv in dbContext.GetTable<NhanVien>()
                         where (hd.id_nhanvien == nv.id_nhanvien)
                         select new
                         {
                             hd.thoigian,
                             nv.tennhanvien
                         });
            grid.DataSource = query;
        }
        public void ThemHoaDonNhapHang(HoaDonNhapHang hd)
        {
            dbContext.HoaDonNhapHangs.InsertOnSubmit(hd);
            dbContext.SubmitChanges();
        }
    }
}
