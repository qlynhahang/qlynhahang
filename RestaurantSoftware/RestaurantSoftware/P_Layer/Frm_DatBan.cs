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
using RestaurantSoftware.Utils;
using RestaurantSoftware.DA_Layer;

namespace RestaurantSoftware.P_Layer
{
    public partial class Frm_DatBan : DevExpress.XtraEditors.XtraForm
    {
        DatBan_BLL datban_bll = new DatBan_BLL();
        bool checkClickRow = false;

        public Frm_DatBan()
        {
            InitializeComponent();
            dtNgayDat.DateTime = DateTime.Now;

        }
        public void LoadDsBan()
        {
            lvDsBan.Clear();
            DataTable ban = Utils.Utils.ConvertToDataTable<Ban>(datban_bll.LayDanhSachBan(dtNgayDat.DateTime));

            lvDsBan.LargeImageList = imageList1;

            foreach (DataRow dr in ban.Rows)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr["tenban"].ToString();
                switch (dr["trangthai"].ToString())
                {
                    case "trống":
                        lvItem.ImageIndex = 2;
                        break;
                    case "đặt trước":
                        lvItem.ImageIndex = 1;
                        break;
                    case "đầy":
                        lvItem.ImageIndex = 0;
                        break;
                }
                lvItem.Name = dr["id_ban"].ToString();
                lvGroup.Header = ((LoaiBan)dr[6]).tenloaiban;
                lvItem.Group = lvGroup;

                if (lvDsBan.Groups.Count != 0)
                {
                    foreach (ListViewGroup gr in lvDsBan.Groups)
                    {
                        if (gr.Header == lvGroup.Header)
                        {
                            exsistGroup = true;
                            lvItem.Group = gr;
                            break;
                        }
                    }
                    if (exsistGroup == false)
                    {
                        lvDsBan.Groups.Add(lvGroup);
                    }

                }
                else lvDsBan.Groups.Add(lvGroup);
                lvDsBan.Items.Add(lvItem);

            }
        }
        public void LoadDsDatBan()
        {
            datban_bll.LayDsDatBan(gridControl_DsDatBan);
        }

        public void LoadDsMon()
        {

            datban_bll.LayDanhSachMon(gridControl_DsMon); ;

        }
        public void LoadDsKhachHang()
        {
            DataTable dt = Utils.Utils.ConvertToDataTable<KhachHang>(datban_bll.LayDsKhachHang());
            cbxKhachHang.Properties.DataSource = dt;
            cbxKhachHang.Properties.DisplayMember = "tenkh";
            cbxKhachHang.Properties.ValueMember = "id_khachhang";
        }
        public void LoadChiTietDatBan()
        {
            
            datban_bll.LoadChiTietDatBan(txtBan.Text, dtNgayDat.DateTime, gridControl_ChiTietDatBan);
        }
        private void Frm_DatBan_Load(object sender, EventArgs e)
        {
            LoadDsBan();
            LoadDsMon();
            LoadDsDatBan();
            LoadDsKhachHang();
            LoadChiTietDatBan();
        }

