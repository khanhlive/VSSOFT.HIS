using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Common.Common.Class;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.Dictionary.UI.Base;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public partial class frmAddDIC_DUOC :  frmAddBase<DIC_DICHVU>
    {
        public frmAddDIC_DUOC()
        {
            InitializeComponent();
            this.xucAddDIC_DUOC1.Success += new xucAddDIC_DUOC.SuccessEventHander(this.xucAddDIC_DUOC_Success);
            this.xucAddDIC_DUOC1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DUOC_Cancel);
        }
        public frmAddDIC_DUOC(Common.Common.Class.Actions action)
        {
            InitializeComponent();
            if (action == Common.Common.Class.Actions.Add)
            {
                this.xucAddDIC_DUOC1.Add();
            }
            this.xucAddDIC_DUOC1.actions = action;
            this.Text = "Dịch vụ";
            this.xucAddDIC_DUOC1.Success += new xucAddDIC_DUOC.SuccessEventHander(this.xucAddDIC_DUOC_Success);
            this.xucAddDIC_DUOC1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DUOC_Cancel);
        }
        public frmAddDIC_DUOC(Common.Common.Class.Actions action, DIC_DICHVU model)
        {
            InitializeComponent();
            if (action == Common.Common.Class.Actions.Add)
            {
                this.xucAddDIC_DUOC1.Add();
            }
            this.xucAddDIC_DUOC1.actions = action;
            this.xucAddDIC_DUOC1.SetModel(model);
            if (model != null) this.Text = String.Format("Thuốc: {0} - {1}", model.MaDichVu, model.TenDichVu);
            this.xucAddDIC_DUOC1.Success += new xucAddDIC_DUOC.SuccessEventHander(this.xucAddDIC_DUOC_Success);
            this.xucAddDIC_DUOC1.CancelClick += new ButtonClickEventHander(this.xucAddDIC_DUOC_Cancel);
        }
        public override void Delete()
        {
            this.xucAddDIC_DUOC1.DeleteModel();
        }
        private void xucAddDIC_DUOC_Success(object sender, DIC_DICHVU model)
        {

            if (this.xucAddDIC_DUOC1.actions == Common.Common.Class.Actions.Add || this.xucAddDIC_DUOC1.actions == Common.Common.Class.Actions.AddNew)
            {
                this.RaiseAddedEventHander(model);
            }
            else if (this.xucAddDIC_DUOC1.actions == Common.Common.Class.Actions.Update)
            {
                this.RaiseUpdatedEventHander(model);
            }
            if (this.xucAddDIC_DUOC1.IsClose == CloseOrNew.Close)
            {
                base.Close();
            }
            this.xucAddDIC_DUOC1.ClearModel();
        }


        private void xucAddDIC_DUOC_Cancel(object sender)
        {
            this.Close();
        }
    }
}
