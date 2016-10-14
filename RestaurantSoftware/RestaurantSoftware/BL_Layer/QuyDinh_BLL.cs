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

        public IEnumerable<QuyDinh> LayDanhSachMon()
        {
            IEnumerable<QuyDinh> query = from m in dbContext.QuyDinhs select m;
            return query;
        }

        public void ThemMonMoi(QuyDinh _quydinh)
        {
            dbContext.QuyDinhs.InsertOnSubmit(_quydinh);
            dbContext.SubmitChanges();
        }

    }
}