        private void btn_ThemMon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView_DsDatBan.GetRowCellValue(gridView_DsDatBan.FocusedRowHandle, "id_datban") != null)
                {
                    Chitiet_DatBan ct_datban = new Chitiet_DatBan();
                    ct_datban.id_datban = int.Parse(gridView_DsDatBan.GetRowCellValue(gridView_DsDatBan.FocusedRowHandle, "id_datban").ToString());

                    if (gridView_DsMon.EditingValue == null)
                    {
                        ct_datban.soluong = 1;
                    }
                    else
                        ct_datban.soluong = int.Parse(gridView_DsMon.EditingValue.ToString());

                    ct_datban.dongia = decimal.Parse(gridView_DsMon.GetFocusedRowCellValue(gia).ToString());
                    ct_datban.thanhtien = ct_datban.soluong * ct_datban.dongia;
                    ct_datban.id_mon = int.Parse(gridView_DsMon.GetFocusedRowCellValue(id_mon).ToString());
                    if (datban_bll.KiemTraMonDaCoChua(ct_datban.id_datban, ct_datban.id_mon) > 0)
                    {
                        //update
                        datban_bll.CapNhatChiTiet(ct_datban);
                        MessageBox.Show("Thêm món thành công");
                    }
                    else
                    {
                        //add new
                        datban_bll.ThemChiTiet(ct_datban);
                        MessageBox.Show("Thêm món mới thành công");
                    }
                    LoadChiTietDatBan();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtNgayDat_EditValueChanged(object sender, EventArgs e)
        {
            txtBan.Text = "";
            LoadDsBan();
            LoadChiTietDatBan();
            
        }

        private void lvDsBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDsBan.SelectedItems.Count > 0)
            {
                txtBan.Text = lvDsBan.SelectedItems[0].Text;
            }


        }

        private void lvDsBan_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }

        private void cbxKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            txtSDT.Text = row["sdt"].ToString();
            txtDiaChi.Text = row["diachi"].ToString();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            DatBan db = new DatBan();
            if (lvDsBan.SelectedItems.Count > 0)
            {
                db.id_ban = Convert.ToInt16(lvDsBan.SelectedItems[0].Name);
            }
            else
            {
                MessageBox.Show("Xin chọn Bàn");
                return;
            }

            db.id_khachhang = (int)cbxKhachHang.EditValue;
            db.id_nhanvien = 1;
            db.thoigian = dtNgayDat.DateTime.Date;
            db.trangthai = "";
            datban_bll.ThemMoiPhieuDatBan(db);
            MessageBox.Show("Thêm phiếu đặt thành công");
            LoadDsBan();
            LoadDsDatBan();
        }

        private void gridView_DsDatBan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            dtNgayDat.DateTime = (DateTime)gridView_DsDatBan.GetRowCellValue(e.RowHandle, "thoigian");
            txtBan.Text = gridView_DsDatBan.GetRowCellValue(e.RowHandle, "tenban").ToString();
            cbxKhachHang.Properties.ValueMember = "tenkh";
            cbxKhachHang.EditValue = gridView_DsDatBan.GetRowCellValue(e.RowHandle, "tenkh").ToString();
            cbxKhachHang.Properties.ValueMember = "id_khachhang";
            checkClickRow = true;
        }

        private void txtBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadChiTietDatBan();
        }

        private void btn_Xoachitiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_datban) != null 
                    && gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_mon)!=null)
                {
                    int iddb = int.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_datban).ToString());
                    int idm = int.Parse(gridView_ChiTietDatBan.GetFocusedRowCellValue(id_ct_mon).ToString());
                    
                    DialogResult result = MessageBox.Show("Chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        datban_bll.XoaChiTiet(iddb, idm);
                        MessageBox.Show("Xóa thành công");
                        LoadChiTietDatBan();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            if(gridView_DsDatBan.GetFocusedRowCellValue(id_datban) != null)
            {
                DatBan db = new DatBan();
                db.id_datban = int.Parse(gridView_DsDatBan.GetFocusedRowCellValue(id_datban).ToString());
                db.id_khachhang = (int)cbxKhachHang.EditValue;
                if (lvDsBan.SelectedItems.Count > 0)
                {
                    db.id_ban = Convert.ToInt16(lvDsBan.SelectedItems[0].Name);
                }
                else
                {
                    MessageBox.Show("Xin chọn Bàn");
                    return;
                }
                db.thoigian = dtNgayDat.DateTime;
                datban_bll.SuaPhieuDatBan(db);
                MessageBox.Show("Sửa phiếu thành công");
                LoadDsBan();
                LoadDsDatBan();
                LoadChiTietDatBan();
            }
            else
            {
                MessageBox.Show("Chọn phiếu đặt bàn muốn sửa");
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (gridView_DsDatBan.GetFocusedRowCellValue(id_datban) != null)
            {
                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa phiếu không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    int id = int.Parse(gridView_DsDatBan.GetFocusedRowCellValue(id_datban).ToString());
                    datban_bll.XoaPhieuDatBan(id);
                    MessageBox.Show("Xóa phiếu thành công");
                    LoadDsBan();
                    LoadDsDatBan();
                    LoadChiTietDatBan();
                }
                
            }
            else
            {
                MessageBox.Show("Chọn phiếu đặt bàn muốn xóa");
            }
        }
    }
}