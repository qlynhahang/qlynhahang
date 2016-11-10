using DevExpress.XtraGrid;
using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class QuyDinh_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public void LayDanhSachQuyDinh(GridControl grid)
        {
            var query = from db in dbContext.QuyDinhs
                        select new
                        {
                            db.id_quydinh,
                            db.tenquydinh,
                            db.id_nhanvien,
                            db.ngaylap,
                            db.noidung
                        };
            grid.DataSource = query;
        }
    }
}
