namespace Vssoft.Common.Common.Class
{
    using DevExpress.Utils;
    using Vssoft.Common;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Threading;

    public class Options
    {
        private static XLoadingForm _LoadingForm = new XLoadingForm();
        private static string _mCaption = "Đang nạp dữ liệu ...";
        private static WaitDialogForm _mDlg;
        private static string _mFTitle = "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t...";

        static Options()
        {
            SoftId = "QLNS";
            TypeSoft = 0;
        }

        public static void Close()
        {
            CloseDialog();
        }

        public static void CloseDialog()
        {
            if (_mDlg != null)
            {
                _mDlg.FormClosing += new FormClosingEventHandler(Options.dlg_FormClosing);
                _mDlg.Close();
            }
        }

        public static void CreateWaitDialog()
        {
            CreateWaitDialog(Caption);
        }

        public static void CreateWaitDialog(string fCaption)
        {
            CreateWaitDialog(fCaption, Title);
        }

        public static void CreateWaitDialog(string fCaption, string fTitle)
        {
            Title = fTitle;
            if (_mDlg == null)
            {
                _mDlg = new WaitDialogForm(fCaption, fTitle);
            }
            _mDlg.AllowFormSkin = true;
        }

        private static void dlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mDlg = null;
        }

        ~Options()
        {
            if (_mDlg != null)
            {
                _mDlg.FormClosing += new FormClosingEventHandler(Options.dlg_FormClosing);
                _mDlg.Close();
            }
        }

        public static void HideDialog()
        {
            if (_mDlg != null)
            {
                _mDlg.Hide();
            }
        }

        public static void SetWaitDialogCaption()
        {
            SetWaitDialogCaption(Caption);
        }

        public static void SetWaitDialogCaption(string fCaption)
        {
            Caption = fCaption;
            if (_mDlg != null)
            {
                _mDlg.Visible = true;
                _mDlg.Caption = fCaption;
            }
            else
            {
                CreateWaitDialog();
            }
        }

        public static void Show()
        {
            SetWaitDialogCaption();
        }

        public static void Show(string fCaption)
        {
            SetWaitDialogCaption(fCaption);
        }

        public static string Caption
        {
            get => 
                _mCaption;
            set
            {
                _mCaption = value;
            }
        }

        public static XLoadingForm FormLoading
        {
            get => 
                _LoadingForm;
            set
            {
                _LoadingForm = value;
            }
        }

