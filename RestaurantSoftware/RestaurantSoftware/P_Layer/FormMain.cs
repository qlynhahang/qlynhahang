using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;

namespace RestaurantSoftware
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            InitSkinGallery();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(ribbonGallery, true);
        }

        private void btn_Ban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_Ban Ban = new P_Layer.Frm_Ban();
            Ban.MdiParent = this;
            Ban.Show();
        }

        private void btn_KhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btn_Mon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_Mon Mon = new P_Layer.Frm_Mon();
            Mon.MdiParent = this;
            Mon.Show();
        }

        private void btn_LoaiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_LoaiMon LoaiMon = new P_Layer.Frm_LoaiMon();
            LoaiMon.MdiParent = this;
            LoaiMon.Show();
        }

        private void btn_KhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_KhachHang KhachHang = new P_Layer.Frm_KhachHang();
            KhachHang.MdiParent= this;
            KhachHang.Show();
        }
        public void Button_KhachHang(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_KhachHang_ItemClick(sender,e);
        }
        private void btn_NguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_NguoiDung NhanVien = new P_Layer.Frm_NguoiDung();
            NhanVien.MdiParent = this;
            NhanVien.Show();
        }

        private void btn_QuyDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_QuyDinh QuyDinh = new P_Layer.Frm_QuyDinh();
            QuyDinh.MdiParent = this;
            QuyDinh.Show();
        }

        private void btn_PhieuNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_DanhSachPhieuNhap DSPhieuNhap = new P_Layer.Frm_DanhSachPhieuNhap();
            DSPhieuNhap.MdiParent = this;
            DSPhieuNhap.Show();
        }

        private void btn_NhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_NhaCungCap NhaCungCap = new P_Layer.Frm_NhaCungCap();
            NhaCungCap.MdiParent = this;
            NhaCungCap.Show();
        }

        private void btn_PhucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_PhucVu PhucVu = new P_Layer.Frm_PhucVu();
            PhucVu.MdiParent = this;
            PhucVu.Show();
        }

        private void btn_DatBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_DatBan DatBan = new P_Layer.Frm_DatBan();
            DatBan.MdiParent = this;
            DatBan.Show();
        }

        private void btn_ThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_ThanhToan ThanhToan = new P_Layer.Frm_ThanhToan();
            ThanhToan.MdiParent = this;
            ThanhToan.Show();
        }

        private void btn_NhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_QuanLyNhapHang QuanLyNhapHang = new P_Layer.Frm_QuanLyNhapHang();
            QuanLyNhapHang.MdiParent = this;
            QuanLyNhapHang.Show();
        }

        private void btn_SuCo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_SuCo SuCo = new P_Layer.Frm_SuCo();
            SuCo.MdiParent = this;
            SuCo.Show();
        }

        private void btn_LoaiSuCo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_LoaiSuCo LoaiSuCo = new P_Layer.Frm_LoaiSuCo();
            LoaiSuCo.MdiParent = this;
            LoaiSuCo.Show();
        }

        private void btn_LoaiQuyDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            P_Layer.Frm_LoaiQuyDinh LoaiQuyDinh = new P_Layer.Frm_LoaiQuyDinh();
            LoaiQuyDinh.MdiParent = this;
            LoaiQuyDinh.Show();
        }
    }
}
