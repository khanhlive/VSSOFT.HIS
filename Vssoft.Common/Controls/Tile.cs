namespace Vssoft.Common.Controls
{
    using DevExpress.Utils;
    using DevExpress.Utils.Design;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class Tile : UserControl
    {
        private IContainer components = null;
        private string m_Description = "Description";
        private int m_SmallImageIndex;
        private object m_SmallImageList;
        private string m_Title = "Title";
        private PanelControl pnContent;
        private PictureEdit ptIcon;
        private Timer timer1;
        private Timer timer2;
        private LabelControl txtDescription;
        private LabelControl txtTitle;

        public event ItemClickedHander ItemClicked;

        public Tile()
        {
            this.InitializeComponent();
            this.pnContent.Height = 80;
            this.Init();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBorderPanel()
        {
        }

        private void Init()
        {
            this.txtTitle.Text = this.m_Title;
            this.txtDescription.Text = this.m_Description;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.pnContent = new PanelControl();
            this.txtDescription = new LabelControl();
            this.txtTitle = new LabelControl();
            this.ptIcon = new PictureEdit();
            this.timer1 = new Timer(this.components);
            this.timer2 = new Timer(this.components);
            this.pnContent.BeginInit();
            this.pnContent.SuspendLayout();
            this.ptIcon.Properties.BeginInit();
            base.SuspendLayout();
            this.pnContent.Appearance.BackColor = Color.AliceBlue;
            this.pnContent.Appearance.Options.UseBackColor = true;
            this.pnContent.Controls.Add(this.txtDescription);
            this.pnContent.Controls.Add(this.txtTitle);
            this.pnContent.Controls.Add(this.ptIcon);
            this.pnContent.Cursor = Cursors.Hand;
            this.pnContent.Dock = DockStyle.Bottom;
            this.pnContent.Location = new Point(0, 0x1c);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new Size(0xd8, 0xbc);
            this.pnContent.TabIndex = 0;
            this.pnContent.MouseLeave += new EventHandler(this.Tile_MouseLeave);
            this.pnContent.Click += new EventHandler(this.Tile_Click);
            this.pnContent.MouseEnter += new EventHandler(this.panelControl1_MouseEnter);
            this.txtDescription.AllowHtmlString = true;
            this.txtDescription.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.txtDescription.Appearance.Options.UseTextOptions = true;
            this.txtDescription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.txtDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.txtDescription.Location = new Point(0x11, 0x51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new Size(0xb9, 0x5b);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Description";
            this.txtDescription.MouseLeave += new EventHandler(this.Tile_MouseLeave);
            this.txtDescription.Click += new EventHandler(this.Tile_Click);
            this.txtDescription.MouseEnter += new EventHandler(this.labelControl2_MouseEnter);
            this.txtTitle.AllowHtmlString = true;
            this.txtTitle.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.txtTitle.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.txtTitle.Appearance.Options.UseFont = true;
            this.txtTitle.Appearance.Options.UseTextOptions = true;
            this.txtTitle.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.txtTitle.AutoSizeMode = LabelAutoSizeMode.None;
            this.txtTitle.Location = new Point(0x11, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(0x79, 0x36);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "Title";
            this.txtTitle.MouseLeave += new EventHandler(this.Tile_MouseLeave);
            this.txtTitle.Click += new EventHandler(this.Tile_Click);
            this.txtTitle.MouseEnter += new EventHandler(this.labelControl1_MouseEnter);
            this.ptIcon.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.ptIcon.Location = new Point(0x93, 13);
            this.ptIcon.Name = "ptIcon";
            this.ptIcon.Properties.NullText = "[Icon]";
            this.ptIcon.Properties.ReadOnly = true;
            this.ptIcon.Properties.ShowMenu = false;
            this.ptIcon.Size = new Size(0x37, 0x36);
            this.ptIcon.TabIndex = 0;
            this.ptIcon.MouseEnter += new EventHandler(this.pictureEdit1_MouseEnter);
            this.ptIcon.MouseLeave += new EventHandler(this.Tile_MouseLeave);
            this.ptIcon.Click += new EventHandler(this.Tile_Click);
            this.timer1.Interval = 1;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer2.Interval = 1;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Transparent;
            base.Controls.Add(this.pnContent);
            base.Name = "Tile";
            base.Size = new Size(0xd8, 0xd8);
            base.Load += new EventHandler(this.Tile_Load);
            base.MouseLeave += new EventHandler(this.Tile_MouseLeave);
            base.Paint += new PaintEventHandler(this.Tile_Paint);
            base.Click += new EventHandler(this.Tile_Click);
            base.MouseEnter += new EventHandler(this.Tile_MouseEnter);
            this.pnContent.EndInit();
            this.pnContent.ResumeLayout(false);
            this.ptIcon.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void labelControl1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(EventArgs.Empty);
        }

        private void labelControl2_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(EventArgs.Empty);
        }

        public void MouseUEnter()
        {
            this.timer1.Enabled = true;
            this.timer2.Enabled = false;
        }

        public void MouseULeave()
        {
            this.timer1.Enabled = false;
            this.timer2.Enabled = true;
        }

        private void panelControl1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(EventArgs.Empty);
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(EventArgs.Empty);
        }

        private void RaiseItemClickedHander()
        {
            if (this.ItemClicked != null)
            {
                this.ItemClicked(this);
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            this.RaiseItemClickedHander();
        }

        private void Tile_Load(object sender, EventArgs e)
        {
        }

        private void Tile_MouseEnter(object sender, EventArgs e)
        {
            this.MouseUEnter();
        }

        private void Tile_MouseLeave(object sender, EventArgs e)
        {
            this.MouseULeave();
        }

        private void Tile_Paint(object sender, PaintEventArgs e)
        {
            if (this.m_SmallImageList != null)
            {
                this.ptIcon.Image = (this.m_SmallImageList as DevExpress.Utils.ImageCollection).Images[this.m_SmallImageIndex];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((this.pnContent.Height + 40) <= base.Height)
            {
                this.pnContent.Height += 40;
            }
            else
            {
                this.pnContent.Height = base.Height;
                this.DrawBorderPanel();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((this.pnContent.Height - 40) >= 80)
            {
                this.pnContent.Height -= 40;
            }
            else
            {
                this.pnContent.Height = 80;
                this.DrawBorderPanel();
            }
        }

        public string Description
        {
            get => 
                this.m_Description;
            set
            {
                this.m_Description = value;
                this.txtDescription.Text = this.m_Description;
            }
        }

        [ImageList("SmallImageList"), Editor(typeof(ImageIndexesEditor), typeof(UITypeEditor)), DefaultValue(-1), Description("Gets or sets the index of the image displayed on the button.")]
        public int SmallImageIndex
        {
            get => 
                this.m_SmallImageIndex;
            set
            {
                this.m_SmallImageIndex = value;
            }
        }

        [Description("Gets or sets the source of images to be displayed within the button."), TypeConverter(typeof(ImageCollectionImagesConverter)), DefaultValue("")]
        public object SmallImageList
        {
            get => 
                this.m_SmallImageList;
            set
            {
                this.m_SmallImageList = value;
            }
        }

        public string Title
        {
            get => 
                this.m_Title;
            set
            {
                this.m_Title = value;
                this.txtTitle.Text = this.m_Title;
            }
        }

        public delegate void ItemClickedHander(object sender);
    }
}

