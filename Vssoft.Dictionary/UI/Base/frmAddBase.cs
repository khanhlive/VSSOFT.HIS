using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using Vssoft.Common;

namespace Vssoft.Dictionary.UI.Base
{
    public partial class frmAddBase<T> : XtraForm
    {
        public event AddedEventHander Added;
        public RowClickEventArgs m_RowClickEventArgs;
        public event UpdatedEventHander Updated;
        public frmAddBase()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(this.frmAddBase_Closed);
        }
        protected virtual void RaiseAddedEventHander(T model)
        {
            this.Added?.Invoke(this, model);
        }
        protected virtual void frmAddBase_Closed(object sender, FormClosedEventArgs e)
        {
            MainFormHelper.CompactCurrentProcessWorkingSet();
        }

        protected virtual void RaiseUpdatedEventHander(T model)
        {
            this.Updated?.Invoke(this, model);
        }
        public virtual void Delete()
        {
            
        }
        public delegate void AddedEventHander(object sender, T model);
        public delegate void UpdatedEventHander(object sender, T model);
    }
}
