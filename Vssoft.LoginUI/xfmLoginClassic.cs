namespace Vssoft.Logonui
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using Vssoft.Common.Common.Class;
    using Vssoft.Common.UI;
    using Vssoft.Data.Helper;

    public class xfmLoginClassic : XtraForm
    {
        private bool _islogin = false;
        private string _mConnectString = "";
        private readonly string _serverParameters = (Application.StartupPath + @"\config.xml");
        private SimpleButton btnExit;
        private SimpleButton btnLogin;
        private SimpleButton btnOption;
        private CheckEdit chxRemember;
        private IContainer components = null;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        private LabelControl labelControl3;
        private LabelControl lbFirstLogin;
        private LabelControl lblWait;
        private LabelControl lbPassword;
        private LabelControl lbUserName;
        private LinkLabel llUpdate;
        private PictureEdit picLogon;
        private PanelControl pnUpdateContent;
        private int solanDangNhap = 0;
        private LoadingCircle spWait;
        private TextEdit txtPassword;
        private ComboBoxEdit txtUserName;

        public event AddUserEventHander AddUser;

        public event ErrorEventHander Error;

        public event FinishEventHander Finish;

        public event FirstEventHander First;

        public event LoginSuccessEventHander LoginSuccess;

        public event UserAddedEventHander UserAdded;

        public xfmLoginClassic()
        {
            this.InitializeComponent();
            this.InitMultiLanguages();
            this.AddUser = (AddUserEventHander) Delegate.Combine(this.AddUser, new AddUserEventHander(this.xfmLoginClassic_AddUser));
            this.UserAdded = (UserAddedEventHander) Delegate.Combine(this.UserAdded, new UserAddedEventHander(this.xfmLoginClassic_UserAdded));
            this.Text = "VSSOFT HIS";// "MyAssembly.AssemblyProduct";
            this.txtUserName.Focus();
            this.readRemember();
            this.CheckUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //MyLogin login = new MyLogin();
            //MyLogin.LoginDate = System.DateTime.Now;
            //this.btnLogin.Enabled = false;
            //if (this.txtUserName.Text.Trim() == "")
            //{
            //    this.txtUserName.ErrorText = "Bạn chưa nhập tài khoản!";
            //    this.Err.SetIconAlignment(this.txtUserName, ErrorIconAlignment.MiddleRight);
            //    this.btnLogin.Enabled = true;
            //    this.txtUserName.Focus();
            //    Cursor.Current = Cursors.Default;
            //}
            //else if (!this.CorrectConnection(SqlHelper.ConnectString))
            //{
            //    this.btnLogin.Enabled = true;
            //    Cursor.Current = Cursors.Default;
            //}
            //else
            //{
            //}
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            //new xfmDatabaseConfig().Show(this);
        }

        private void CheckUpdate()
        {
            string str = clsAllOption.CheckOption("Update");
            if (str != "")
            {
                if (str == "0")
                {
                    this.ShowUpdateStatus(false);
                }
                else if (str == "1")
                {
                    this.ShowUpdateStatus(true);
                }
            }
        }

        public bool CorrectConnection(string serverConnectionString)
        {
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            using (SqlConnection connection = new SqlConnection(serverConnectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                }
                catch
                {
                    XtraMessageBox.Show(this, "Kh\x00f4ng thể kết nối với m\x00e1y chủ.", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                finally
                {
                    Cursor.Current = current;
                }
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void GetUsers()
        {
            //DataTable list = new SYS_USER().GetList();
            //if (list != null)
            //{
            //    for (int i = 0; i < list.Rows.Count; i++)
            //    {
            //        if (list.Rows[i]["Group_ID"].ToString() != "employee")
            //        {
            //            this.RaiseAddUserEventHander(list.Rows[i]["UserName"].ToString());
            //        }
            //    }
            //}
            //this.RaiseUserAddedEventHander();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfmLoginClassic));
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbUserName = new DevExpress.XtraEditors.LabelControl();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.chxRemember = new DevExpress.XtraEditors.CheckEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnOption = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbFirstLogin = new DevExpress.XtraEditors.LabelControl();
            this.picLogon = new DevExpress.XtraEditors.PictureEdit();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.txtUserName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spWait = new Vssoft.Common.UI.LoadingCircle();
            this.lblWait = new DevExpress.XtraEditors.LabelControl();
            this.pnUpdateContent = new DevExpress.XtraEditors.PanelControl();
            this.llUpdate = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chxRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUpdateContent)).BeginInit();
            this.pnUpdateContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(150, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lbUserName
            // 
            this.lbUserName.Location = new System.Drawing.Point(87, 78);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(47, 13);
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "Tài Khoản";
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(87, 108);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(45, 13);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Mật Khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(148, 154);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // chxRemember
            // 
            this.chxRemember.Location = new System.Drawing.Point(147, 130);
            this.chxRemember.Name = "chxRemember";
            this.chxRemember.Properties.Caption = "Nhớ tài khoản và mật khẩu";
            this.chxRemember.Size = new System.Drawing.Size(181, 19);
            this.chxRemember.TabIndex = 2;
            this.chxRemember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(236, 154);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Kết Thúc";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(5, 154);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(81, 23);
            this.btnOption.TabIndex = 5;
            this.btnOption.Text = "Tuỳ Chọn";
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(149, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 16);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "ĐĂNG NHẬP";
            // 
            // lbFirstLogin
            // 
            this.lbFirstLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstLogin.Appearance.Options.UseFont = true;
            this.lbFirstLogin.Appearance.Options.UseTextOptions = true;
            this.lbFirstLogin.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbFirstLogin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbFirstLogin.Location = new System.Drawing.Point(104, 26);
            this.lbFirstLogin.Name = "lbFirstLogin";
            this.lbFirstLogin.Size = new System.Drawing.Size(214, 43);
            this.lbFirstLogin.TabIndex = 9;
            this.lbFirstLogin.Text = "Đăng nhập lần đầu tiên tài khoản: admin, mật khẩu:(để trống)";
            // 
            // picLogon
            // 
            this.picLogon.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLogon.EditValue = ((object)(resources.GetObject("picLogon.EditValue")));
            this.picLogon.Location = new System.Drawing.Point(7, 1);
            this.picLogon.Name = "picLogon";
            this.picLogon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogon.Properties.Appearance.Options.UseBackColor = true;
            this.picLogon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogon.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.picLogon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLogon.Size = new System.Drawing.Size(75, 71);
            this.picLogon.TabIndex = 10;
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "admin";
            this.txtUserName.Location = new System.Drawing.Point(150, 75);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserName.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtUserName_Properties_ButtonClick);
            this.txtUserName.Size = new System.Drawing.Size(168, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // spWait
            // 
            this.spWait.Active = false;
            this.spWait.Color = System.Drawing.Color.DarkGray;
            this.spWait.InnerCircleRadius = 10;
            this.spWait.Location = new System.Drawing.Point(10, 79);
            this.spWait.Name = "spWait";
            this.spWait.NumberSpoke = 16;
            this.spWait.OuterCircleRadius = 20;
            this.spWait.RotationSpeed = 150;
            this.spWait.Size = new System.Drawing.Size(58, 47);
            this.spWait.SpokeThickness = 6;
            this.spWait.TabIndex = 12;
            this.spWait.Text = "loadingCircle1";
            this.spWait.Value = 0;
            this.spWait.Visible = false;
            // 
            // lblWait
            // 
            this.lblWait.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblWait.Appearance.Options.UseFont = true;
            this.lblWait.Location = new System.Drawing.Point(12, 128);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(66, 13);
            this.lblWait.TabIndex = 13;
            this.lblWait.Text = "Vui lòng đợi...";
            this.lblWait.Visible = false;
            // 
            // pnUpdateContent
            // 
            this.pnUpdateContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnUpdateContent.Controls.Add(this.llUpdate);
            this.pnUpdateContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnUpdateContent.Location = new System.Drawing.Point(0, 153);
            this.pnUpdateContent.Name = "pnUpdateContent";
            this.pnUpdateContent.Size = new System.Drawing.Size(329, 30);
            this.pnUpdateContent.TabIndex = 14;
            this.pnUpdateContent.Visible = false;
            // 
            // llUpdate
            // 
            this.llUpdate.AutoSize = true;
            this.llUpdate.Location = new System.Drawing.Point(9, 8);
            this.llUpdate.Name = "llUpdate";
            this.llUpdate.Size = new System.Drawing.Size(261, 13);
            this.llUpdate.TabIndex = 0;
            this.llUpdate.TabStop = true;
            this.llUpdate.Text = "Bản cập nhật mới đã sẳn có! Nhấp vào đây để tải về!";
            this.llUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llUpdate_LinkClicked);
            // 
            // xfmLoginClassic
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 183);
            this.Controls.Add(this.pnUpdateContent);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.spWait);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.picLogon);
            this.Controls.Add(this.lbFirstLogin);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.chxRemember);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.txtPassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "xfmLoginClassic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xfmLoginClassic_FormClosing);
            this.Load += new System.EventHandler(this.xfmLoginClassic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chxRemember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUpdateContent)).EndInit();
            this.pnUpdateContent.ResumeLayout(false);
            this.pnUpdateContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitMultiLanguages()
        {
            this.Text = "Đăng nhập";
            this.btnLogin.Text = "Đăng Nhập";
            this.btnExit.Text =   "Kết Th\x00fac";
            this.btnOption.Text = "T\x00f9y Chọn";
            this.lbFirstLogin.Text =  "Đăng nhập lần đầu ti\x00ean t\x00e0i khoản: admin, mật khẩu:(để trống)";
            this.lblWait.Text = "Vui l\x00f2ng đợi...";
            this.lbUserName.Text = "T\x00e0i Khoản";
            this.lbPassword.Text = "Mật Khẩu";
            this.chxRemember.Text =  "Nhớ t\x00e0i khoản v\x00e0 mật khẩu";
        }

        private void llUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Update();
        }

        private void RaiseAddUserEventHander(string username)
        {
            AddUserEventHander addUser = this.AddUser;
            if (addUser != null)
            {
                addUser(this, username);
            }
        }

        private void RaiseErrorEventHander(string message)
        {
            if (this.Error != null)
            {
                this.Error(this, message);
            }
        }

        private void RaiseFinishEventHander(string connecstring)
        {
            if (this.Finish != null)
            {
                this.Finish(this, connecstring);
            }
        }

        private void RaiseFirstEventHander(string connectString)
        {
            if (this.First != null)
            {
                this.First(this, connectString);
            }
        }

        private void RaiseLoginSuccessEventHander()
        {
            if (this.LoginSuccess != null)
            {
                this.LoginSuccess(this);
            }
        }

        private void RaiseUserAddedEventHander()
        {
            UserAddedEventHander userAdded = this.UserAdded;
            if (userAdded != null)
            {
                userAdded(this);
            }
        }

        private string ReadCofig()
        {
            DataTable table = new DataTable("SERVER");
            table.Columns.Add("server");
            table.Columns.Add("auth");
            table.Columns.Add("user");
            table.Columns.Add("pass");
            table.Columns.Add("database");
            table.Columns.Add("ConnectString");
            SqlHelper helper = new SqlHelper();
            FileInfo info = new FileInfo(this._serverParameters);
            if (info.Exists)
            {
                DataSet set = new DataSet();
                set.Tables.Add(table);
                set.ReadXml(this._serverParameters, XmlReadMode.Auto);
                try
                {
                    if (set.Tables[0].Rows.Count > 0)
                    {
                        helper.Server = set.Tables[0].Rows[0]["server"].ToString();
                        helper.Authentication = Convert.ToInt32(set.Tables[0].Rows[0]["auth"]) == 1;
                        helper.UserID = set.Tables[0].Rows[0]["user"].ToString();
                        helper.Password = set.Tables[0].Rows[0]["pass"].ToString();
                        helper.Database = set.Tables[0].Rows[0]["database"].ToString();
                        helper.ConnectionString = set.Tables[0].Rows[0]["ConnectString"].ToString();
                        return helper.ConnectionString;
                    }
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.RaiseErrorEventHander(exception.Message);
                }
            }
            return "";
        }

        private void readRemember()
        {
            DataTable table = new DataTable("account");
            table.Columns.Add("user");
            table.Columns.Add("pass");
            FileInfo info = new FileInfo(Application.StartupPath + @"\account.xml");
            if (info.Exists)
            {
                this.chxRemember.Checked = true;
                DataSet set = new DataSet();
                set.Tables.Add(table);
                try
                {
                    set.ReadXml(Application.StartupPath + @"\account.xml");
                    if (set.Tables[0].Rows.Count > 0)
                    {
                        this.txtUserName.Text = set.Tables[0].Rows[0]["user"].ToString();
                        this.txtPassword.Text = set.Tables[0].Rows[0]["pass"].ToString();
                    }
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(this, exception.Message, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                if (this.txtPassword.Text != "")
                {
                    this.chxRemember.Checked = true;
                }
                else
                {
                    this.chxRemember.Checked = false;
                }
            }
        }

        public void SaveConfig(string server, int auth, string user, string pass, string database, string connecstring)
        {
            try
            {
                DataSet set = new DataSet();
                DataTable table = new DataTable("SERVER");
                table.Columns.Add("server");
                table.Columns.Add("auth");
                table.Columns.Add("user");
                table.Columns.Add("pass");
                table.Columns.Add("database");
                table.Columns.Add("ConnectString");
                table.Rows.Clear();
                table.Rows.Add(new object[] { server, database, connecstring });
                set.Tables.Add(table);
                set.WriteXml(this._serverParameters);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void saveNullRemember()
        {
            try
            {
                DataSet set = new DataSet();
                DataTable table = new DataTable("account");
                table.Columns.Add("user");
                table.Columns.Add("pass");
                table.Rows.Clear();
                table.Rows.Add(new object[] { this.txtUserName.Text, "" });
                set.Tables.Add(table);
                set.WriteXml(Application.StartupPath + @"\account.xml");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(this, exception.Message, "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void saveRemember()
        {
            try
            {
                DataSet set = new DataSet();
                DataTable table = new DataTable("account");
                table.Columns.Add("user");
                table.Columns.Add("pass");
                table.Rows.Clear();
                table.Rows.Add(new object[] { this.txtUserName.Text, this.txtPassword.Text });
                set.Tables.Add(table);
                set.WriteXml(Application.StartupPath + @"\account.xml");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(this, exception.Message, "Th\x00f4ng B\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ShowUpdateStatus(bool Show)
        {
            //if (Vssoft.Update.Process.CheckUpdate.CheckUpdateVersion())
            //{
            //    if (Show)
            //    {
            //        base.Height = 0xf4;
            //        this.pnUpdateContent.Visible = true;
            //    }
            //    else
            //    {
            //        this.Update();
            //    }
            //}
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void txtUserName_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ThreadStart start = null;
            if ((this.txtUserName.Properties.Items.Count == 0) && (e.Button.Index == 0))
            {
                this.spWait.Active = true;
                this.spWait.Visible = true;
                this.txtUserName.Enabled = false;
                this.lblWait.Visible = true;
                if (start == null)
                {
                    start = () => this.GetUsers();
                }
                new Thread(start).Start();
            }
        }

        private void Update()
        {
            try
            {
                //SYS_LOG.Insert("Cập Nhật Phần Mềm", "Thực Thi");
                Process.Start(Application.StartupPath + @"\OnlineUpdate.exe");
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void xfmLoginClassic_AddUser(object sender, string username)
        {
            if (this.txtUserName.InvokeRequired)
            {
                AddUserEventHander method = new AddUserEventHander(this.xfmLoginClassic_AddUser);
                base.Invoke(method, new object[] { sender, username });
            }
            else
            {
                this.txtUserName.Properties.Items.Add(username);
            }
        }

        private void xfmLoginClassic_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._islogin)
            {
                Environment.Exit(0);
            }
        }

        private void xfmLoginClassic_Load(object sender, EventArgs e)
        {
        }

        private void xfmLoginClassic_UserAdded(object sender)
        {
            if (this.txtUserName.InvokeRequired)
            {
                UserAddedEventHander method = new UserAddedEventHander(this.xfmLoginClassic_UserAdded);
                base.Invoke(method, new object[] { sender });
            }
            else
            {
                this.spWait.Active = false;
                this.spWait.Visible = false;
                this.txtUserName.Enabled = true;
                this.lblWait.Visible = false;
                this.txtUserName.SelectedIndex = 0;
            }
        }

        public string MConnectString =>
            this._mConnectString;

        public delegate void AddUserEventHander(object sender, string username);

        public delegate void ErrorEventHander(object sender, string message);

        public delegate void FinishEventHander(object sender, string connecstring);

        public delegate void FirstEventHander(object sender, string connectString);

        public delegate void LoginSuccessEventHander(object sender);

        public delegate void UserAddedEventHander(object sender);
    }
}

