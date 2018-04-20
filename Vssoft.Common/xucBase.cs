namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Alerter;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Menu;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraTreeList;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class xucBase : XtraUserControl
    {
        protected GridControl _exportControl;
        protected GridView _exportView;
        protected string _parentControlName = "";
        private string _title = "";
        protected AlertControl alc;
        private IContainer components;
        private WaitDialogForm dlg = null;
        protected CloseOrNew m_CloseOrNew = CloseOrNew.None;
        private bool m_isSave = false;
        protected MenuButton m_Menu;
        protected Actions m_Status = Actions.Add;
        protected ProgressForm progressForm = null;
        protected bool start = true;

        public event RibbonChangedEventHander RibbonChanged;

        public event SaveChangedEventHander SaveChanged;

        public event SaveChangingEventHander SaveChanging;

        public event SaveCompleteEventHander SaveComplete;

        public event SuccessEventHander Success;

        public xucBase()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.alc = new AlertControl();
            this.alc.AllowHtmlText = true;
            this.m_Status = Actions.None;
            this.m_CloseOrNew = CloseOrNew.None;
            this.m_Menu = new MenuButton();
        }

        public virtual void Clear()
        {
        }

        public void CreateWaitDialog()
        {
            this.dlg = new WaitDialogForm("Đang nạp dữ liệu...", "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t...");
        }

        public virtual void Delete()
        {
        }

        private void dlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dlg.Dispose();
            this.dlg = null;
        }

        protected virtual void DoHide()
        {
            base.OnLoad(EventArgs.Empty);
            if (this.dlg != null)
            {
                this.dlg.FormClosing += new FormClosingEventHandler(this.dlg_FormClosing);
                this.dlg.Close();
            }
        }

        protected virtual void DoShow()
        {
        }

        public void DoShowMenu(GridHitInfo hi, GridView view)
        {
            if (hi.HitTest == GridHitTest.ColumnButton)
            {
                GridViewMenu menu = new GridViewColumnButtonMenu(view);
                menu.Init(hi);
                menu.Show(hi.HitPoint);
            }
        }

        public void DoShowMenu(GridHitInfo hi, GridView view, Control control)
        {
            GridViewColumnButtonMenu menu;
            if (hi.HitTest == GridHitTest.ColumnButton)
            {
                menu = new GridViewColumnButtonMenu(view) {
                    ParentControl = control,
                    ParentControlName = this._parentControlName
                };
                menu.Init(hi);
                menu.Show(hi.HitPoint);
            }
            else
            {
                try
                {
                    if ((hi as BandedGridHitInfo).HitTest == BandedGridHitTest.BandButton)
                    {
                        menu = new GridViewColumnButtonMenu(view) {
                            ParentControl = control,
                            ParentControlName = this._parentControlName
                        };
                        menu.Init(hi);
                        menu.Show(hi.HitPoint);
                    }
                }
                catch
                {
                }
            }
        }

        protected virtual void EndExport()
        {
            if (this.progressForm != null)
            {
                this.progressForm.Dispose();
            }
            this.progressForm = null;
        }

        public void Export()
        {
            if (this.ExportPermision())
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "Microsoft Excel 97-2003(*.xls)|*.xls|Microsoft Excel 2007(*.xlsx)|*.xlsx|PDF(*.pdf)|*.pdf|Rich Text Format(*.rtf)|*.rtf|Webpage (*.htm)|*.htm",
                    FilterIndex = 0
                };
                dialog.ShowDialog();
                if (dialog.FileName != null)
                {
                    try
                    {
                        if (dialog.FilterIndex == 1)
                        {
                            this.ExportToEx(dialog.FileName, "xls");
                        }
                        else if (dialog.FilterIndex == 2)
                        {
                            this.ExportToEx(dialog.FileName, "xlsx");
                        }
                        else if (dialog.FilterIndex == 3)
                        {
                            this.ExportToEx(dialog.FileName, "pdf");
                        }
                        else if (dialog.FilterIndex == 4)
                        {
                            this.ExportToEx(dialog.FileName, "rtf");
                        }
                        else if (dialog.FilterIndex == 5)
                        {
                            this.ExportToEx(dialog.FileName, "htm");
                        }
                        if (File.Exists(dialog.FileName) && (XtraMessageBox.Show("Bạn muốn mở t\x00e0i liệu n\x00e0y kh\x00f4ng?", "Th\x00f4ng B\x00e1o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No))
                        {
                            Process.Start(dialog.FileName);
                        }
                    }
                    catch (Exception)
                    {
                        this.EndExport();
                    }
                }
            }
        }

        public virtual void Export(GridView view)
        {
            this._exportView = view;
            this.Export();
        }

        public void Export(TreeList treeList)
        {
            if (this.ExportPermision())
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "Microsoft Excel 97-2003(*.xls)|*.xls|Microsoft Excel 2007(*.xlsx)|*.xlsx|PDF(*.pdf)|*.pdf|Rich Text Format(*.rtf)|*.rtf|Webpage (*.htm)|*.htm",
                    FilterIndex = 0
                };
                dialog.ShowDialog();
                if (dialog.FileName != null)
                {
                    try
                    {
                        if (dialog.FilterIndex == 1)
                        {
                            treeList.ExportToXls(dialog.FileName);
                        }
                        else if (dialog.FilterIndex == 2)
                        {
                            treeList.ExportToXlsx(dialog.FileName);
                        }
                        else if (dialog.FilterIndex == 3)
                        {
                            treeList.ExportToPdf(dialog.FileName);
                        }
                        else if (dialog.FilterIndex == 4)
                        {
                            treeList.ExportToRtf(dialog.FileName);
                        }
                        else if (dialog.FilterIndex == 5)
                        {
                            treeList.ExportToHtml(dialog.FileName);
                        }
                        if (File.Exists(dialog.FileName) && (XtraMessageBox.Show("Bạn muốn mở t\x00e0i liệu n\x00e0y kh\x00f4ng?", "Th\x00f4ng B\x00e1o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No))
                        {
                            Process.Start(dialog.FileName);
                        }
                    }
                    catch (Exception)
                    {
                        this.EndExport();
                    }
                }
            }
        }

        public virtual void Export(GridView view, string title)
        {
            this.Title = title;
            this.Export(view);
        }

        protected virtual void Export_ProgressEx(object sender, ChangeEventArgs e)
        {
            if (e.EventName == "ProgressPositionChanged")
            {
                int position = (int) e.ValueOf("ProgressPosition");
                this.progressForm.SetProgressValue(position);
            }
        }

        protected virtual bool ExportPermision() => 
            true;

        private void ExportToEx(string filename, string ext)
        {
            this.StartExport();
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (this._exportView == null)
            {
                this.EndExport();
                XtraMessageBox.Show("Đối tượng kết xuất chưa x\x00e1c định");
            }
            else
            {
                PrintingSystem currentPS = new PrintingSystem();
                //currentPS.AfterChange += new ChangeEventHandler(this.Export_ProgressEx);
                //if (ext == "rtf")
                //{
                //    this._exportView.ExportToRtf(filename);
                //}
                //if (ext == "pdf")
                //{
                //    this._exportView.ExportToPdf(filename);
                //}
                //if (ext == "mht")
                //{
                //    this._exportView.ExportToMht(filename);
                //}
                //if (ext == "htm")
                //{
                //    this._exportView.ExportToHtml(filename, new HtmlExportOptions("utf-8"));
                //}
                //if (ext == "txt")
                //{
                //    this._exportView.ExportToText(filename, new TextExportOptions(" ", Encoding.Unicode));
                //}
                //if (ext == "xls")
                //{
                //    this._exportView.ExportToXls(filename, new XlsExportOptions(TextExportMode.Value, true));
                //}
                //if (ext == "xlsOld")
                //{
                //    this._exportView.ExportToExcelOld(filename);
                //}
                //if (ext == "xlsx")
                //{
                //    this._exportView.ExportToXlsx(filename, new XlsxExportOptions(TextExportMode.Value, true));
                //}
                //currentPS.AfterChange -= new ChangeEventHandler(this.Export_ProgressEx);
                //Cursor.Current = current;
                //this.EndExport();
            }
        }

        public void FormatColumns(RepositoryItemGridLookUpEdit item, string column, int pos, int width, string caption)
        {
            this.FormatColumns(item, column, pos, width, caption, true);
        }

        public void FormatColumns(RepositoryItemGridLookUpEdit item, string column, int pos, int width, string caption, RepositoryItem repositoryItem)
        {
            this.FormatColumns(item, column, pos, width, caption, repositoryItem, true);
        }

        public void FormatColumns(RepositoryItemGridLookUpEdit item, string column, int pos, int width, string caption, bool visible)
        {
            this.FormatColumns(item, column, pos, width, caption, null, visible);
        }

        public void FormatColumns(RepositoryItemGridLookUpEdit item, string column, int pos, int width, string caption, RepositoryItem repositoryItem, bool visible)
        {
            GridColumn column2 = item.View.Columns.AddField(column);
            column2.VisibleIndex = pos;
            column2.Caption = caption;
            column2.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            column2.Visible = visible;
            column2.ColumnEdit = repositoryItem;
            column2.Width = width;
        }

        public string GenerateCode(string studentName)
        {
            string str = "";
            string[] strArray = studentName.Split(new char[] { ' ' });
            foreach (string str2 in strArray)
            {
                if (str2.Length > 0)
                {
                    str = str + str2.Substring(0, 1);
                }
            }
            return str;
        }

        public object GetCellValue(Vssoft.Common.Common.Class.RowClickEventArgs e, AdvBandedGridView view)
        {
            GridColumn column = new GridColumn();
            if (e.ColumnIndex != -1)
            {
                column = view.Columns[e.ColumnIndex];
            }
            else
            {
                column = view.Columns[e.FieldName];
            }
            return view.GetRowCellValue(e.RowIndex, column);
        }

        public object GetCellValue(Vssoft.Common.Common.Class.RowClickEventArgs e, GridView view)
        {
            GridColumn column = new GridColumn();
            if (e.ColumnIndex != -1)
            {
                column = view.Columns[e.ColumnIndex];
            }
            else
            {
                column = view.Columns[e.FieldName];
            }
            return view.GetRowCellValue(e.RowIndex, column);
        }

        public object GetCellValue(int Rowindex, GridColumn ColIndex, GridView view) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(Rowindex, ColIndex.ColumnHandle, ColIndex.FieldName), view);

        public object GetCellValue(int RowIndex, int ColumIndex, AdvBandedGridView view) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(RowIndex, ColumIndex), view);

        public object GetCellValue(int Rowindex, int ColIndex, GridView view) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(Rowindex, ColIndex), view);

        public object GetCellValue(int RowIndex, string FieldName, AdvBandedGridView view) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(RowIndex, FieldName), view);

        public object GetCellValue(int Rowindex, string FieldName, GridView view) => 
            this.GetCellValue(new Vssoft.Common.Common.Class.RowClickEventArgs(Rowindex, FieldName), view);

        private void InitializeComponent()
        {
            this.components = new Container();
            this.alc = new AlertControl(this.components);
            base.SuspendLayout();
            this.alc.AllowHtmlText = true;
            base.Name = "xucBase";
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.dlg != null)
            {
                this.dlg.Close();
            }
        }

        protected virtual void OnSwitchStyle()
        {
        }

        protected void RaiseRibbonChanged(RibbonChangedEventArgs e)
        {
            RibbonChangedEventHander ribbonChanged = this.RibbonChanged;
            if (ribbonChanged != null)
            {
                ribbonChanged(this, e);
            }
        }

        protected void RaiseSaveChanged(SaveChangedEventArgs e)
        {
            SaveChangedEventHander saveChanged = this.SaveChanged;
            if (saveChanged != null)
            {
                saveChanged(this, e);
            }
        }

        protected void RaiseSaveChanging(SaveChangingEventArgs e)
        {
            SaveChangingEventHander saveChanging = this.SaveChanging;
            if (saveChanging != null)
            {
                saveChanging(this, e);
            }
        }

        protected void RaiseSaveComplete(SaveCompleteEventArgs e)
        {
            SaveCompleteEventHander saveComplete = this.SaveComplete;
            if (saveComplete != null)
            {
                saveComplete(this, e);
            }
        }

        public void RaiseSuccessEventHander(object Item)
        {
            if (this.Success != null)
            {
                this.Success(this, Item);
            }
        }

        public void RestoreLayout(GridView view, Control control)
        {
            new GridViewColumnButtonMenu(view) { 
                ParentControl = control,
                ParentControlName = this._parentControlName
            }.RestoreLayout();
        }

        public void SetWaitDialogCaption(string fCaption)
        {
            if (this.dlg != null)
            {
                this.dlg.Caption = fCaption;
            }
            else
            {
                this.CreateWaitDialog();
                if (this.dlg != null)
                {
                    this.dlg.Caption = fCaption;
                }
            }
        }

        public void SetWaitDialogCaption(string fCaption, string fTitle)
        {
            if (this.dlg != null)
            {
                this.DoHide();
                this.dlg = new WaitDialogForm(fCaption, fTitle);
            }
            else
            {
                this.dlg = new WaitDialogForm(fCaption, fTitle);
            }
        }

        protected virtual void StartExport()
        {
            this.progressForm = new ProgressForm(this);
            this.progressForm.Show();
            this.progressForm.Refresh();
        }

        [Category("Config"), DisplayName("Close")]
        public CloseOrNew IsClose
        {
            get => 
                this.m_CloseOrNew;
            set
            {
                this.m_CloseOrNew = value;
            }
        }

        [DisplayName("Save"), Description("L\x00e0 thuộc t\x00ednh thể trạng th\x00e1i của dữ liệu hiện tại c\x00f3 được lưu hay chưa."), Category("Config")]
        public bool NotSave
        {
            get => 
                this.m_isSave;
            set
            {
                this.m_isSave = value;
            }
        }

        [Category("Config"), PropertyTab(typeof(MenuButton)), DisplayName("Bar")]
        public MenuButton RibbonBar
        {
            get => 
                this.m_Menu;
            set
            {
                this.m_Menu = value;
            }
        }

        [Category("Config"), Description("L\x00e0 thuộc t\x00ednh thể trạng th\x00e1i của dữ liệu."), DisplayName("Status")]
        public Actions Status
        {
            get => 
                this.m_Status;
            set
            {
                this.m_Status = value;
            }
        }

        [Category("Config"), Description("L\x00e0 thuộc t\x00ednh ti\x00eau đề khi in ra."), DisplayName("Title")]
        public string Title
        {
            get => 
                this._title;
            set
            {
                this._title = value;
            }
        }

        public enum ColumnKeyPress
        {
            None,
            Quantity,
            UnitPrice,
            Amount,
            Discount,
            Vat,
            Unit
        }

        public delegate void SuccessEventHander(object sender, object Item);

        public enum TypeAdd
        {
            None,
            Single,
            Replace,
            Add,
            Duplicate
        }
    }
}

