using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common.Common.Class;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Dictionary.UI.Base;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class frmAddDIC_DICHVU : frmAddBase<DIC_DICHVU>
    {
        public frmAddDIC_DICHVU()
        {
            InitializeComponent();
            this.xucAddDIC_DICHVU1.Success += new xucAddDIC_DICHVU.SuccessEventHander(this.xucAddDIC_DICHVU1_Success);
            this.xucAddDIC_DICHVU1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DICHVU1_Cancel);
        }
        public frmAddDIC_DICHVU(Common.Common.Class.Actions action)
        {
            InitializeComponent();
            if (action== Common.Common.Class.Actions.Add)
            {
                this.xucAddDIC_DICHVU1.Add();
            }
            this.xucAddDIC_DICHVU1.actions = action;
            this.Text = "Dịch vụ";
            this.xucAddDIC_DICHVU1.Success += new xucAddDIC_DICHVU.SuccessEventHander(this.xucAddDIC_DICHVU1_Success);
            this.xucAddDIC_DICHVU1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DICHVU1_Cancel);
        }
        public frmAddDIC_DICHVU(Common.Common.Class.Actions action,DIC_DICHVU model)
        {
            InitializeComponent();
            if (action == Common.Common.Class.Actions.Add)
            {
                this.xucAddDIC_DICHVU1.Add();
            }
            this.xucAddDIC_DICHVU1.actions = action;
            this.xucAddDIC_DICHVU1.SetModel(model);
            if (model != null) this.Text = String.Format("Dịch vụ: {0} - {1}", model.MaDichVu, model.TenDichVu);
            this.xucAddDIC_DICHVU1.Success += new xucAddDIC_DICHVU.SuccessEventHander(this.xucAddDIC_DICHVU1_Success);
            this.xucAddDIC_DICHVU1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DICHVU1_Cancel);
        }
        public override void Delete()
        {
            this.xucAddDIC_DICHVU1.DeleteModel();
        }
        private void xucAddDIC_DICHVU1_Success(object sender, DIC_DICHVU model)
        {
            
            if (this.xucAddDIC_DICHVU1.actions== Common.Common.Class.Actions.Add || this.xucAddDIC_DICHVU1.actions == Common.Common.Class.Actions.AddNew)
            {
                this.RaiseAddedEventHander(model);
            }
            else if(this.xucAddDIC_DICHVU1.actions == Common.Common.Class.Actions.Update)
            {
                this.RaiseUpdatedEventHander(model);
            }
            if (this.xucAddDIC_DICHVU1.IsClose == CloseOrNew.Close)
            {
                base.Close();
            }
            this.xucAddDIC_DICHVU1.ClearModel();
        }
        
        
        private void xucAddDIC_DICHVU1_Cancel(object sender)
        {
            this.Close();
        }
        
        private void InitializeComponent()
        {
            this.xucAddDIC_DICHVU1 = new Vssoft.Dictionary.UI.Core.Actions.xucAddDIC_DICHVU();
            this.SuspendLayout();
            // 
            // xucAddDIC_DICHVU1
            // 
            this.xucAddDIC_DICHVU1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xucAddDIC_DICHVU1.IsClose = Vssoft.Common.Common.Class.CloseOrNew.None;
            this.xucAddDIC_DICHVU1.Location = new System.Drawing.Point(0, 0);
            this.xucAddDIC_DICHVU1.Name = "xucAddDIC_DICHVU1";
            this.xucAddDIC_DICHVU1.NotSave = false;
            this.xucAddDIC_DICHVU1.Size = new System.Drawing.Size(972, 465);
            this.xucAddDIC_DICHVU1.Status = Vssoft.Common.Common.Class.Actions.None;
            this.xucAddDIC_DICHVU1.TabIndex = 0;
            this.xucAddDIC_DICHVU1.Title = "";
            // 
            // frmAddDIC_DICHVU
            // 
            this.ClientSize = new System.Drawing.Size(972, 465);
            this.Controls.Add(this.xucAddDIC_DICHVU1);
            this.Name = "frmAddDIC_DICHVU";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}
