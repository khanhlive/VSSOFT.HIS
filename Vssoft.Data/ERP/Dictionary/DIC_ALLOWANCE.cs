namespace Perfect.ERP
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Repository;
    using Perfect.Data.Helper;
    using Perfect.Utils.Lib;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class DIC_ALLOWANCE
    {
        private string m_AllowanceCode;
        private string m_AllowanceName;
        private string m_Description;
        private double m_IncomeTaxValue;
        private bool m_IsByWorkDay;
        private bool m_IsShowInSalaryTableList;
        private decimal m_MaximumMoney;

        public DIC_ALLOWANCE()
        {
            this.m_AllowanceCode = "";
            this.m_AllowanceName = "";
            this.m_MaximumMoney = 0M;
            this.m_IsByWorkDay = false;
            this.m_IncomeTaxValue = 0.0;
            this.m_IsShowInSalaryTableList = false;
            this.m_Description = "";
        }

        public DIC_ALLOWANCE(string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            this.m_AllowanceCode = AllowanceCode;
            this.m_AllowanceName = AllowanceName;
            this.m_MaximumMoney = MaximumMoney;
            this.m_IsByWorkDay = IsByWorkDay;
            this.m_IncomeTaxValue = IncomeTaxValue;
            this.m_IsShowInSalaryTableList = IsShowInSalaryTableList;
            this.m_Description = Description;
        }

        public void AddCombo(System.Windows.Forms.ComboBox combo)
        {
            MyLib.TableToComboBox(combo, this.GetList(), "AllowanceName", "AllowanceCode");
        }

        public void AddComboAll(System.Windows.Forms.ComboBox combo)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            DataRow row = list.NewRow();
            row["AllowanceCode"] = "All";
            row["AllowanceName"] = "Tất cả";
            list.Rows.InsertAt(row, 0);
            MyLib.TableToComboBox(combo, list, "AllowanceName", "AllowanceCode");
        }

        public void AddComboEdit(ComboBoxEdit combo)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            foreach (DataRow row in list.Rows)
            {
                combo.Properties.Items.Add(row["AllowanceName"]);
            }
        }

        public void AddGridLookupEdit(GridLookUpEdit gridlookup)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            gridlookup.Properties.DataSource = list;
            gridlookup.Properties.DisplayMember = "AllowanceName";
            gridlookup.Properties.ValueMember = "AllowanceCode";
        }

        public void AddRepositoryGridLookupEdit(RepositoryItemGridLookUpEdit gridlookup)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            gridlookup.DataSource = list;
            gridlookup.DisplayMember = "AllowanceCode";
            gridlookup.ValueMember = "AllowanceCode";
        }

        public void AddRepositoryGridLookupEdit1(RepositoryItemGridLookUpEdit gridlookup)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            gridlookup.DataSource = list;
            gridlookup.DisplayMember = "AllowanceName";
            gridlookup.ValueMember = "AllowanceCode";
        }

        public string Delete()
        {
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { this.m_AllowanceCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Delete", myParams, myValues);
        }

        public string Delete(string AllowanceCode)
        {
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Delete", myParams, myValues);
        }

        public string Delete(SqlConnection myConnection, string AllowanceCode)
        {
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_ALLOWANCE_Delete", myParams, myValues);
        }

        public string Delete(SqlTransaction myTransaction, string AllowanceCode)
        {
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_ALLOWANCE_Delete", myParams, myValues);
        }

        public bool Exist(string AllowanceCode)
        {
            bool hasRows = false;
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("DIC_ALLOWANCE_Get", myParams, myValues);
            if (reader != null)
            {
                hasRows = reader.HasRows;
                reader.Close();
                helper.Close();
                reader = null;
            }
            return hasRows;
        }

        public string Get(string AllowanceCode)
        {
            string str = "";
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("DIC_ALLOWANCE_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_AllowanceCode = Convert.ToString((reader["AllowanceCode"] == DBNull.Value) ? "" : reader["AllowanceCode"]);
                    this.m_AllowanceName = Convert.ToString((reader["AllowanceName"] == DBNull.Value) ? "" : reader["AllowanceName"]);
                    this.m_MaximumMoney = Convert.ToDecimal((reader["MaximumMoney"] == DBNull.Value) ? 0 : reader["MaximumMoney"]);
                    this.m_IsByWorkDay = Convert.ToBoolean((reader["IsByWorkDay"] == DBNull.Value) ? true : reader["IsByWorkDay"]);
                    this.m_IncomeTaxValue = Convert.ToDouble((reader["IncomeTaxValue"] == DBNull.Value) ? 0.0 : reader["IncomeTaxValue"]);
                    this.m_IsShowInSalaryTableList = Convert.ToBoolean((reader["IsShowInSalaryTableList"] == DBNull.Value) ? true : reader["IsShowInSalaryTableList"]);
                    this.m_Description = Convert.ToString((reader["Description"] == DBNull.Value) ? "" : reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
                reader = null;
            }
            return str;
        }

        public string Get(SqlConnection myConnection, string AllowanceCode)
        {
            string str = "";
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myConnection, "DIC_ALLOWANCE_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_AllowanceCode = Convert.ToString((reader["AllowanceCode"] == DBNull.Value) ? "" : reader["AllowanceCode"]);
                    this.m_AllowanceName = Convert.ToString((reader["AllowanceName"] == DBNull.Value) ? "" : reader["AllowanceName"]);
                    this.m_MaximumMoney = Convert.ToDecimal((reader["MaximumMoney"] == DBNull.Value) ? 0 : reader["MaximumMoney"]);
                    this.m_IsByWorkDay = Convert.ToBoolean((reader["IsByWorkDay"] == DBNull.Value) ? true : reader["IsByWorkDay"]);
                    this.m_IncomeTaxValue = Convert.ToDouble((reader["IncomeTaxValue"] == DBNull.Value) ? 0.0 : reader["IncomeTaxValue"]);
                    this.m_IsShowInSalaryTableList = Convert.ToBoolean((reader["IsShowInSalaryTableList"] == DBNull.Value) ? true : reader["IsShowInSalaryTableList"]);
                    this.m_Description = Convert.ToString((reader["Description"] == DBNull.Value) ? "" : reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
                reader = null;
            }
            return str;
        }

        public string Get(SqlTransaction myTransaction, string AllowanceCode)
        {
            string str = "";
            string[] myParams = new string[] { "@AllowanceCode" };
            object[] myValues = new object[] { AllowanceCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myTransaction, "DIC_ALLOWANCE_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_AllowanceCode = Convert.ToString((reader["AllowanceCode"] == DBNull.Value) ? "" : reader["AllowanceCode"]);
                    this.m_AllowanceName = Convert.ToString((reader["AllowanceName"] == DBNull.Value) ? "" : reader["AllowanceName"]);
                    this.m_MaximumMoney = Convert.ToDecimal((reader["MaximumMoney"] == DBNull.Value) ? 0 : reader["MaximumMoney"]);
                    this.m_IsByWorkDay = Convert.ToBoolean((reader["IsByWorkDay"] == DBNull.Value) ? true : reader["IsByWorkDay"]);
                    this.m_IncomeTaxValue = Convert.ToDouble((reader["IncomeTaxValue"] == DBNull.Value) ? 0.0 : reader["IncomeTaxValue"]);
                    this.m_IsShowInSalaryTableList = Convert.ToBoolean((reader["IsShowInSalaryTableList"] == DBNull.Value) ? true : reader["IsShowInSalaryTableList"]);
                    this.m_Description = Convert.ToString((reader["Description"] == DBNull.Value) ? "" : reader["Description"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
                reader = null;
            }
            return str;
        }

        public DataTable GetList()
        {
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteDataTable("DIC_ALLOWANCE_GetList");
        }

        public string Insert()
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { this.m_AllowanceCode, this.m_AllowanceName, this.m_MaximumMoney, this.m_IsByWorkDay, this.m_IncomeTaxValue, this.m_IsShowInSalaryTableList, this.m_Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { this.m_AllowanceCode, this.m_AllowanceName, this.m_MaximumMoney, this.m_IsByWorkDay, this.m_IncomeTaxValue, this.m_IsShowInSalaryTableList, this.m_Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_ALLOWANCE_Insert", myParams, myValues);
        }

        public string Insert(string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Insert", myParams, myValues);
        }

        public string Insert(SqlConnection myConnection, string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_ALLOWANCE_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction, string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_ALLOWANCE_Insert", myParams, myValues);
        }

        public string NewID()
        {
            return SqlHelper.GenCode("DIC_ALLOWANCE", "AllowanceCode", "PC");
        }

        public void SetData(string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            this.m_AllowanceCode = AllowanceCode;
            this.m_AllowanceName = AllowanceName;
            this.m_MaximumMoney = MaximumMoney;
            this.m_IsByWorkDay = IsByWorkDay;
            this.m_IncomeTaxValue = IncomeTaxValue;
            this.m_IsShowInSalaryTableList = IsShowInSalaryTableList;
            this.m_Description = Description;
        }

        public string Update()
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { this.m_AllowanceCode, this.m_AllowanceName, this.m_MaximumMoney, this.m_IsByWorkDay, this.m_IncomeTaxValue, this.m_IsShowInSalaryTableList, this.m_Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Update", myParams, myValues);
        }

        public string Update(string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_ALLOWANCE_Update", myParams, myValues);
        }

        public string Update(SqlConnection myConnection, string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_ALLOWANCE_Update", myParams, myValues);
        }

        public string Update(SqlTransaction myTransaction, string AllowanceCode, string AllowanceName, decimal MaximumMoney, bool IsByWorkDay, double IncomeTaxValue, bool IsShowInSalaryTableList, string Description)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@AllowanceName", "@MaximumMoney", "@IsByWorkDay", "@IncomeTaxValue", "@IsShowInSalaryTableList", "@Description" };
            object[] myValues = new object[] { AllowanceCode, AllowanceName, MaximumMoney, IsByWorkDay, IncomeTaxValue, IsShowInSalaryTableList, Description };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_ALLOWANCE_Update", myParams, myValues);
        }

        public string UpdateEmployeeAllowance(string AllowanceCode, bool IsByWorkDay, double IncomeTaxValue)
        {
            string[] myParams = new string[] { "@AllowanceCode", "@IsByWorkDay", "@IncomeTaxValue" };
            object[] myValues = new object[] { AllowanceCode, IsByWorkDay, IncomeTaxValue };
            SqlHelper helper = new SqlHelper {
                CommandType = CommandType.Text
            };
            return helper.ExecuteNonQuery("Update HRM_EMPLOYEE_ALLOWANCE\r\nset IsByWorkDay=@IsByWorkDay,\r\nIncomeTaxValue=@IncomeTaxValue\r\nwhere AllowanceCode=@AllowanceCode", myParams, myValues);
        }

        [DisplayName("AllowanceCode"), Category("Primary Key")]
        public string AllowanceCode
        {
            get
            {
                return this.m_AllowanceCode;
            }
            set
            {
                this.m_AllowanceCode = value;
            }
        }

        [DisplayName("AllowanceName"), Category("Column")]
        public string AllowanceName
        {
            get
            {
                return this.m_AllowanceName;
            }
            set
            {
                this.m_AllowanceName = value;
            }
        }

        [DisplayName("Description"), Category("Column")]
        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        [Category("Column"), DisplayName("IncomeTaxValue")]
        public double IncomeTaxValue
        {
            get
            {
                return this.m_IncomeTaxValue;
            }
            set
            {
                this.m_IncomeTaxValue = value;
            }
        }

        [Category("Column"), DisplayName("IsByWorkDay")]
        public bool IsByWorkDay
        {
            get
            {
                return this.m_IsByWorkDay;
            }
            set
            {
                this.m_IsByWorkDay = value;
            }
        }

        [DisplayName("IsShowInSalaryTableList"), Category("Column")]
        public bool IsShowInSalaryTableList
        {
            get
            {
                return this.m_IsShowInSalaryTableList;
            }
            set
            {
                this.m_IsShowInSalaryTableList = value;
            }
        }

        [DisplayName("MaximumMoney"), Category("Column")]
        public decimal MaximumMoney
        {
            get
            {
                return this.m_MaximumMoney;
            }
            set
            {
                this.m_MaximumMoney = value;
            }
        }

        public string ProductName
        {
            get
            {
                return "Class DIC_ALLOWANCE";
            }
        }

        public string ProductVersion
        {
            get
            {
                return "1.0.0.0";
            }
        }
    }
}

