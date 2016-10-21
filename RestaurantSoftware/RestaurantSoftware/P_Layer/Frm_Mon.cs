using System;
using System.Collections.Generic;
using System.ComponentModel;
using RestaurantSoftware.BL_Layer;
using RestaurantSoftware.DA_Layer;
using RestaurantSoftware.P_Layer;
using RestaurantSoftware.Utils;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_Mon : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private Mon_BLL _monBll = new Mon_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_Mon()
        {
            InitializeComponent();
        }


        private void Frm_Mon_Load(object sender, EventArgs e)
        {
            LoadDataSource();

        }
        private void LoadDataSource()
        {
            gridControl1.DataSource = dt;

        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                gridView1.AddNewRow();
                gridView1.MoveLastVisible();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
                gridView1.ShowEditor();
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (int id in _listUpdate)
            {
                ThucDon Mon = new ThucDon();
                Mon.id_mon = gridView1.GetRowCellValue(id, "id_mon").ToString();
                Mon.id_loaimon = gridView1.GetRowCellValue(id, "id_loaimon").ToString();
                Mon.tenmon = gridView1.GetRowCellValue(id, "tenmon").ToString();
                Mon.tenviettat = gridView1.GetRowCellValue(id, "tenviettat").ToString();
                Mon.gia =decimal.Parse(gridView1.GetRowCellValue(id, "gia").ToString());
                Mon.trangthai = gridView1.GetRowCellValue(id, "trangthai").ToString();
                _monBll.CapNhatMon(Mon);
            }

        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.PostEditor();
                gridView1.UpdateCurrentRow();
                gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btn_Luu.Enabled = true;
            _listUpdate.Add(e.RowHandle);
        }

    }
}