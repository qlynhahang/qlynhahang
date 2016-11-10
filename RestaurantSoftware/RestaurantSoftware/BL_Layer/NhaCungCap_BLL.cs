using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    public class NhaCungCap_BLL
    {
        RestaurantDBDataContext dbContext = null;
        public NhaCungCap_BLL()
        {
            dbContext = new RestaurantDBDataContext();
        }
        public IEnumerable<NhaCungCap> LayDanhSachNhaCungCap()
        {
            IEnumerable<NhaCungCap> query = from ncc in dbContext.NhaCungCaps select ncc;
            return query;
        }
        public void ThemNhaCungCapMoi(NhaCungCap ncc)
        {
            dbContext.NhaCungCaps.InsertOnSubmit(ncc);
            dbContext.SubmitChanges();
        }
        public void CapNhatNhaCungCap(NhaCungCap ncc){

            NhaCungCap _nhacungcap = dbContext.NhaCungCaps.Single<NhaCungCap>(x=>x.id_nhacungcap==ncc.id_nhacungcap);
            _nhacungcap.tennhacungcap = ncc.tennhacungcap;
            _nhacungcap.sdt = ncc.sdt;
            _nhacungcap.diachi = ncc.diachi;
            _nhacungcap.ghichu = ncc.ghichu;
            // update
            dbContext.SubmitChanges();
        }
        public bool KiemTraNhaCungCapTonTai(int _MaNhaCungCap, string _TenNhanCungCap)
        {
            IEnumerable<NhaCungCap> query = from ncc in dbContext.NhaCungCaps
                                            where ncc.tennhacungcap == _TenNhanCungCap || ncc.id_nhacungcap == _MaNhaCungCap
                                            select ncc;
            return true;
        }
        public void TimKiem(string timkiem, GridControl gridview)
        {
            IEnumerable<NhaCungCap> query = from ncc in dbContext.NhaCungCaps
                                            where ncc.tennhacungcap.Contains(timkiem) || ncc.diachi.Contains(timkiem)
                                            select ncc;
            gridview.DataSource = query;
        }

    }
}
