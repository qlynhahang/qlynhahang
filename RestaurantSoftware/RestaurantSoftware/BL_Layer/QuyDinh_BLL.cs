﻿using DevExpress.XtraEditors;
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
        public void ThemQuyDinh(QuyDinh quydinh)
        {
            dbContext.QuyDinhs.InsertOnSubmit(quydinh);
            dbContext.SubmitChanges();
        }
        public void CapNhatQuyDinh(QuyDinh m)
        {
            QuyDinh _qd = dbContext.QuyDinhs.Single<QuyDinh>(x => x.id_quydinh == m.id_quydinh);
            _qd.tenquydinh = m.tenquydinh;
            _qd.NhanVien = dbContext.NhanViens.Single<NhanVien>(l => l.id_nhanvien == m.id_nhanvien);
            _qd.ngaylap = m.ngaylap;
            _qd.noidung  = m.noidung;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaQuyDinh(int _IDQuyDinh)
        {
            QuyDinh _QuyDinh = dbContext.QuyDinhs.Single<QuyDinh>(x => x.id_quydinh == _IDQuyDinh);
            dbContext.QuyDinhs.DeleteOnSubmit(_QuyDinh);

            dbContext.SubmitChanges();
        }
       
    }
}
