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
    
    public partial class Frm_QuyDinh : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private QuyDinh_BLL _quydinhBLL = new QuyDinh_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_QuyDinh()
        {
            InitializeComponent();
        }
        private void LoadDataSource()
        {
            _quydinhBLL.LayDanhSachQuyDinh(grd_QuyDinh);

        }

        private void Frm_QuyDinh_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
    }
}