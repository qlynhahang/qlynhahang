﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_SuCo : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private SuCo_BLL _sucoBLL = new SuCo_BLL();
        private List<int> _listUpdate = new List<int>();
        FormMain fr = new FormMain();
        string kt = "Them";
        public Frm_SuCo()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            cmb_NhanVienLap.Properties.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().NhanViens;
            // This line of code is generated by Data Source Configuration Wizard
            
        }
          private void Frm_SuCo_Load(object sender, EventArgs e)
        {
            LoadDataSource();
            dt_NgayLap.Text = DateTime.Now.ToShortDateString();
            LoadDsKhachHang();
        }
        private void LoadDataSource()
        {
            _sucoBLL.LayDanhSachSuCo(gridControl1);
            

        }
        public void LoadDsKhachHang()
        {
            DataTable dt = Utils.Utils.ConvertToDataTable<KhachHang>(_sucoBLL.LayDsKhachHang());
            cmb_TenKhachHang.Properties.DataSource = dt;
            cmb_TenKhachHang.Properties.DisplayMember = "tenkh";
            cmb_TenKhachHang.Properties.ValueMember = "id_khachhang";
        }

        private void gv_SuCo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txt_MaSuCo.Text = gv_SuCo.GetFocusedRowCellDisplayText(col_MaSuCo);
            txt_TenSuCo.Text = gv_SuCo.GetFocusedRowCellDisplayText(col_TenSuCo);
            string a = gv_SuCo.GetFocusedRowCellDisplayText(col_NhanVien);
            cmb_NhanVienLap.EditValue = int.Parse(a);
            dt_NgayLap.Text = gv_SuCo.GetFocusedRowCellDisplayText(col_NgayLap);
            rxt_NoiDung.Text = gv_SuCo.GetFocusedRowCellDisplayText(col_NoiDung);
            string b = gv_SuCo.GetFocusedRowCellDisplayText(col_KhachHang);
            cmb_TenKhachHang.EditValue = int.Parse(b);
            kt = "Sua";
        }

      

        private void cmb_TenKhachHang_EditValueChanged_1(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            txt_SoDienThoai.Text = row["sdt"].ToString();
            txt_DiaChi.Text = row["diachi"].ToString();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (kt == "Them")
            {
                SuCo qd = new SuCo();
                qd.tensuco = txt_TenSuCo.Text;
                qd.id_nhanvien = (int)cmb_NhanVienLap.EditValue;
                qd.ngaylap = dt_NgayLap.DateTime;
                qd.noidung = rxt_NoiDung.Text;
                _sucoBLL.ThemSuCo(qd);
                Notifications.Answers("Thêm thành công!");
                LoadDataSource();


            }
            else
                if (kt == "Sua")
                {
                    SuCo qd = new SuCo();
                    qd.id_suco = int.Parse(txt_MaSuCo.Text);
                    qd.tensuco = txt_TenSuCo.Text;
                    qd.id_nhanvien = (int)cmb_NhanVienLap.EditValue;
                    qd.ngaylap = dt_NgayLap.DateTime;
                    qd.noidung = rxt_NoiDung.Text;
                    _sucoBLL.CapNhatSuCo(qd);
                    Notifications.Answers("Sửa thành công!");


                }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            _sucoBLL.XoaSuCo(int.Parse(txt_MaSuCo.Text));
            Notifications.Answers("Xóa thành công!");
            btn_LamMoi_Click(sender, e);
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaSuCo.Text = "";
            txt_TenSuCo.Text = "";
            dt_NgayLap.Text = DateTime.Now.ToShortDateString();
            rxt_NoiDung.Text = "";
            kt = "Them";
            LoadDataSource();
        }

        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {

        }

      
    }
}