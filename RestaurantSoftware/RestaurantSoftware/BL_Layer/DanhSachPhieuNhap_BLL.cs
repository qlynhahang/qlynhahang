using DevExpress.XtraBars;
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
    public class DanhSachPhieuNhap_BLL
    {
        RestaurantDBDataContext dbContext = null;

        public DanhSachPhieuNhap_BLL()
        {
            dbContext = new RestaurantDBDataContext();
        }
        //public IEnumerable<HoaDonNhapHang> LayDanhSachHoaDonNhapHang()
        //{
        //    IEnumerable<HoaDonNhapHang> query = from hd in dbContext.HoaDonNhapHangs select hd;
        //    return query;
        //}
       
        public void ThemHoaDonNhapHang(HoaDonNhapHang hd)
        {
            dbContext.HoaDonNhapHangs.InsertOnSubmit(hd);
            dbContext.SubmitChanges();
        }
        public void LayDanhSachNhapHang(GridControl  gridView)
        {
            var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
                         from cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
                         from hh in dbContext.GetTable<HangHoa>()
                         where ((hd.id_nhaphang == cthd.id_nhaphang) && (cthd.id_hanghoa == hh.id_hanghoa))
                         select new 
                         {
                             hh.tenhanghoa,
                             hd.thoigian,
                             cthd.soluong,
                             cthd.dongia,
                             hd.thue,
                         });
            gridView.DataSource = query;
        }
        public void LoadDataDanhSachNhapHang(GridControl gridView)
        {
            var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
                         from cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
                         from hh in dbContext.GetTable<HangHoa>()
                         where ((hd.id_nhaphang == cthd.id_nhaphang) && (cthd.id_hanghoa == hh.id_hanghoa))
                         select new
                         {
                             hh.tenhanghoa,
                             hd.thoigian,
                             cthd.soluong,
                             cthd.dongia,
                             hd.thue,
                         });
            gridView.DataSource = query;
        }
        public void TimKiem(string timkiem,GridControl gridView)
        {
            //var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
            //             join cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
            //             on hd.id_nhaphang equals cthd.id_ctnhaphang
            //             join hh in dbContext.GetTable<HangHoa>()
            //             on cthd.id_hanghoa equals hh.id_hanghoa
                        
            //             select new
            //             {
            //                 hh.tenhanghoa,
            //                 hd.thoigian,
            //                 cthd.soluong,
            //                 cthd.dongia,
            //                 hd.thue
            //             });
            var query = (from hd in dbContext.GetTable<HoaDonNhapHang>()
                         from cthd in dbContext.GetTable<Chitiet_HoaDonNhapHang>()
                         from hh in dbContext.GetTable<HangHoa>()
                         where ((hd.id_nhaphang == cthd.id_nhaphang) && (cthd.id_hanghoa == hh.id_hanghoa))
                         select new
                         {
                             hh.tenhanghoa,
                             hd.thoigian,
                             cthd.soluong,
                             cthd.dongia,
                             hd.thue,
                         });
            var search = (from keyword in query
                          where keyword.tenhanghoa.Contains(timkiem)
                          select keyword);
            gridView.DataSource = search;

        }
    }
}
