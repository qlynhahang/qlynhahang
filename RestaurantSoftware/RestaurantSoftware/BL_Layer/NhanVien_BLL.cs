﻿using RestaurantSoftware.DA_Layer;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSoftware.BL_Layer
{
    class NhanVien_BLL
    {
        RestaurantDBDataContext dbContext = new RestaurantDBDataContext();
        public IEnumerable<NhanVien> LayDanhSachNhanVien()
        {
            IEnumerable<NhanVien> query = from nv in dbContext.NhanViens select nv;
            return query;
        }

        public void ThemNhanVien(NhanVien NhanVien)
        {

            dbContext.NhanViens.InsertOnSubmit(NhanVien);
            dbContext.SubmitChanges();
        }

        public void CapNhatNhanVien(NhanVien nv)
        {
            NhanVien _NhanVien = dbContext.NhanViens.Single<NhanVien>(x => x.id_nhanvien == nv.id_nhanvien);
            _NhanVien.id_nhanvien = nv.id_nhanvien;
            _NhanVien.tendangnhap = nv.tendangnhap;
            _NhanVien.matkhau = nv.matkhau;
            _NhanVien.id_quyen = nv.id_quyen;
            // update 
            dbContext.SubmitChanges();
        }

        public void XoaNhanVien(int _NhanVienID)
        {
            NhanVien _NhanVien = dbContext.NhanViens.Single<NhanVien>(x => x.id_nhanvien == _NhanVienID);
            dbContext.SubmitChanges();
        }
    }
}
