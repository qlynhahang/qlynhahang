﻿using System;
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
    public partial class Frm_Ban : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Ban()
        {
            InitializeComponent();
            RestaurantDBDataContext db = new RestaurantDBDataContext();

            // This line of code is generated by Data Source Configuration Wizard
            lue_LoaiBan.DataSource = new RestaurantSoftware.DA_Layer.RestaurantDBDataContext().LoaiBans;
            // This line of code is generated by Data Source Configuration Wizard
            lue_TrangThai.DataSource = db.TrangThais.Where(TrangThai => TrangThai.lienket == "B");
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_LuuLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}