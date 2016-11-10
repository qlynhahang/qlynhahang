using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class Ban_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<Ban> LayDanhBan()
        {
            IEnumerable<Ban> query = from m in dbContext.Bans select m;
            return query;
        }
    }
}
