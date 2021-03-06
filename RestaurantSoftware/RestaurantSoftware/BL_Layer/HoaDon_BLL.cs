﻿using RestaurantSoftware.DA_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSoftware.BL_Layer
{
    class HoaDon_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();

        public IEnumerable<HoaDonThanhToan> LayDanhHoaDon()
        {
            IEnumerable<HoaDonThanhToan> query = from m in dbContext.HoaDonThanhToans select m;
            return query;
        }
    }
}
