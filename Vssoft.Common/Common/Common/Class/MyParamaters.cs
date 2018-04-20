// C:\Program Files (x86)\Perfect Software\Perfect HRM 2012\Perfect.Common.dll
// Perfect.Common, Version=3.0.6.3, Culture=neutral, PublicKeyToken=0907d8af90186095

using System.Runtime.CompilerServices;

namespace Vssoft.Common.Common.Class
{
    public class MyParamaters
    {
        private static string _mUiLanguage;
        private static string _mReportLanguage;
        private static string _mReportLocalization;
        private static string _mLocalization;
        private static string _mOsName;

        public static string UiLanguage
        {
            get
            {
                return MyParamaters._mUiLanguage;
            }

            set
            {
                MyParamaters._mUiLanguage = value;
            }
        }

        public static string ReportLanguage
        {
            get
            {
                return MyParamaters._mReportLanguage;
            }

            set
            {
                MyParamaters._mReportLanguage = value;
            }
        }

        public static string ReportLocalization
        {
            get
            {
                return MyParamaters._mReportLocalization;
            }

            set
            {
                MyParamaters._mReportLocalization = value;
            }
        }

        public static string Localization
        {
            get
            {
                return MyParamaters._mLocalization;
            }

            set
            {
                MyParamaters._mLocalization = value;
            }
        }

        public static bool IsCreateShortcut
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsAutoUpdate
        {
            get;
            set;
        }

        public static string OsName
        {
            get
            {
                return MyParamaters._mOsName;
            }

            set
            {
                MyParamaters._mOsName = value;
            }
        }

        public static bool IsDefault
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }
    
    public static bool IsClearData
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsClearHistory
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsShowError
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsResetLayout
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsSetHomePage
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsSimple
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsShowWarning
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsPacket
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsClassic
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool Offline
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsSale
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsBarCafe
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        public static bool IsItemStock
        {
            [CompilerGenerated]
            get;

            [CompilerGenerated]
            set;
        }

        static MyParamaters()
        {
            MyParamaters._mUiLanguage = "VN";
            MyParamaters._mReportLanguage = "VN";
            MyParamaters._mReportLocalization = "vi-VN";
            MyParamaters._mLocalization = "vi-VN";
            MyParamaters._mOsName = "";
            MyParamaters.IsSetHomePage = true;
        }

        public MyParamaters()
        {
        }
    }
}