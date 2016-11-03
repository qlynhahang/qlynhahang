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

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private Ban_BLL _banBll = new Ban_BLL();
        private HoaDon_BLL _hoadonBll = new HoaDon_BLL();
        private List<int> _listUpdate = new List<int>();


        public Frm_ThanhToan()
        {
            InitializeComponent();
        }


        private void Frm_ThanhToan_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            dt = Utils.Utils.ConvertToDataTable<Ban>(_banBll.LayDanhBan());
            grd_Ban.DataSource = dt;

        }
    }
}