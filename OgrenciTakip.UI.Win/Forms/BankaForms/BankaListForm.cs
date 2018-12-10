﻿
using DevExpress.XtraBars;
using OgrenciTakip.BLL.General;
using OgrenciTakip.Common.Enums;
using OgrenciTakip.Model.Entities;
using OgrenciTakip.UI.Win.Forms.BaseForms;
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.UI.Win.Show;

namespace OgrenciTakip.UI.Win.Forms.BankaForms
{
    public partial class BankaListForm : BaseListForm
    {
        public BankaListForm()
        {
            InitializeComponent();

            bll = new BankaBll();
            btnBagliKartlar.Caption = "Şube Kartları";
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            kartTuru = KartTuru.Banka;
            formShow = new ShowEditForms<BankaEditForm>();
            navigator = longNavigator.Navigator;
            if (IsMdiChild)
                ShowItems = new BarItem[] { btnBagliKartlar };
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaBll)bll).List(FilterFunctions.Filter<Banka>(aktifKartlariGoster));
        }

        //protected override void BagliKartAc()
        //{
        //    var entity = Tablo.GetRow<Banka>();
        //    if (entity == null) return;
        //    ShowListForms<BankaListForm>.ShowListForm()
        //}
    }
}