namespace Vssoft.Common.Common.Class
{
    using Vssoft.Data.Helper;
    using Vssoft.Utils.Lib;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class SysOption
    {
        private string _mDescription;
        private static string _mLanguage = "VN";
        private string _mOptionID;
        private string _mOptionValue;
        private static string _mReportLanguage = "VN";
        private static string _mReportLocalization = "vi-VN";
        private int _mValueType;

        public SysOption()
        {
            this._mOptionID = "";
            this._mOptionValue = "";
            this._mValueType = 0;
            this._mDescription = "";
        }

        public SysOption(string optionID, string optionValue, int valueType, string description)
        {
            this._mOptionID = optionID;
            this._mOptionValue = optionValue;
            this._mValueType = valueType;
            this._mDescription = description;
        }

        public void AddCombo(ComboBox combo)
        {
            MyLib.TableToComboBox(combo, this.GetList(), "SYS_OPTIONName", "SYS_OPTIONID");
        }

        public void AddComboAll(ComboBox combo)
        {
            DataTable list = this.GetList();
            DataRow row = list.NewRow();
            row["SYS_OPTIONID"] = "All";
            row["SYS_OPTIONName"] = "Tất cả";
            list.Rows.InsertAt(row, 0);
            MyLib.TableToComboBox(combo, list, "SYS_OPTIONName", "SYS_OPTIONID");
        }

        public string Delete()
        {
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { this._mOptionID };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Delete", myParams, myValues);
        }

        public string Delete(string optionID)
        {
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Delete", myParams, myValues);
        }

        public string Delete(SqlConnection myConnection, string optionID)
        {
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "SYS_OPTION_Delete", myParams, myValues);
        }

        public string Delete(SqlTransaction myTransaction, string optionID)
        {
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "SYS_OPTION_Delete", myParams, myValues);
        }

        public bool Exist(string optionID)
        {
            bool hasRows = false;
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("SYS_OPTION_Get", myParams, myValues);
            if (reader != null)
            {
                hasRows = reader.HasRows;
                reader.Close();
                helper.Close();
            }
            return hasRows;
        }

        public string Get(string optionID)
        {
            string str = "";
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("SYS_OPTION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this._mOptionID = Convert.ToString(reader["Option_ID"]);
                    this._mOptionValue = Convert.ToString(reader["OptionValue"]);
                    this._mValueType = Convert.ToInt32(reader["ValueType"]);
                    this._mDescription = Convert.ToString(reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
            }
            return str;
        }

        public string Get(SqlConnection myConnection, string optionID)
        {
            string str = "";
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myConnection, "SYS_OPTION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this._mOptionID = Convert.ToString(reader["Option_ID"]);
                    this._mOptionValue = Convert.ToString(reader["OptionValue"]);
                    this._mValueType = Convert.ToInt32(reader["ValueType"]);
                    this._mDescription = Convert.ToString(reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
            }
            return str;
        }

        public string Get(SqlTransaction myTransaction, string optionID)
        {
            string str = "";
            string[] myParams = new string[] { "@Option_ID" };
            object[] myValues = new object[] { optionID };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myTransaction, "SYS_OPTION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this._mOptionID = Convert.ToString(reader["Option_ID"]);
                    this._mOptionValue = Convert.ToString(reader["OptionValue"]);
                    this._mValueType = Convert.ToInt32(reader["ValueType"]);
                    this._mDescription = Convert.ToString(reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
            }
            return str;
        }

        public DataTable GetList()
        {
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteDataTable("SYS_OPTION_GetList");
        }

        public string Insert()
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { this._mOptionID, this._mOptionValue, this._mValueType, this._mDescription };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { this._mOptionID, this._mOptionValue, this._mValueType, this._mDescription };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "SYS_OPTION_Insert", myParams, myValues);
        }

        public string Insert(string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Insert", myParams, myValues);
        }

        public string Insert(SqlConnection myConnection, string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "SYS_OPTION_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction, string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "SYS_OPTION_Insert", myParams, myValues);
        }

        public static void Load()
        {
            SysOption option = new SysOption();
            option.Get("Language_Id");
            _mLanguage = (option.OptionValue == "") ? "VN" : option.OptionValue;
        }

        public string NewID() => 
            SqlHelper.GenCode("SYS_OPTION", "SYS_OPTIONID", "");

        public string Update()
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { this._mOptionID, this._mOptionValue, this._mValueType, this._mDescription };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Update", myParams, myValues);
        }

        public string Update(string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("SYS_OPTION_Update", myParams, myValues);
        }

        public string Update(SqlConnection myConnection, string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "SYS_OPTION_Update", myParams, myValues);
        }

        public string Update(SqlTransaction myTransaction, string optionID, string OptionValue, int ValueType, string Description)
        {
            string[] myParams = new string[] { "@Option_ID", "@OptionValue", "@ValueType", "@Description" };
            object[] myValues = new object[] { optionID, OptionValue, ValueType, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "SYS_OPTION_Update", myParams, myValues);
        }

        public string Description
        {
            get => 
                this._mDescription;
            set
            {
                this._mDescription = value;
            }
        }

        public static string Language
        {
            get => 
                _mLanguage;
            set
            {
                _mLanguage = value;
            }
        }

        public string OptionID
        {
            get => 
                this._mOptionID;
            set
            {
                this._mOptionID = value;
            }
        }

        public string OptionValue
        {
            get => 
                this._mOptionValue;
            set
            {
                this._mOptionValue = value;
            }
        }

        public string ProductName =>
            "Class SYS_OPTION";

        public string ProductVersion =>
            "1.0.0.0";

        public static string ReportLanguage
        {
            get => 
                _mReportLanguage;
            set
            {
                _mReportLanguage = value;
            }
        }

        public static string ReportLocalization
        {
            get => 
                _mReportLocalization;
            set
            {
                _mReportLocalization = value;
            }
        }

        public int ValueType
        {
            get => 
                this._mValueType;
            set
            {
                this._mValueType = value;
            }
        }
    }
}

