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

        public void ThemMonMoi(ThucDon _mon)
        {
            dbContext.ThucDons.InsertOnSubmit(_mon);
            dbContext.SubmitChanges();
        }

       }
}
