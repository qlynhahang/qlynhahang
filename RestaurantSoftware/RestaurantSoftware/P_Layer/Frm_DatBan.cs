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
           
            foreach(DataRow dr in ban.Rows)
            {
                bool exsistGroup = false;
                ListViewItem lvItem = new ListViewItem();
                ListViewGroup lvGroup = new ListViewGroup();
                lvItem.Text = dr["tenban"].ToString();
                switch(dr["trangthai"].ToString())
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

        private void Frm_DatBan_Load(object sender, EventArgs e)
        {
            LoadDsBan();
            LoadDsMon();
            LoadDsDatBan();
            LoadDsKhachHang();
        }

        private void btn_ThemMon_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void dtNgayDat_EditValueChanged(object sender, EventArgs e)
        {
            LoadDsBan();
        }

        private void lvDsBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDsBan.SelectedItems.Count > 0)
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
    }
}