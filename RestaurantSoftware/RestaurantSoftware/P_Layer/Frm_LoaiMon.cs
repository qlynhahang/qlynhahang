using System;
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
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Utils;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_LoaiMon : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private LoaiMon_BLL lm_Bll = new LoaiMon_BLL();
        public Frm_LoaiMon()
        {
            InitializeComponent();
        }

        private void Frm_LoaiMon_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void LoadDataSource()
        {

            dt = Utils.Utils.ConvertToDataTable<LoaiMon>(lm_Bll.LayDanhSachLoaiMon());
            gridControl1.DataSource = dt;

        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}