namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using DevExpress.XtraWizard;
    using Vssoft.Data.Helper;
    //using Vssoft.Utils.Excel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xfmBaseImport : XtraForm
    {
        public ComboBoxEdit cboSheet;
        public CheckEdit cheIsUpdate;
        public GridColumn colFieldName;
        private GridColumn colMessage;
        public GridColumn colSelectField;
        private GridColumn colStatus;
        private IContainer components = null;
        public List<string> FieldName;
        public GridView gbList;
        private GridView gbMessage;
        public GridControl gcList;
        private GridControl gcMessage;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem layoutControlItem1;
        public LabelControl lbDataRow;
        public LabelControl lbFilePathDescription;
        public LabelControl lbFinishDescription;
        private LinkLabel lbFix;
        public LabelControl lbLinkFile;
        public LabelControl lbLinkFileDecription;
        private LabelControl lbMessage;
        public LabelControl lbProgressDescription;
        private LayoutControl lcSheet;
        private int m_Error = 0;
        private bool m_IsFieldFull = false;
        private int m_Success = 0;
        public MarqueeProgressBarControl mqProgress;
        public string[] ParamName;
        public List<int> ParamNameIndex;
        public RepositoryItemComboBox repSelectField;
        public ButtonEdit txtFilePath;
        public WizardControl wcImport;
        public CompletionWizardPage wpFinish;
        public DevExpress.XtraWizard.WizardPage wpProcessPage;
        public DevExpress.XtraWizard.WizardPage wpSelectField;
        public WelcomeWizardPage wpSelectFile;

        public event SuccessEventHander Success;

        public xfmBaseImport()
        {
            this.InitializeComponent();
            this.CreateNullMessage();
            this.lbLinkFile.Text = Application.StartupPath + @"\ImportFile\*.xls";
            this.Success = (SuccessEventHander) Delegate.Combine(this.Success, new SuccessEventHander(this.xfmImport_Success));
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillField();
        }

        public void CreateNullMessage()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Message"));
            table.Columns.Add(new DataColumn("Status"));
            this.gcMessage.DataSource = table;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void ErrorRow(string Error)
        {
            this.m_Error++;
            this.gbMessage.AddNewRow();
            this.gbMessage.SetFocusedRowCellValue(this.colMessage, Error);
            this.gbMessage.SetFocusedRowCellValue(this.colStatus, "1");
        }

        protected virtual void FillField()
        {
        }

        public void FillField(List<string> FieldName)
        {
            string text = this.cboSheet.Text;
            SqlHelper helper = new SqlHelper();
            DataTable dataTable = new DataTable();
            List<int> list = new List<int>();
            DataTable table2 = new DataTable();//ExcelImport.ReadExcelContents(this.txtFilePath.Text, text);
            if (table2 != null)
            {
                string[] strArray = new string[table2.Columns.Count];
                this.repSelectField.Items.Clear();
                int index = 0;
                try
                {
                    foreach (DataColumn column in table2.Columns)
                    {
                        if (table2.Rows[0][column.Caption].ToString() != "")
                        {
                            strArray[index] = table2.Rows[0][column.Caption].ToString();
                            this.repSelectField.Items.Add(table2.Rows[0][column.Caption].ToString());
                            index++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Kh\x00f4ng thể đọc sheet n\x00e0y! N\x00f3 kh\x00f4ng giống cấu tr\x00fac mặc định của chương tr\x00ecnh!", "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                foreach (string str2 in FieldName)
                {
                    if (str2 != "")
                    {
                        new SqlDataAdapter("select N'" + str2 + "' as [FieldName], '' as [SelectField]", helper.ConnectionString).Fill(dataTable);
                    }
                }
                this.gcList.DataSource = dataTable;
                for (int i = 0; i < table2.Columns.Count; i++)
                {
                    this.gbList.SetRowCellValue(i, this.colSelectField, strArray[i]);
                    index = i;
                }
                if (FieldName.Count <= (index + 1))
                {
                    this.m_IsFieldFull = true;
                }
            }
        }

        public void FillSheet()
        {
            DataTable table = new DataTable();// ExcelImport.ReadSheets(this.txtFilePath.Text);
            if (table != null)
            {
                this.cboSheet.Properties.Items.Clear();
                foreach (DataRow row in table.Rows)
                {
                    this.cboSheet.Properties.Items.Add(row["TABLE_NAME"].ToString());
                }
                if (table.Rows.Count > 0)
                {
                    this.cboSheet.SelectedIndex = 0;
                }
            }
        }

        private void Import()
        {
            DataTable excelContentTable = new DataTable();// ExcelImport.ReadExcelContents(this.txtFilePath.Text, this.cboSheet.Text);
            if (excelContentTable != null)
            {
                this.ParamNameIndex = new List<int>();
                for (int i = 0; i < this.gbList.RowCount; i++)
                {
                    DataRow dataRow = this.gbList.GetDataRow(i);
                    if (dataRow[1].ToString() != "")
                    {
                        for (int j = 0; j < this.repSelectField.Items.Count; j++)
                        {
                            if (dataRow[1].ToString() == this.repSelectField.Items[j].ToString())
                            {
                                this.ParamNameIndex.Add(j);
                            }
                        }
                    }
                    else
                    {
                        this.ParamNameIndex.Clear();
                        return;
                    }
                }
                this.Import(excelContentTable);
            }
        }

        protected virtual void Import(DataTable ExcelContentTable)
        {
        }

        private void InitializeComponent()
        {
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xfmBaseImport));
            SerializableAppearanceObject obj3 = new SerializableAppearanceObject();
            StyleFormatCondition condition = new StyleFormatCondition();
            this.colStatus = new GridColumn();
            this.wcImport = new WizardControl();
            this.cheIsUpdate = new CheckEdit();
            this.lcSheet = new LayoutControl();
            this.cboSheet = new ComboBoxEdit();
            this.layoutControlGroup1 = new LayoutControlGroup();
            this.layoutControlItem1 = new LayoutControlItem();
            this.wpSelectFile = new WelcomeWizardPage();
            this.lbLinkFile = new LabelControl();
            this.lbLinkFileDecription = new LabelControl();
            this.txtFilePath = new ButtonEdit();
            this.lbFilePathDescription = new LabelControl();
            this.wpProcessPage = new DevExpress.XtraWizard.WizardPage();
            this.lbDataRow = new LabelControl();
            this.lbProgressDescription = new LabelControl();
            this.mqProgress = new MarqueeProgressBarControl();
            this.wpFinish = new CompletionWizardPage();
            this.gcMessage = new GridControl();
            this.gbMessage = new GridView();
            this.colMessage = new GridColumn();
            this.lbFix = new LinkLabel();
            this.lbFinishDescription = new LabelControl();
            this.lbMessage = new LabelControl();
            this.wpSelectField = new DevExpress.XtraWizard.WizardPage();
            this.gcList = new GridControl();
            this.gbList = new GridView();
            this.colFieldName = new GridColumn();
            this.colSelectField = new GridColumn();
            this.repSelectField = new RepositoryItemComboBox();
            this.wcImport.BeginInit();
            this.wcImport.SuspendLayout();
            this.cheIsUpdate.Properties.BeginInit();
            this.lcSheet.BeginInit();
            this.lcSheet.SuspendLayout();
            this.cboSheet.Properties.BeginInit();
            this.layoutControlGroup1.BeginInit();
            this.layoutControlItem1.BeginInit();
            this.wpSelectFile.SuspendLayout();
            this.txtFilePath.Properties.BeginInit();
            this.wpProcessPage.SuspendLayout();
            this.mqProgress.Properties.BeginInit();
            this.wpFinish.SuspendLayout();
            this.gcMessage.BeginInit();
            this.gbMessage.BeginInit();
            this.wpSelectField.SuspendLayout();
            this.gcList.BeginInit();
            this.gbList.BeginInit();
            this.repSelectField.BeginInit();
            base.SuspendLayout();
            this.colStatus.Caption = "Trạng th\x00e1i";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.wcImport.CancelText = "Tho\x00e1t";
            this.wcImport.Controls.Add(this.cheIsUpdate);
            this.wcImport.Controls.Add(this.lcSheet);
            this.wcImport.Controls.Add(this.wpSelectFile);
            this.wcImport.Controls.Add(this.wpProcessPage);
            this.wcImport.Controls.Add(this.wpFinish);
            this.wcImport.Controls.Add(this.wpSelectField);
            this.wcImport.FinishText = "&Ho\x00e0n Th\x00e0nh";
            this.wcImport.HelpText = "&Trợ Gi\x00fap";
            this.wcImport.Name = "wcImport";
            this.wcImport.NextText = "&Tiếp Tục >";
            this.wcImport.Pages.AddRange(new BaseWizardPage[] { this.wpSelectFile, this.wpSelectField, this.wpProcessPage, this.wpFinish });
            this.wcImport.PreviousText = "< &Trở Lại";
            this.wcImport.Text = "C\x00e1c bước nhập danh s\x00e1ch * từ tập tin excel";
            this.wcImport.WizardStyle = WizardStyle.WizardAero;
            this.wcImport.SelectedPageChanged += new WizardPageChangedEventHandler(this.wcImport_SelectedPageChanged);
            this.wcImport.NextClick += new WizardCommandButtonClickEventHandler(this.wcImport_NextClick);
            this.cheIsUpdate.Location = new Point(0x26, 0x131);
            this.cheIsUpdate.Name = "cheIsUpdate";
            this.cheIsUpdate.Properties.Caption = "Cập nhật nếu tồn tại";
            this.cheIsUpdate.Size = new Size(0x105, 0x13);
            this.cheIsUpdate.TabIndex = 15;
            this.cheIsUpdate.Visible = false;
            this.lcSheet.Controls.Add(this.cboSheet);
            this.lcSheet.Location = new Point(0x138, 0x3a);
            this.lcSheet.Name = "lcSheet";
            this.lcSheet.Root = this.layoutControlGroup1;
            this.lcSheet.Size = new Size(0x8e, 0x1c);
            this.lcSheet.TabIndex = 10;
            this.lcSheet.Text = "layoutControl1";
            this.lcSheet.Click += new EventHandler(this.layoutControl1_Click);
            this.cboSheet.Location = new Point(0x3d, 2);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboSheet.Size = new Size(0x4f, 20);
            this.cboSheet.StyleController = this.lcSheet;
            this.cboSheet.TabIndex = 4;
            this.cboSheet.SelectedIndexChanged += new EventHandler(this.cboSheet_SelectedIndexChanged);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new BaseLayoutItem[] { this.layoutControlItem1 });
            this.layoutControlGroup1.Location = new Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new Size(0x8e, 0x1c);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlItem1.Control = this.cboSheet;
            this.layoutControlItem1.CustomizationFormText = "Chọn sheet";
            this.layoutControlItem1.Location = new Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new Size(0x8e, 0x1c);
            this.layoutControlItem1.Text = "Chọn sheet";
            this.layoutControlItem1.TextSize = new Size(0x37, 13);
            this.wpSelectFile.Controls.Add(this.lbLinkFile);
            this.wpSelectFile.Controls.Add(this.lbLinkFileDecription);
            this.wpSelectFile.Controls.Add(this.txtFilePath);
            this.wpSelectFile.Controls.Add(this.lbFilePathDescription);
            this.wpSelectFile.Name = "wpSelectFile";
            this.wpSelectFile.Size = new Size(0x1ab, 0xae);
            this.wpSelectFile.Text = "Lựa chọn tập tin excel";
            this.lbLinkFile.AllowHtmlString = true;
            this.lbLinkFile.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Underline);
            this.lbLinkFile.Appearance.ForeColor = Color.Blue;
            this.lbLinkFile.Appearance.Options.UseFont = true;
            this.lbLinkFile.Appearance.Options.UseForeColor = true;
            this.lbLinkFile.Appearance.Options.UseTextOptions = true;
            this.lbLinkFile.Appearance.TextOptions.Trimming = Trimming.EllipsisPath;
            this.lbLinkFile.Appearance.TextOptions.VAlignment = VertAlignment.Top;
            this.lbLinkFile.Appearance.TextOptions.WordWrap = WordWrap.NoWrap;
            this.lbLinkFile.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbLinkFile.Cursor = Cursors.Hand;
            this.lbLinkFile.Location = new Point(3, 140);
            this.lbLinkFile.Name = "lbLinkFile";
            this.lbLinkFile.Size = new Size(0x19d, 0x1f);
            this.lbLinkFile.TabIndex = 15;
            this.lbLinkFile.Text = @"D:\Project\Source (Winform)\HRM\ERP.PMQLNS.V1600\Vssoft.HumanResource\Bin\Import\*.xls";
            this.lbLinkFile.Click += new EventHandler(this.lbLinkFile_Click);
            this.lbLinkFileDecription.AllowHtmlString = true;
            this.lbLinkFileDecription.Appearance.Options.UseTextOptions = true;
            this.lbLinkFileDecription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.lbLinkFileDecription.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbLinkFileDecription.Location = new Point(4, 0x6d);
            this.lbLinkFileDecription.Name = "lbLinkFileDecription";
            this.lbLinkFileDecription.Size = new Size(410, 0x19);
            this.lbLinkFileDecription.TabIndex = 15;
            this.lbLinkFileDecription.Text = "Mở tập tin <b><i>*.xls</i></b> trong thư mục <b>ImportFile</b> tại ổ đĩa c\x00e0i đặt hoặc nhấp v\x00e0o li\x00ean kết sau để xem tập tin mẫu:";
            this.txtFilePath.Location = new Point(3, 0x45);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Undo, "", -1, true, true, false, ImageLocation.MiddleCenter, null, new KeyShortcut(Keys.None), appearance, "Sử dụng tập tin mẫu để nạp dữ liệu", null, null, true), new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image) manager.GetObject("txtFilePath.Properties.Buttons"), new KeyShortcut(Keys.None), obj3, "Chọn tập tin để nạp dữ liệu", "Browse", null, true) });
            this.txtFilePath.Size = new Size(0x19b, 0x16);
            this.txtFilePath.TabIndex = 14;
            this.txtFilePath.TabStop = false;
            this.txtFilePath.ButtonClick += new ButtonPressedEventHandler(this.txtFilePath_ButtonClick);
            this.lbFilePathDescription.Appearance.Options.UseTextOptions = true;
            this.lbFilePathDescription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.lbFilePathDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbFilePathDescription.Location = new Point(3, 3);
            this.lbFilePathDescription.Name = "lbFilePathDescription";
            this.lbFilePathDescription.Size = new Size(0x19b, 0x2f);
            this.lbFilePathDescription.TabIndex = 0;
            this.lbFilePathDescription.Text = "Điều chỉnh tập tin cần import c\x00f3 cấu tr\x00fac c\x00e1c trường dữ liệu giống như tập tin excel mẫu (xem tập tin mẫu theo đường dẫn b\x00ean dưới). Đảm bảo dữ liệu cột m\x00e3 * kh\x00f4ng tr\x00f9ng lấp nhau.";
            this.wpProcessPage.Controls.Add(this.lbDataRow);
            this.wpProcessPage.Controls.Add(this.lbProgressDescription);
            this.wpProcessPage.Controls.Add(this.mqProgress);
            this.wpProcessPage.Name = "wpProcessPage";
            this.wpProcessPage.Size = new Size(0x1ab, 0xae);
            this.wpProcessPage.Text = "Tiến tr\x00ecnh thực hiện việc nạp dữ liệu";
            this.lbDataRow.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbDataRow.Location = new Point(4, 0x68);
            this.lbDataRow.Name = "lbDataRow";
            this.lbDataRow.Size = new Size(0x199, 0x36);
            this.lbDataRow.TabIndex = 2;
            this.lbProgressDescription.Appearance.Options.UseTextOptions = true;
            this.lbProgressDescription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.lbProgressDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbProgressDescription.Location = new Point(3, 4);
            this.lbProgressDescription.Name = "lbProgressDescription";
            this.lbProgressDescription.Size = new Size(0x19b, 0x2e);
            this.lbProgressDescription.TabIndex = 1;
            this.mqProgress.EditValue = 0;
            this.mqProgress.Location = new Point(3, 0x4f);
            this.mqProgress.Name = "mqProgress";
            this.mqProgress.Properties.ProgressViewStyle = ProgressViewStyle.Solid;
            this.mqProgress.Size = new Size(410, 0x12);
            this.mqProgress.TabIndex = 0;
            this.wpFinish.AllowBack = false;
            this.wpFinish.Controls.Add(this.gcMessage);
            this.wpFinish.Controls.Add(this.lbFix);
            this.wpFinish.Controls.Add(this.lbFinishDescription);
            this.wpFinish.Controls.Add(this.lbMessage);
            this.wpFinish.Name = "wpFinish";
            this.wpFinish.Size = new Size(0x1ab, 0xae);
            this.wpFinish.Text = "Ho\x00e0n th\x00e0nh";
            this.gcMessage.Location = new Point(0, 0x17);
            this.gcMessage.MainView = this.gbMessage;
            this.gcMessage.Name = "gcMessage";
            this.gcMessage.Size = new Size(0x1ab, 110);
            this.gcMessage.TabIndex = 5;
            this.gcMessage.ViewCollection.AddRange(new BaseView[] { this.gbMessage });
            this.gbMessage.Columns.AddRange(new GridColumn[] { this.colMessage, this.colStatus });
            condition.Appearance.ForeColor = Color.Red;
            condition.Appearance.Options.UseForeColor = true;
            condition.ApplyToRow = true;
            condition.Column = this.colStatus;
            condition.Condition = FormatConditionEnum.Equal;
            condition.Value1 = "1";
            this.gbMessage.FormatConditions.AddRange(new StyleFormatCondition[] { condition });
            this.gbMessage.GridControl = this.gcMessage;
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.OptionsView.EnableAppearanceEvenRow = true;
            this.gbMessage.OptionsView.RowAutoHeight = true;
            this.gbMessage.OptionsView.ShowColumnHeaders = false;
            this.gbMessage.OptionsView.ShowGroupPanel = false;
            this.gbMessage.OptionsView.ShowIndicator = false;
            this.colMessage.Caption = "Th\x00f4ng tin";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.OptionsColumn.AllowEdit = false;
            this.colMessage.OptionsColumn.ReadOnly = true;
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 0;
            this.lbFix.AutoSize = true;
            this.lbFix.BackColor = Color.Transparent;
            this.lbFix.Font = new Font("Tahoma", 9.75f);
            this.lbFix.Location = new Point(0x16b, 4);
            this.lbFix.Name = "lbFix";
            this.lbFix.Size = new Size(0x33, 0x10);
            this.lbFix.TabIndex = 3;
            this.lbFix.TabStop = true;
            this.lbFix.Text = "Sửa Lỗi";
            this.lbFix.Visible = false;
            this.lbFix.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lbFix_LinkClicked);
            this.lbFinishDescription.Appearance.Options.UseTextOptions = true;
            this.lbFinishDescription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.lbFinishDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbFinishDescription.Location = new Point(3, 0x8b);
            this.lbFinishDescription.Name = "lbFinishDescription";
            this.lbFinishDescription.Size = new Size(0x19b, 0x20);
            this.lbFinishDescription.TabIndex = 2;
            this.lbFinishDescription.Text = "Qu\x00e1 tr\x00ecnh import dữ liệu * đ\x00e3 ho\x00e0n tất. Nhấn n\x00fat ho\x00e0n th\x00e0nh ph\x00eda b\x00ean dưới để x\x00e1c nhận lại.";
            this.lbMessage.AllowHtmlString = true;
            this.lbMessage.Location = new Point(3, 5);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new Size(0xb6, 14);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "Th\x00e0nh c\x00f4ng: <color=red>0</color> mẫu tin. Lỗi: <color=red>0</color> mẫu tin.";
            this.wpSelectField.Controls.Add(this.gcList);
            this.wpSelectField.Name = "wpSelectField";
            this.wpSelectField.Size = new Size(0x1ab, 0xae);
            this.wpSelectField.Text = "Gh\x00e9p trường dữ liệu";
            this.gcList.Dock = DockStyle.Fill;
            this.gcList.Location = new Point(0, 0);
            this.gcList.MainView = this.gbList;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new RepositoryItem[] { this.repSelectField });
            this.gcList.Size = new Size(0x1ab, 0xae);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new BaseView[] { this.gbList });
            this.gbList.Columns.AddRange(new GridColumn[] { this.colFieldName, this.colSelectField });
            this.gbList.GridControl = this.gcList;
            this.gbList.Name = "gbList";
            this.gbList.OptionsView.ColumnAutoWidth = false;
            this.gbList.OptionsView.ShowGroupPanel = false;
            this.gbList.OptionsView.ShowIndicator = false;
            this.colFieldName.Caption = "Mặc định";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.OptionsColumn.AllowEdit = false;
            this.colFieldName.OptionsColumn.ReadOnly = true;
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 0;
            this.colFieldName.Width = 0x9f;
            this.colSelectField.Caption = "T\x00f9y chọn";
            this.colSelectField.ColumnEdit = this.repSelectField;
            this.colSelectField.FieldName = "SelectField";
            this.colSelectField.Name = "colSelectField";
            this.colSelectField.Visible = true;
            this.colSelectField.VisibleIndex = 1;
            this.colSelectField.Width = 0xc0;
            this.repSelectField.AutoHeight = false;
            this.repSelectField.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repSelectField.Name = "repSelectField";
            this.repSelectField.NullText = "<Vui l\x00f2ng chọn>";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1e7, 0x150);
            base.Controls.Add(this.wcImport);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "xfmBaseImport";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nhập Danh S\x00e1ch * Từ Tập Tin Excel";
            base.Load += new EventHandler(this.xfmImport_Load);
            this.wcImport.EndInit();
            this.wcImport.ResumeLayout(false);
            this.cheIsUpdate.Properties.EndInit();
            this.lcSheet.EndInit();
            this.lcSheet.ResumeLayout(false);
            this.cboSheet.Properties.EndInit();
            this.layoutControlGroup1.EndInit();
            this.layoutControlItem1.EndInit();
            this.wpSelectFile.ResumeLayout(false);
            this.txtFilePath.Properties.EndInit();
            this.wpProcessPage.ResumeLayout(false);
            this.mqProgress.Properties.EndInit();
            this.wpFinish.ResumeLayout(false);
            this.wpFinish.PerformLayout();
            this.gcMessage.EndInit();
            this.gbMessage.EndInit();
            this.wpSelectField.ResumeLayout(false);
            this.gcList.EndInit();
            this.gbList.EndInit();
            this.repSelectField.EndInit();
            base.ResumeLayout(false);
        }

        private void layoutControl1_Click(object sender, EventArgs e)
        {
        }

        private void lbFix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(this.txtFilePath.Text);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void lbLinkFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.lbLinkFile.Text);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void ProgressRow(string Progress)
        {
            this.lbDataRow.Text = Progress;
            this.lbDataRow.Refresh();
            this.mqProgress.Refresh();
        }

        private void RaiseSuccessEventHander()
        {
            if (this.Success != null)
            {
                this.Success(this);
            }
        }

        public void SuccessRow()
        {
            this.m_Success++;
        }

        public void SuccessRow(string Information)
        {
            this.m_Success++;
            this.gbMessage.AddNewRow();
            this.gbMessage.SetFocusedRowCellValue(this.colMessage, Information);
            this.gbMessage.SetFocusedRowCellValue(this.colStatus, "0");
        }

        private void txtFilePath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                OpenFileDialog dialog = new OpenFileDialog {
                    Filter = "Excel File(*.xls,*.xlsx)|*.xls;*.xlsx",
                    FilterIndex = 0
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtFilePath.Text = dialog.FileName;
                }
            }
            else
            {
                this.txtFilePath.Text = this.lbLinkFile.Text;
            }
        }

        private void wcImport_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            this.m_Success = 0;
            this.m_Error = 0;
            if (e.Page == this.wpSelectFile)
            {
                if (this.txtFilePath.Text != "")
                {
                    this.FillSheet();
                }
                else
                {
                    XtraMessageBox.Show("Vui l\x00f2ng chọn đường dẫn đến tập tin dữ liệu!", "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (e.Page == this.wpSelectField)
            {
                if (!this.m_IsFieldFull)
                {
                    XtraMessageBox.Show("Vui l\x00f2ng chọn đầy đủ th\x00f4ng tin cho c\x00e1c trường!", "Th\x00f4ng B\x00e1o");
                }
                else
                {
                    this.wcImport.SelectedPage = this.wpProcessPage;
                    this.Refresh();
                    this.CreateNullMessage();
                    this.Import();
                    this.RaiseSuccessEventHander();
                }
            }
        }

        private void wcImport_SelectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            this.lcSheet.Visible = false;
            if ((e.Page == this.wpSelectField) && (e.Direction == Direction.Forward))
            {
                this.lcSheet.Visible = true;
                if (this.txtFilePath.Text == "")
                {
                    this.wcImport.SelectedPage = this.wpSelectFile;
                }
            }
            if (((e.Page == this.wpProcessPage) && (e.Direction == Direction.Forward)) && !this.m_IsFieldFull)
            {
                this.wcImport.SelectedPage = this.wpSelectField;
            }
            if ((e.Page == this.wpProcessPage) && (e.Direction == Direction.Backward))
            {
                this.wcImport.SelectedPage = this.wpSelectField;
            }
        }

        private void xfmImport_Load(object sender, EventArgs e)
        {
        }

        private void xfmImport_Success(object sender)
        {
            this.wcImport.SelectedPage = this.wpFinish;
            this.lbMessage.Text = string.Concat(new object[] { "Th\x00e0nh c\x00f4ng: <color=red>", this.m_Success, "</color> mẫu tin. Lỗi: <color=red>", this.m_Error, "</color> mẫu tin." });
            if (this.m_Error > 0)
            {
                this.lbFix.Visible = true;
            }
        }

        public delegate void SuccessEventHander(object sender);
    }
}

