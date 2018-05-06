using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using System;
using Vssoft.Common.Common.Class;

namespace Vssoft.Common.UserControls
{
    public partial class ucBaseAdd : xucBase
    {
        public event ButtonClickEventHander CancelClick;
        

        protected bool isUpdated = false;
        protected bool isValidModel = true;
        public Actions actions = Actions.None;
        public event SaveCompleteEventHander SaveComplete;
        protected DXErrorProvider dxErrorProviderModel;
        public bool isEdited { get; protected set; }

        protected object Model;
        public ucBaseAdd() : base()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.Loaded);
            this.dxErrorProviderModel = new DXErrorProvider();
            this.dxErrorProviderModel.ContainerControl = this;
        }
        public virtual void SetModel(object model)
        {
            this.Model = model;
            if (this.Model == null)
            {
                this.ClearModel();
            }
            else
            {
                BindingModel();
            }
            this.Update();
        }

        protected virtual void BindingModel()
        {
        }
        
        private void Loaded(object sender, EventArgs e)
        {
            this.Init();
            this.DisabledLayout(true);
        }

        protected virtual void Init()
        {

        }

        protected void SaveCompleteSuccess(object sender, SaveCompleteEventArgs args)
        {
            if (args.Result)
            {
                this.ClearModel();
                this.DisabledLayout(true);
                this.SaveComplete(sender, args);
            }
            else
            {
                XtraMessageBox.Show(args.Message, "Thông báo");
            }

        }

        public virtual void ClearModel()
        {

        }

        public virtual UserActionType DeleteModel()
        {
            return UserActionType.None;
        }

        public virtual void SaveModel()
        {
            this.Validation();
        }

        public virtual void UpdateModel()
        {
            this.DisabledLayout(false);
            this.actions = Actions.Update;
        }

        public virtual void DisabledLayout(bool isDisable)
        {

        }

        public virtual bool Validation()
        {
            return true;
        }

        public virtual void AddNew()
        {
            this.ClearModel();
            this.Model = null;
            this.actions = Actions.AddNew;
            this.DisabledLayout(false);
        }

        public virtual void Cancel()
        {
            this.SetModel(this.Model);
            this.DisabledLayout(true);
            if (this.CancelClick!=null)
            {
                this.CancelClick(this);
            }
        }

        public virtual object GetModel()
        {
            return null;
        }

        protected bool Validate_EmptyStringRule(BaseEdit control)
        {
            if (control.Text == null || control.Text.Trim().Length == 0)
            {
                dxErrorProviderModel.SetError(control, "Trường này không được để trống!", ErrorType.Critical);
                this.isValidModel = false;
                return false;
            }
            else
            {
                this.isValidModel = this.isValidModel ? true : this.isValidModel;
                dxErrorProviderModel.SetError(control, "");
                return true;
            }
        }

        protected virtual void ClearError(LayoutControl layoutControl)
        {
            for (int i = 0; i < layoutControl.Controls.Count; i++)
            {
                dxErrorProviderModel.SetError(layoutControl.Controls[i], "");
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveModel();
        }
    }
}
