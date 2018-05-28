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
        public new event SaveCompleteEventHander SaveComplete;
        protected DXErrorProvider dxErrorProviderModel;
        public bool IsEdited { get; protected set; }

        protected object Model;
        public ucBaseAdd() : base()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.Loaded);
            this.dxErrorProviderModel = new DXErrorProvider
            {
                ContainerControl = this
            };
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
                this.SaveComplete?.Invoke(sender, args);
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

        public virtual void Add()
        {
            this.ClearModel();
            this.Model = null;
            this.actions = Actions.Add;
            this.DisabledLayout(false);
        }

        //public virtual void AddNew()
        //{
        //    this.m_CloseOrNew = CloseOrNew.New;
        //    this.Add();
        //    this.actions = Actions.AddNew;
        //}

        public virtual void Cancel()
        {
            this.SetModel(this.Model);
            this.DisabledLayout(true);
            if (this.CancelClick != null)
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
                dxErrorProviderModel.SetError(control, string.Empty);
                return true;
            }
        }

        protected virtual void ClearError(LayoutControl layoutControl)
        {
            for (int i = 0; i < layoutControl.Controls.Count; i++)
            {
                dxErrorProviderModel.SetError(layoutControl.Controls[i], string.Empty);
            }
        }
        protected virtual void ClearErrorControl(BaseEdit control)
        {
            this.isValidModel = this.isValidModel ? true : this.isValidModel;
            dxErrorProviderModel.SetError(control, string.Empty);
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                this.m_CloseOrNew = CloseOrNew.New;
                this.SaveModel();
                this.Add();
                this.actions = Actions.Add;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.m_CloseOrNew = CloseOrNew.Close;
            this.SaveModel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelClick?.Invoke(this);
        }
    }
}
