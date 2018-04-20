namespace Vssoft.ERP
{
    using DevExpress.XtraEditors;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Vssoft.Data.Helper;

    public class DIC_POSITION
    {
        private bool m_Active;
        private string m_Description;
        private bool m_IsManager;
        private string m_PositionCode;
        private string m_PositionName;

        public DIC_POSITION()
        {
            this.m_PositionCode = "";
            this.m_PositionName = "";
            this.m_IsManager = false;
            this.m_Description = "";
            this.m_Active = true;
        }

        public DIC_POSITION(string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            this.m_PositionCode = PositionCode;
            this.m_PositionName = PositionName;
            this.m_IsManager = IsManager;
            this.m_Description = Description;
            this.m_Active = Active;
        }

        public void AddCombo(System.Windows.Forms.ComboBox combo)
        {
            //MyLib.TableToComboBox(combo, this.GetList(), "PositionName", "PositionCode");
        }

        public void AddComboAll(System.Windows.Forms.ComboBox combo)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            DataRow row = list.NewRow();
            row["PositionCode"] = "All";
            row["PositionName"] = "Tất cả";
            list.Rows.InsertAt(row, 0);
            //MyLib.TableToComboBox(combo, list, "PositionName", "PositionCode");
        }

        public void AddComboEdit(ComboBoxEdit combo)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            foreach (DataRow row in list.Rows)
            {
                combo.Properties.Items.Add(row["PositionName"]);
            }
        }

        public void AddGridLookupEdit(GridLookUpEdit gridlookup)
        {
            DataTable list = new DataTable();
            list = this.GetList();
            gridlookup.Properties.DataSource = list;
            gridlookup.Properties.DisplayMember = "PositionName";
            gridlookup.Properties.ValueMember = "PositionCode";
        }

        public string Delete()
        {
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { this.m_PositionCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Delete", myParams, myValues);
        }

        public string Delete(string PositionCode)
        {
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Delete", myParams, myValues);
            
        }

        public string Delete(SqlConnection myConnection, string PositionCode)
        {
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_POSITION_Delete", myParams, myValues);
            //return "OK";
        }

        public string Delete(SqlTransaction myTransaction, string PositionCode)
        {
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_POSITION_Delete", myParams, myValues);
            //return "OK";
        }

        public bool Exist(string PositionCode)
        {
            bool hasRows = false;
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("DIC_POSITION_Get", myParams, myValues);
            if (reader != null)
            {
                hasRows = reader.HasRows;
                reader.Close();
                helper.Close();
                reader = null;
            }
            return hasRows;
        }

        public string Get(string PositionCode)
        {
            string str = "";
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader("DIC_POSITION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_PositionCode = Convert.ToString(reader["PositionCode"]);
                    this.m_PositionName = Convert.ToString(reader["PositionName"]);
                    this.m_IsManager = Convert.ToBoolean(reader["IsManager"]);
                    this.m_Description = Convert.ToString(reader["Description"]);
                    this.m_Active = Convert.ToBoolean(reader["Active"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
                reader = null;
            }
            return str;
        }

        public string Get(SqlConnection myConnection, string PositionCode)
        {
            string str = "";
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myConnection, "DIC_POSITION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_PositionCode = Convert.ToString(reader["PositionCode"]);
                    this.m_PositionName = Convert.ToString(reader["PositionName"]);
                    this.m_IsManager = Convert.ToBoolean(reader["IsManager"]);
                    this.m_Description = Convert.ToString(reader["Description"]);
                    this.m_Active = Convert.ToBoolean(reader["Active"]);
                    str = "OK";
                }
                reader.Close();
                helper.Close();
                reader = null;
            }
            return str;
        }

        public string Get(SqlTransaction myTransaction, string PositionCode)
        {
            string str = "";
            string[] myParams = new string[] { "@PositionCode" };
            object[] myValues = new object[] { PositionCode };
            SqlHelper helper = new SqlHelper();
            SqlDataReader reader = helper.ExecuteReader(myTransaction, "DIC_POSITION_Get", myParams, myValues);
            if (reader != null)
            {
                while (reader.Read())
                {
                    this.m_PositionCode = Convert.ToString(reader["PositionCode"]);
                    this.m_PositionName = Convert.ToString(reader["PositionName"]);
                    this.m_IsManager = Convert.ToBoolean(reader["IsManager"]);
                    this.m_Description = Convert.ToString(reader["Description"]);
                    this.m_Active = Convert.ToBoolean(reader["Active"]);
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
            DataTable dt = new DataTable();
            dt.Columns.Add("PositionCode");
            dt.Columns.Add("PositionName");
            dt.Columns.Add("IsManager");
            dt.Columns.Add("Description");
            dt.Columns.Add("Active");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add("NV000"+i.ToString(), "Name "+i.ToString(),true, "Description "+i.ToString(),"Active "+i.ToString());
            }
            return dt;//helper.ExecuteDataTable("DIC_POSITION_GetList");
        }

        public string Insert()
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { this.m_PositionCode, this.m_PositionName, this.m_IsManager, this.m_Description, this.m_Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { this.m_PositionCode, this.m_PositionName, this.m_IsManager, this.m_Description, this.m_Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_POSITION_Insert", myParams, myValues);
        }

        public string Insert(string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Insert", myParams, myValues);
        }

        public string Insert(SqlConnection myConnection, string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_POSITION_Insert", myParams, myValues);
        }

        public string Insert(SqlTransaction myTransaction, string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_POSITION_Insert", myParams, myValues);
        }

        public string NewID() => 
            SqlHelper.GenCode("DIC_POSITION", "PositionCode", "CV");

        public string Update()
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { this.m_PositionCode, this.m_PositionName, this.m_IsManager, this.m_Description, this.m_Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Update", myParams, myValues);
        }

        public string Update(string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("DIC_POSITION_Update", myParams, myValues);
        }

        public string Update(SqlConnection myConnection, string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myConnection, "DIC_POSITION_Update", myParams, myValues);
        }

        public string Update(SqlTransaction myTransaction, string PositionCode, string PositionName, bool IsManager, string Description, bool Active)
        {
            string[] myParams = new string[] { "@PositionCode", "@PositionName", "@IsManager", "@Description", "@Active" };
            object[] myValues = new object[] { PositionCode, PositionName, IsManager, Description, Active };
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery(myTransaction, "DIC_POSITION_Update", myParams, myValues);
        }

        public bool Active
        {
            get => 
                this.m_Active;
            set
            {
                this.m_Active = value;
            }
        }

        public string Description
        {
            get => 
                this.m_Description;
            set
            {
                this.m_Description = value;
            }
        }

        public bool IsManager
        {
            get => 
                this.m_IsManager;
            set
            {
                this.m_IsManager = value;
            }
        }

        public string PositionCode
        {
            get => 
                this.m_PositionCode;
            set
            {
                this.m_PositionCode = value;
            }
        }

        public string PositionName
        {
            get => 
                this.m_PositionName;
            set
            {
                this.m_PositionName = value;
            }
        }

        public string ProductName =>
            "Class DIC_POSITION";

        public string ProductVersion =>
            "1.0.0.0";
    }
}

