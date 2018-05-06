using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Vssoft.Dictionary;
using System.Reflection;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Vssoft.Data.Helper;
using Vssoft.Common;

namespace Vssoft.His
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm, IFormMain
    {

        #region Local Variable

        Form1 xfmSalary;
        private SqlHelper sqlHelper;
        Form2 form2;
        frmDictionary _frmDictionary;

        #endregion
        public frmMain()
        {
            InitializeComponent();
            //Vssoft.Logonui.xfmLoginClassic _xfmLoginClassic = new Logonui.xfmLoginClassic();
            //_xfmLoginClassic.LoginSuccess += new Logonui.xfmLoginClassic.LoginSuccessEventHander(this.formLoginSuccess);
            //_xfmLoginClassic.ShowDialog(this);
            
        }
        

        void formLoginSuccess(object sender)
        {

        }

        void frmDictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._frmDictionary = null;
            MainFormHelper.CompactCurrentProcessWorkingSet();
        }
        private void bbiWorkdesk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.xfmSalary != null)
            {
                this.tabMdi.Pages[this.xfmSalary].MdiChild.Activate();
                return;
            }
            Form1 salary = new Form1
            {
                MdiParent = this
            };
            this.xfmSalary = salary;
            this.xfmSalary.FormClosing += new FormClosingEventHandler(this.frmDictionary_FormClosing);
            this.xfmSalary.Show();
        }

        private void bbiTotalUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.form2 != null)
            {
                this.tabMdi.Pages[this.form2].MdiChild.Activate();
                return;
            }
            Form2 form12 = new Form2
            {
                MdiParent = this
            };
            this.form2 = form12;
            this.form2.FormClosing += new FormClosingEventHandler(this.frmDictionary_FormClosing);
            this.form2.Show();
        }

        private void bbiDictionary_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._frmDictionary != null && !this._frmDictionary.IsDisposed)
            {
                this.tabMdi.Pages[this._frmDictionary].MdiChild.Activate();
                return;
            }
            frmDictionary form = new frmDictionary
            {
                MdiParent = this
            };
            this._frmDictionary = form;
            this._frmDictionary.FormClosing += new FormClosingEventHandler(this.frmDictionary_FormClosing);
            this._frmDictionary.Show();
            MainFormHelper.CompactCurrentProcessWorkingSet();
        }
        
        private void timer_Tick_1(object sender, EventArgs e)
        {
            this.lblToday.Caption = "Thời gian: " + System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            this.bbiNumlock.Caption = SqlHelper.Count.ToString();
        }

        public void OpenFormNewTab(Form frm)
        {
            frm.MdiParent = this;

            frm.FormClosing += new FormClosingEventHandler(this.frmDictionary_FormClosing);
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.lblInfo.Caption = "Phiên bản: 2.2.1" ;
            this.LoadSkin();
            this.sqlHelper = new SqlHelper();
            this.lblServer.Caption = this.sqlHelper.Server + " ";
            this.lblDatabase.Caption = this.sqlHelper.Database + " ";
            this.lblAccount.Caption = "Người sử dụng: "+"Nguyễn Đình Khánh";
        }

        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {   
            UserLookAndFeel.Default.SkinName = e.Item.Tag.ToString();
        }

        private void LoadSkin()
        {
            foreach (SkinContainer container in SkinManager.Default.Skins)
            {
                BarCheckItem item = this.rbcMain.Items.CreateCheckItem(container.SkinName, false);
                item.Tag = container.SkinName;
                item.ItemClick += new ItemClickEventHandler(this.OnPaintStyleClick);
                this.bbSkin.ItemLinks.Add(item);
            }
            //Welcome.LoadWelcome();
        }
        
    }
}