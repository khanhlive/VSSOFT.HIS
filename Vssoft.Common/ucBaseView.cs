using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Data;
using Vssoft.Common.Common.Class;

namespace Vssoft.Common
{
    public class ucBaseView: XtraUserControl
    {
        protected bool isUpdated = false;
        protected bool isValidModel = true;
        public Actions actions = Actions.None;
        public event SaveCompleteEventHander SaveComplete;
        
        protected object Model;
        protected DXErrorProvider dxErrorProviderModel;
        public bool isEdited { get; protected set; }
       
        public ucBaseView() {
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

        protected virtual void BindingModel() { }

        public virtual void SetModel(object key, object dataSource)
        {

        }

        public virtual void SetModel(DataRow rowFocused, object dataSource)
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
        

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucBaseView
            // 
            this.Name = "ucBaseView";
            this.Size = new System.Drawing.Size(251, 235);
            this.ResumeLayout(false);

        }
    }
}
