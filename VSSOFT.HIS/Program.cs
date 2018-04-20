using DevExpress.Skins;
using DevExpress.UserSkins;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Common.Common.Class;
using Vssoft.HumanResource.DS;

namespace Vssoft.His
{
    //internal class MyApp: WindowsFormsApplicationBase
    //{
    //    private static MyApp _myApp;
    //    [DebuggerStepThrough]
    //    public MyApp() : base(AuthenticationMode.Windows)
    //    {
    //        base.IsSingleInstance = true;
    //        base.EnableVisualStyles = true;
    //        base.SaveMySettingsOnExit = true;
    //        base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    //    }
    //    [STAThread]
    //    static void Main(string[] args)
    //    {
    //        //Application.EnableVisualStyles();
    //        //Application.SetCompatibleTextRenderingDefault(false);
    //        Options.FormLoading.SetProgressValue(1,  "Đang khởi động phần mềm...");
    //        //SqlHelper.HideError = false;
    //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
    //        Thread.Sleep(2000);
    //        dsUPDATE supdate = new dsUPDATE();
    //        supdate.UPDATE.AddUPDATERow("03a208c9-59c4-4e81-9e24-3322d0cab4ca", "MyAssembly.AssemblyTitle", "MyAssembly.AssemblyVersion"," MyAssembly.AssemblyVersion", 0, "http://update.perfect.com.vn/QLNS/updateinfo.xml", 0xbb8, "Standard", System.Windows.Forms.Application.StartupPath);
    //        supdate.KillProcess.AddKillProcessRow("Perfect.Data");
    //        supdate.KillProcess.AddKillProcessRow("Perfect.Data.Config");
    //        supdate.KillProcess.AddKillProcessRow("PM.QLNS");
    //        supdate.KillProcess.AddKillProcessRow("Perfect.License");
    //        supdate.WriteXml(System.Windows.Forms.Application.StartupPath + @"\updateinfo.xml");
    //        Options.FormLoading.SetProgressValue(5, "Đang nạp giao diện...");
    //        BonusSkins.Register();
    //        SkinManager.EnableFormSkins();
    //        Thread.Sleep(2000);
    //        Options.FormLoading.SetProgressValue(15,  "Đang thiết lập tham số chương tr\x00ecnh...");
    //        Thread.Sleep(2000);
    //        Options.FormLoading.SetProgressValue(20,  "Đang thiết lập shortcut cho phần mềm...");
    //        Options.FormLoading.SetProgressValue(0x19,  "Đang t\x00ecm dữ liệu...");
    //        Options.FormLoading.Hide();

    //        BonusSkins.Register();
    //        SkinManager.EnableFormSkins();

    //        _myApp = new MyApp();
    //        _myApp.Run(args);
    //        //Application.Run(new frmMain());
    //    }
    //    [DebuggerStepThrough]
    //    protected override void OnCreateMainForm()
    //    {
    //        base.MainForm = new frmMain();
    //    }

    //    internal static MyApp Application =>
    //        _myApp;
        
    //}
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Options.FormLoading.SetProgressValue(1, "Đang nạp dữ liệu...");
                Options.FormLoading.SetProgressValue(20, "Đang nạp giao diện...");
                Options.FormLoading.SetProgressValue(40, "Đang thiết lập tham số...");
                Options.FormLoading.SetProgressValue(80, "Đang tạo dữ liệu...");
                Thread.Sleep(1000);
                Options.FormLoading.Hide();
                Data.Helper.SqlHelper.ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalAdo"].ConnectionString;
                log.Info(string.Format("Start Program."));
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                Application.Run(new frmMain());
            }
            catch (Exception exception)
            {
                log.Error("Khởi động chương trình", exception);
            }
            
        }
    }
}
