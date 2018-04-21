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

namespace Vssoft.His
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm, IFormMain
    {

        #region Local Variable

        Form1 xfmSalary;
        private SqlHelper sqlHelper;
        Form2 form2;
        xfmDictionary _xfmDictionary;

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

        void xfmSalary_FormClosing(object sender, FormClosingEventArgs e)
        {
            
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
            this.xfmSalary.FormClosing += new FormClosingEventHandler(this.xfmSalary_FormClosing);
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
            this.form2.FormClosing += new FormClosingEventHandler(this.xfmSalary_FormClosing);
            this.form2.Show();
        }

        private void bbiDictionary_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._xfmDictionary != null && !this._xfmDictionary.IsDisposed)
            {
                this.tabMdi.Pages[this._xfmDictionary].MdiChild.Activate();
                return;
            }
            xfmDictionary form = new xfmDictionary
            {
                MdiParent = this
            };
            this._xfmDictionary = form;
            this._xfmDictionary.FormClosing += new FormClosingEventHandler(this.xfmSalary_FormClosing);
            this._xfmDictionary.Show();
        }
        
        private void timer_Tick_1(object sender, EventArgs e)
        {
            this.lblToday.Caption = "Thời gian: " + System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }
        public void OpenFormNewTab(Form frm)
        {
            frm.MdiParent = this;

            frm.FormClosing += new FormClosingEventHandler(this.xfmSalary_FormClosing);
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