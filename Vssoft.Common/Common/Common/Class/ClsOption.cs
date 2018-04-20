namespace Vssoft.Common.Common.Class
{
    using DevExpress.Utils;
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public class ClsOption
    {
        private static WaitDialogForm _dlg;

        public static void CreateWaitDialog()
        {
            if (_dlg == null)
            {
                _dlg = new WaitDialogForm("Đang nạp dữ liệu ...", "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t...");
            }
        }

        private static void dlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dlg = null;
        }

        public static void DoHide()
        {
            if (_dlg != null)
            {
                _dlg.FormClosing += new FormClosingEventHandler(ClsOption.dlg_FormClosing);
                _dlg.Close();
            }
        }

        ~ClsOption()
        {
            if (_dlg != null)
            {
                _dlg.FormClosing += new FormClosingEventHandler(ClsOption.dlg_FormClosing);
                _dlg.Close();
            }
        }

        public static void SetWaitDialogCaption(string fCaption)
        {
            if (_dlg != null)
            {
                _dlg.Caption = fCaption;
            }
            else
            {
                _dlg = new WaitDialogForm(fCaption, "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t...");
            }
        }

        public class DateTime
        {
            private static Vssoft.Common.Common.Class.ClsOption.FormatType _mDateFormatType = Vssoft.Common.Common.Class.ClsOption.FormatType.Custom;
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
                        case Vssoft.Common.Common.Class.ClsOption.FormatType.Dmy:
                            day = GetDay(true);
                            month = GetMonth(true);
                            year = GetYear(false);
                            _mFormatDate = (day.Length == 1) ? "" : (day + ((month.Length == 1) ? "" : month) + year);
                            if (_mFormatDate.Trim() == string.Empty)
                            {
                                _mFormatDate = "dd/MM/yyyy";
                            }
                            return _mFormatDate;

                        case Vssoft.Common.Common.Class.ClsOption.FormatType.Mdy:
                            day = GetDay(true);
                            month = GetMonth(true);
                            year = GetYear(false);
                            _mFormatDate = (month.Length == 1) ? "" : (month + ((day.Length == 1) ? "" : day) + year);
                            if (_mFormatDate.Trim() == string.Empty)
                            {
                                _mFormatDate = "MM/dd/yyyy";
                            }
                            return _mFormatDate;

                        case Vssoft.Common.Common.Class.ClsOption.FormatType.Ymd:
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
                    _mDateFormatType = Vssoft.Common.Common.Class.ClsOption.FormatType.Custom;
                    _mFormatDate = value;
                }
            }

            public static string FormatString =>
                ("{0:" + Format + "}");

            public static Vssoft.Common.Common.Class.ClsOption.FormatType FormatType
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
            private static int _mDecimals = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalDigits;
            private static string _mDecimalSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            private static string _mDigitGroupSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            private static string _mFormatNumber = "##,##0.###";
            private static string _mFrefixSymbol = "";
            private static string _mSuffixSymbol = "";

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

            private static string Format
            {
                get
                {
                    string str = "##,##0.";
                    for (int i = 0; i < _mDecimals; i++)
                    {
                        str = str + "#";
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

            public static string PercentFormatString =>
                ("{0:" + Format + "} %");

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
            private static ClsOption.FormatType _mDateFormatType = ClsOption.FormatType.Custom;
            private static string _mDateSaparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            private static int _mDecimals = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalDigits;
            private static string _mDecimalSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            private static string _mDigitGroupSymbol = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
            private static string _mFormatDate = "dd/MM/yyyy";
            private static string _mFormatNumber = "##,##0.###";
            private static bool _mIsMsgBoxResult = true;
            private static bool _mIsQuestion = true;

            public static ClsOption.FormatType DateFormatType
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
                        case ClsOption.FormatType.Dmy:
                            _mFormatDate = ClsOption.FormatType.Dmy.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;

                        case ClsOption.FormatType.Mdy:
                            _mFormatDate = ClsOption.FormatType.Mdy.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;

                        case ClsOption.FormatType.Ymd:
                            _mFormatDate = ClsOption.FormatType.Ymd.ToString().Replace("/", _mDateSaparator);
                            return _mFormatDate;
                    }
                    return _mFormatDate;
                }
                set
                {
                    _mDateFormatType = ClsOption.FormatType.Custom;
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

