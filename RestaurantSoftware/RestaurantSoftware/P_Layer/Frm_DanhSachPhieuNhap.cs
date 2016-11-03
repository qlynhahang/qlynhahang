using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DanhSachPhieuNhap : Form
    {
        DataTable dt = null;
        private DanhSachPhieuNhap_BLL _dsHDBLL;
        public Frm_DanhSachPhieuNhap()
        {
            InitializeComponent();
            _dsHDBLL = new DanhSachPhieuNhap_BLL();
            LoadDanhSachPhieuNhap();
        }
        void LoadDanhSachPhieuNhap()
        {
            _dsHDBLL.LoadDataDanhSachNhapHang(gridControl1);
            
        }
        private void Frm_DanhSachPhieuNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _dsHDBLL.TimKiem(txtTimKiem.EditValue.ToString(), gridControl1);
        }
    }
}
