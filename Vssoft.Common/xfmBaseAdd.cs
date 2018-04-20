namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xfmBaseAdd : XtraForm
    {
        private IContainer components = null;
        public RowClickEventArgs m_RowClickEventArgs;
        protected xucBase ucAdd = null;

        public event AddedEventHander Added;

        public event UpdatedEventHander Updated;

        public xfmBaseAdd()
        {
            this.InitializeComponent();
        }

        public void Delete()
        {
            this.ucAdd.Delete();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Init()
        {
            this.ucAdd.Success += new xucBase.SuccessEventHander(this.ucAdd_Success);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            base.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "xfmBaseAdd";
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    base.Close();
                    return true;

                case Keys.F2:
                    return true;

                case (Keys.Control | Keys.S):
                    return true;

                case (Keys.Control | Keys.W):
                    return true;

                case (Keys.Control | Keys.Shift | Keys.S):
                    return true;

                case (Keys.Alt | Keys.D):
                    MessageBox.Show("You are stupid");
                    return true;

                case (Keys.Alt | Keys.X):
                    base.Close();
                    return true;
            }
            return false;
        }

        public void RaiseAddedEventHander(object Item)
        {
            if (this.Added != null)
            {
                this.Added(this, Item);
            }
        }

        public void RaiseUpdatedEventHander(object Item)
        {
            if (this.Updated != null)
            {
                this.Updated(this, Item);
            }
        }

        private void ucAdd_CancelClick(object sender)
        {
            base.Close();
        }

        private void ucAdd_Success(object sender, object Item)
        {
            if (this.ucAdd.Status == Actions.Add)
            {
                this.RaiseAddedEventHander(Item);
            }
            else if (this.ucAdd.Status == Actions.Update)
            {
                this.RaiseUpdatedEventHander(Item);
            }
            if (this.ucAdd.IsClose == CloseOrNew.Close)
            {
                base.Close();
            }
            this.ucAdd.Clear();
        }

        public delegate void AddedEventHander(object sender, object Item);

        public delegate void UpdatedEventHander(object sender, object Item);
    }
}

