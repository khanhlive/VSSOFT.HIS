namespace Vssoft.Common.Report
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Alerter;
    using DevExpress.XtraEditors;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraPrinting.Control;
    using DevExpress.XtraPrinting.Preview;
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraReports.UserDesigner;
    using Vssoft.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using DevExpress.DocumentView;

    public sealed class XucBaseReportControls : xucBase
    {
        private readonly PrintBarManager _fPrintBarManager;
        private readonly XtraReport _fReport;
        private AlertControl ac;
        private Bar bar1;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarButtonItem bbiDesign;
        private BarManager bm;
        private BarButtonItem btnPreviewForm;
        private IContainer components = null;
        private const string FileName = "";
        private DevExpress.Utils.ImageCollection imageCollection2;
        private PanelControl plButton;
        private PanelControl plReportControl;
        private PanelControl plTop;
        private PrintControl printControl;
        private PrintingSystem printingSystem;

        public XucBaseReportControls(XtraReport fReport)
        {
            this.InitializeComponent();
            base.alc.FormLocation = AlertFormLocation.BottomRight;
            this.printingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
            if (this._fPrintBarManager != null)
            {
                this._fPrintBarManager.Dispose();
            }
            this._fPrintBarManager = this.CreatePrintBarManager(this.printControl);
            this._fPrintBarManager.PreviewBar.AddItem(this.btnPreviewForm).BeginGroup = true;
            this._fPrintBarManager.PreviewBar.AddItem(this.bbiDesign).BeginGroup = true;
            CreateReport();
            this._fReport = fReport;
        }

        private void BbiDesignItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._fReport != null)
            {
                this._fReport.ShowDesignerDialog();
            }
            string reportPath = Vssoft.Common.Report.Helper.GetReportPath(this._fReport, "sav");
            if (this._fReport != null)
            {
                this._fReport.PrintingSystem.ExecCommand(PrintingSystemCommand.StopPageBuilding);
                this._fReport.SaveLayout(reportPath);
            }
            using (XtraReport report = XtraReport.FromFile(reportPath, true))
            {
                XRDesignFormExBase designForm = new CustomDesignForm();
                designForm.OpenReport(report);
                designForm.FileName = "";
                ShowDesignerForm(designForm, base.FindForm());
                if ((designForm.FileName != "") && File.Exists(designForm.FileName))
                {
                    File.Copy(designForm.FileName, "", true);
                }
                designForm.OpenReport((XtraReport) null);
                designForm.Dispose();
            }
            if (File.Exists(""))
            {
                if (this._fReport != null)
                {
                    this._fReport.LoadLayout("");
                }
                File.Delete("");
                if (this._fReport != null)
                {
                    this._fReport.CreateDocument(true);
                }
            }
            this.ShowParameters();
            File.Delete(reportPath);
            InitializeControls();
        }

        private void BtnPreviewFormItemClick(object sender, ItemClickEventArgs e)
        {
            if (this._fReport != null)
            {
                this._fReport.ShowPreview();
            }
        }

        private PrintBarManager CreatePrintBarManager(PrintControl pc)
        {
            PrintBarManager manager = new PrintBarManager {
                Form = this.printControl
            };
            manager.Initialize(pc);
            manager.MainMenu.Visible = false;
            manager.AllowCustomization = false;
            return manager;
        }

        private static void CreateReport()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(XucBaseReportControls));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipTitleItem item2 = new ToolTipTitleItem();
            ToolTipItem item3 = new ToolTipItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.plButton = new PanelControl();
            this.plReportControl = new PanelControl();
            this.printControl = new PrintControl();
            this.printingSystem = new PrintingSystem(this.components);
            this.plTop = new PanelControl();
            this.bm = new BarManager(this.components);
            this.bar1 = new Bar();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.btnPreviewForm = new BarButtonItem();
            this.bbiDesign = new BarButtonItem();
            this.ac = new AlertControl(this.components);
            this.imageCollection2.BeginInit();
            this.plButton.BeginInit();
            this.plReportControl.BeginInit();
            this.plReportControl.SuspendLayout();
            ((ISupportInitialize) this.printingSystem).BeginInit();
            this.plTop.BeginInit();
            this.bm.BeginInit();
            base.SuspendLayout();
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection2.ImageStream");
            this.plButton.Dock = DockStyle.Bottom;
            this.plButton.Location = new Point(0, 0x1fc);
            this.plButton.Name = "plButton";
            this.plButton.Size = new Size(0x39d, 0x1c);
            this.plButton.TabIndex = 80;
            this.plButton.Visible = false;
            this.plReportControl.Controls.Add(this.printControl);
            this.plReportControl.Dock = DockStyle.Fill;
            this.plReportControl.Location = new Point(0, 60);
            this.plReportControl.Name = "plReportControl";
            this.plReportControl.Size = new Size(0x39d, 0x1c0);
            this.plReportControl.TabIndex = 0x51;
            this.printControl.BackColor = Color.Empty;
            this.printControl.Dock = DockStyle.Fill;
            this.printControl.ForeColor = Color.Empty;
            this.printControl.IsMetric = false;
            this.printControl.Location = new Point(2, 2);
            this.printControl.Name = "printControl";
            this.printControl.PageBorderVisibility = PageBorderVisibility.AllWithoutSelection;
            this.printControl.PrintingSystem = this.printingSystem;
            this.printControl.Size = new Size(0x399, 0x1bc);
            this.printControl.TabIndex = 2;
            this.printControl.TabStop = false;
            this.printControl.TooltipFont = new Font("Tahoma", 8.25f);
            this.plTop.Dock = DockStyle.Top;
            this.plTop.Location = new Point(0, 0x18);
            this.plTop.Name = "plTop";
            this.plTop.Size = new Size(0x39d, 0x24);
            this.plTop.TabIndex = 0x4f;
            this.plTop.Visible = false;
            this.bm.AutoSaveInRegistry = true;
            this.bm.Bars.AddRange(new Bar[] { this.bar1 });
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.Form = this;
            this.bm.Images = this.imageCollection2;
            this.bm.Items.AddRange(new BarItem[] { this.btnPreviewForm, this.bbiDesign });
            this.bm.LargeImages = this.imageCollection2;
            this.bm.MaxItemId = 2;
            this.bm.RegistryPath = @"HKEY_CURRENT_USER\Software\Perfect Software\Perfect Stock Management";
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            this.bar1.Visible = false;
            this.btnPreviewForm.Caption = "T\x00e1ch Ra";
            this.btnPreviewForm.Glyph = (Image) manager.GetObject("btnPreviewForm.Glyph");
            this.btnPreviewForm.Id = 0;
            this.btnPreviewForm.Name = "btnPreviewForm";
            item.Text = "Chức năng n\x00e0y gi\x00fap bạn t\x00e1ch b\x00e1o c\x00e1o đang xem ra một cửa sổ kh\x00e1c.";
            tip.Items.Add(item);
            this.btnPreviewForm.SuperTip = tip;
            this.btnPreviewForm.ItemClick += new ItemClickEventHandler(this.BtnPreviewFormItemClick);
            this.bbiDesign.Caption = "Thiết Kế";
            this.bbiDesign.Id = 1;
            this.bbiDesign.ImageIndex = 5;
            this.bbiDesign.Name = "bbiDesign";
            item2.Text = "Thiết Kế";
            item3.LeftIndent = 6;
            item3.Text = "Đ\x00e2y l\x00e0 chức năng gi\x00fap ch\x00fang ta tự thiết kế lại trang b\x00e1o c\x00e1o hiện tại, bạn c\x00f3 thể lưu lại v\x00e0 bạn c\x00f3 thể sử dụng b\x00e1o c\x00e1o cho c\x00f4ng việc sau n\x00e0y. ";
            tip2.Items.Add(item2);
            tip2.Items.Add(item3);
            this.bbiDesign.SuperTip = tip2;
            this.bbiDesign.ItemClick += new ItemClickEventHandler(this.BbiDesignItemClick);
            this.ac.AllowHtmlText = true;
            this.ac.AppearanceText.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ac.AppearanceText.Options.UseFont = true;
            this.ac.AutoFormDelay = 0x1388;
            this.ac.FormLocation = AlertFormLocation.TopLeft;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.plReportControl);
            base.Controls.Add(this.plButton);
            base.Controls.Add(this.plTop);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "XucBaseReportControls";
            base.Size = new Size(0x39d, 0x218);
            this.imageCollection2.EndInit();
            this.plButton.EndInit();
            this.plReportControl.EndInit();
            this.plReportControl.ResumeLayout(false);
            ((ISupportInitialize) this.printingSystem).EndInit();
            this.plTop.EndInit();
            this.bm.EndInit();
            base.ResumeLayout(false);
        }

        private static void InitializeControls()
        {
        }

        private static void ShowDesignerForm(Form designForm, Form parentForm)
        {
            designForm.MinimumSize = parentForm.MinimumSize;
            if (parentForm.WindowState == FormWindowState.Normal)
            {
                designForm.Bounds = parentForm.Bounds;
            }
            designForm.WindowState = parentForm.WindowState;
            parentForm.Visible = false;
            designForm.ShowDialog();
            parentForm.Visible = true;
        }

        private void ShowParameters()
        {
            this.printingSystem.ExecCommand(PrintingSystemCommand.Parameters, new object[] { true });
        }
    }
}

