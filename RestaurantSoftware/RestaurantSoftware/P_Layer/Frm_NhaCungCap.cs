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
using DevExpress.XtraGrid;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_NhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        private NhaCungCap_BLL _nccBll = new NhaCungCap_BLL();
        private List<int> _listUpdate = new List<int>();
        public Frm_NhaCungCap()
        {
            InitializeComponent();
        }

        private void Frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            dt = RestaurantSoftware.Utils.Utils.ConvertToDataTable<NhaCungCap>(_nccBll.LayDanhSachNhaCungCap());
            gridControl1.DataSource = dt;
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.AddNewRow();
            gridView1.MoveLastVisible();
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btn_Luu.Enabled = true;
            _listUpdate.Add(e.RowHandle);
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach(int id in _listUpdate){
                NhaCungCap NhaCungCap = new NhaCungCap();
                NhaCungCap.id_nhacungcap = int.Parse(gridView1.GetRowCellValue(id, "id_nhacungcap").ToString());
                NhaCungCap.tennhacungcap = gridView1.GetRowCellValue(id, "tennhacungcap").ToString();
                NhaCungCap.sdt = gridView1.GetRowCellValue(id, "sdt").ToString();
                NhaCungCap.diachi = gridView1.GetRowCellValue(id, "diachi").ToString();
                NhaCungCap.ghichu = gridView1.GetRowCellValue(id, "ghichu").ToString();
                _nccBll.CapNhatNhaCungCap(NhaCungCap);
            }
            MessageBox.Show("Bạn thêm nhà cung cấp thành công!");
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

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _nccBll.TimKiem(txtTimKiem.EditValue.ToString(), gridControl1);
        }


    }
}