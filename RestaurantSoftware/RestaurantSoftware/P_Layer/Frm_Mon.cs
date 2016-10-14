using System;
using System.Collections.Generic;
using System.ComponentModel;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Untils;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_Mon : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private Mon_BLL _monBll = new Mon_BLL();
        public Frm_Mon()
        {
            InitializeComponent();
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            dt = Utils.ConvertToDataTable<ThucDon>(_monBll.LayDanhSachMon());
            gridControl1.DataSource = dt;

        }
    }
}