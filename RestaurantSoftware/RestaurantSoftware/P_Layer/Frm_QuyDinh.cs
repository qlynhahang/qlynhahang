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
using RestaurantSoftware.Untils;
using RestaurantSoftware.DA_Layer;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_QuyDinh : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private QuyDinh_BLL _quydinhBll = new QuyDinh_BLL();
        public Frm_QuyDinh()
        {
            InitializeComponent();
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            dt = Utils.ConvertToDataTable<QuyDinh>(_quydinhBll.LayDanhSachMon());
            grd_QuyDinh.DataSource = dt;

        }
    }
}