        public static string SoftId
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }

        public static string Title
        {
            get => 
                _mFTitle;
            set
            {
                _mFTitle = value;
            }
        }

        public static int TypeSoft
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }

        public class DateTime
        {
            private static Vssoft.Common.Common.Class.Options.FormatType _mDateFormatType = Vssoft.Common.Common.Class.Options.FormatType.Custom;
            private static string _mDateSaparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            private static int _mDayLength = 2;
            private static string _mFormatDate = "dd/MM/yyyy";
            private static int _mMonthLength = 2;
            private static int _mYearLength = 4;

            private static string GetDay(bool dateSaparator)
            {
                string str = "";
                for (int i = 0; i < _mDayLength; i++)
                {
                    str = str + "d";
                }
                if (dateSaparator)
                {
                    str = str + _mDateSaparator;
                }
                return str;
            }

            private static string GetMonth(bool dateSaparator)
            {
                string str = "";
                for (int i = 0; i < _mMonthLength; i++)
                {
                    str = str + "M";
                }
                if (dateSaparator)
                {
                    str = str + _mDateSaparator;
                }
                return str;
            }

            private static string GetYear(bool dateSaparator)
            {
                string str = "";
                for (int i = 0; i < _mYearLength; i++)
                {
                    str = str + "y";
                }
                if (dateSaparator)
                {
                    str = str + _mDateSaparator;
                }
                return str;
            }

            public static int DayLength
            {
                get => 
                    _mDayLength;
                set
                {
                    _mDayLength = value;
                }
            }

            public static string Format
            {
                get
                {
                    string day;
                    string month;
                    string year;
                    switch (_mDateFormatType)
                    {
                        case Vssoft.Common.Common.Class.Options.FormatType.Dmy:
                            day = GetDay(true);
                            month = GetMonth(true);
                            year = GetYear(false);
                            _mFormatDate = (day.Length == 1) ? "" : (day + ((month.Length == 1) ? "" : month) + year);
                            if (_mFormatDate.Trim() == string.Empty)
                            {
                                _mFormatDate = "dd/MM/yyyy";
                            }
                            return _mFormatDate;

                        case Vssoft.Common.Common.Class.Options.FormatType.Mdy:
                            day = GetDay(true);
                            month = GetMonth(true);
                            year = GetYear(false);
                            _mFormatDate = (month.Length == 1) ? "" : (month + ((day.Length == 1) ? "" : day) + year);
                            if (_mFormatDate.Trim() == string.Empty)
                            {
                                _mFormatDate = "MM/dd/yyyy";
                            }
                            return _mFormatDate;

                        case Vssoft.Common.Common.Class.Options.FormatType.Ymd:
                            day = GetDay(false);
                            month = GetMonth(true);
                            year = GetYear(true);
                            _mFormatDate = (year.Length == 1) ? "" : (year + ((month.Length == 1) ? "" : month) + day);
                            if (_mFormatDate.Trim() == string.Empty)
                            {
                                _mFormatDate = "yyyy/MM/dd";
                            }
                            return _mFormatDate;
                    }
                    return _mFormatDate;
                }
                set
                {
                    _mDateFormatType = Vssoft.Common.Common.Class.Options.FormatType.Custom;
                    _mFormatDate = value;
                }
            }

            public static string FormatString =>
                ("{0:" + Format + "}");

            public static Vssoft.Common.Common.Class.Options.FormatType FormatType
            {
                get => 
                    _mDateFormatType;
                set
                {
                    _mDateFormatType = value;
                }
            }

            public static int MonthLength
            {
                get => 
                    _mMonthLength;
                set
                {
                    _mMonthLength = value;
                }
            }

            public static string Saparator
            {
                get => 
                    _mDateSaparator;
                set
                {
                    _mDateSaparator = value;
                }
            }

            public static int YearLength
            {
                get => 
                    _mYearLength;
                set
                {
                    _mYearLength = value;
                }
            }
        }

        public enum FormatType
        {
            Custom,
            Dmy,
            Mdy,
            Ymd
        }

        public class Number
        {
            private static bool _mAutoRound = true;
            private static int _mDecimals = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalDigits;
            private static string _mDecimalSymbol = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            private static string _mDigitGroupSymbol = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
            private static string _mFormatNumber = "##,##0.###";
            private static string _mFrefixSymbol = "";
            private static string _mSuffixSymbol = "";

            public static bool AutoRound
            {
                get => 
                    _mAutoRound;
                set
                {
                    _mAutoRound = value;
                }
            }

            public static int Decimals
            {
                get => 
                    _mDecimals;
                set
                {
                    _mDecimals = value;
                }
            }

            public static string DecimalSymbol
            {
                get => 
                    _mDecimalSymbol;
                set
                {
                    _mDecimalSymbol = value;
                }
            }

            public static string DigitGroupSymbol
            {
                get => 
                    _mDigitGroupSymbol;
                set
                {
                    _mDigitGroupSymbol = value;
                }
            }

            public static string Format
            {
                get
                {
                    string str = "##,##0.";
                    for (int i = 0; i < _mDecimals; i++)
                    {
                        str = str + (_mAutoRound ? "#" : "0");
                    }
                    _mFormatNumber = _mFrefixSymbol + str + _mSuffixSymbol;
                    return _mFormatNumber;
                }
                set
                {
                    _mFormatNumber = value;
                }
            }

            public static string FormatString =>
                ("{0:" + Format + "}");

            public static string FrefixSymbol
            {
                get => 
                    _mFrefixSymbol;
                set
                {
                    _mFrefixSymbol = value;
                }
            }

            public static string SuffixSymbol
            {
                get => 
                    _mSuffixSymbol;
                set
                {
                    _mSuffixSymbol = value;
                }
            }
        }

        public class Parameter
        {
            private static string _mManager = "Gi\x00e1m đốc";

            public static string Manager
            {
                get => 
                    _mManager;
                set
                {
                    _mManager = value;
                }
            }
        }

        public class Regional
        {
            private static Options.FormatType _mDateFormatType = Options.FormatType.Custom;
            private static string _mDateSaparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            private static int _mDecimals = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalDigits;
            private static string _mDecimalSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            private static string _mDigitGroupSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            private static string _mFormatDate = "dd/MM/yyyy";
            private static string _mFormatNumber = "##,##0.###";
            private static bool _mIsMsgBoxResult = true;
            private static bool _mIsQuestion = true;
            private static int _mNumberDecimalDigits = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalDigits;

            public static Options.FormatType DateFormatType
            {
                get => 
                    _mDateFormatType;
                set
                {
                    _mDateFormatType = value;
                }
            }

            public static string DateSaparator
            {
                get => 
                    _mDateSaparator;
                set
                {
                    _mDateSaparator = value;
                }
            }

            public static int Decimals
            {
                get => 
                    _mDecimals;
                set
                {
                    _mDecimals = value;
                }
            }

            public static string DecimalSymbol
            {
                get => 
                    _mDecimalSymbol;
                set
                {
                    _mDecimalSymbol = value;
                }
            }

            public static string DigitGroupSymbol
            {
                get => 
                    _mDigitGroupSymbol;
                set
                {
                    _mDigitGroupSymbol = value;
                }
            }

            public static string FormatDate
            {
                get
                {
                    switch (_mDateFormatType)
                    {
                        case Options.FormatType.Dmy:
                            _mFormatDate = Options.FormatType.Dmy.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;

                        case Options.FormatType.Mdy:
                            _mFormatDate = Options.FormatType.Mdy.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;

                        case Options.FormatType.Ymd:
                            _mFormatDate = Options.FormatType.Ymd.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;
                    }
                    return _mFormatDate;
                }
                set
                {
                    _mDateFormatType = Options.FormatType.Custom;
                    _mFormatDate = value;
                }
            }

            public static string FormatNumber
            {
                get
                {
                    string str = "##,##0.";
                    for (int i = 0; i < _mDecimals; i++)
                    {
                        str = str + "#";
                    }
                    _mFormatNumber = str;
                    return str;
                }
                set
                {
                    _mFormatNumber = value;
                }
            }

            public static bool IsMsgBoxResult
            {
                get => 
                    _mIsMsgBoxResult;
                set
                {
                    _mIsMsgBoxResult = value;
                }
            }

            public static bool IsQuestion
            {
                get => 
                    _mIsQuestion;
                set
                {
                    _mIsQuestion = value;
                }
            }

            public static int NumberDecimalDigits
            {
                get => 
                    _mNumberDecimalDigits;
                set
                {
                    _mNumberDecimalDigits = value;
                }
            }

            public static string StringFormat =>
                ("{0:" + FormatNumber + "}");
        }

        public class System2
        {
            private static bool _mIsMsgBoxError = true;
            private static bool _mIsMsgBoxResult = true;
            private static bool _mIsQuestion = true;

            public static bool IsMsgBoxError
            {
                get => 
                    _mIsMsgBoxError;
                set
                {
                    _mIsMsgBoxError = value;
                }
            }

            public static bool IsMsgBoxResult
            {
                get => 
                    _mIsMsgBoxResult;
                set
                {
                    _mIsMsgBoxResult = value;
                }
            }

            public static bool IsQuestion
            {
                get => 
                    _mIsQuestion;
                set
                {
                    _mIsQuestion = value;
                }
            }
        }
    }
}

