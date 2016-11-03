﻿using System;
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
            // This line of code is generated by Data Source Configuration Wizard
            lue_LoaiMon.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().LoaiMons;
            // This line of code is generated by Data Source Configuration Wizard
            lue_TrangThai.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().TrangThais;
        }


        private void Frm_Mon_Load(object sender, EventArgs e)
        {
            LoadDataSource();

        }
        private void LoadDataSource()
        {

            dt = Utils.Utils.ConvertToDataTable<Mon>(_monBll.LayDanhSachMon());
            gridControl1.DataSource = dt;

        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
            gridView1.SelectRow(gridView1.FocusedRowHandle);
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            gridView1.ShowEditor();
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (int id in _listUpdate)
            {
                Mon Mon = new Mon();
                Mon.id_mon = int.Parse(gridView1.GetRowCellValue(id, "id_mon").ToString());
                Mon.id_loaimon = int.Parse(gridView1.GetRowCellValue(id, "id_loaimon").ToString());
                Mon.tenmon = gridView1.GetRowCellValue(id, "tenmon").ToString();
                Mon.tenviettat = gridView1.GetRowCellValue(id, "tenviettat").ToString();
                Mon.gia =decimal.Parse(gridView1.GetRowCellValue(id, "gia").ToString());
                Mon.trangthai = gridView1.GetRowCellValue(id, "trangthai").ToString();
                _monBll.CapNhatMon(Mon);
            }

            Notifications.Success("Lưu dữ liệu thành công!");

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

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Notifications.Answers("Bạn thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for(int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_Mon = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "id_mon").ToString());
                _monBll.XoaMon(_ID_Mon);
            }
            Notifications.Success("Xóa dữ liệu thành công!");
            LoadDataSource();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btn_Xoa.Enabled = false;
            if(gridView1.SelectedRowsCount > 0)
            {
                btn_Xoa.Enabled = true;
            }
        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách loại phòng";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                    gridView1.ExportToPdf(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 2)
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 3)
                    gridControl1.ExportToRtf(saveFileDialog1.FileName);
            }
        }

    }
}