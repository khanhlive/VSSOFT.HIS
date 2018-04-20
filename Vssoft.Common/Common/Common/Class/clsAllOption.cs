namespace Vssoft.Common.Common.Class
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class clsAllOption
    {
        private int m_LocationX;
        private int m_LocationY;
        private bool m_Minimized;
        private System.DateTime m_MonthDefault;
        private bool m_ShowDiagram;
        private bool m_ShowHelp;
        private bool m_ShowSalary;
        private bool m_ShowSendMail;
        private bool m_ShowTimekeeper;
        private bool m_ShowWelcome;
        private bool m_ShowWorkdesk;
        private int m_SizeHeight;
        private int m_SizeWidth;
        private int m_Update;
        private string m_WindowState;

        public clsAllOption()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Application.StartupPath + @"\Layout\allOption.xml");
                this.m_MonthDefault = System.DateTime.Parse(CheckOption("MonthDefault", ds));
                this.m_ShowDiagram = bool.Parse(CheckOption("ShowDiagram", ds));
                this.m_ShowWorkdesk = bool.Parse(CheckOption("ShowWorkdesk", ds));
                this.m_ShowWelcome = bool.Parse(CheckOption("ShowWelcome", ds));
                this.m_ShowHelp = bool.Parse(CheckOption("ShowHelp", ds));
                this.m_ShowSendMail = bool.Parse(CheckOption("ShowSendMail", ds));
                this.m_ShowTimekeeper = bool.Parse(CheckOption("ShowTimekeeper", ds));
                this.m_ShowSalary = bool.Parse(CheckOption("ShowSalary", ds));
                this.m_Update = int.Parse(CheckOption("Update", ds));
                this.m_Minimized = bool.Parse(CheckOption("Minimized", ds));
                this.m_WindowState = CheckOption("WindowState", ds);
                this.m_SizeWidth = int.Parse(CheckOption("SizeWidth", ds));
                this.m_SizeHeight = int.Parse(CheckOption("SizeHeight", ds));
                this.m_LocationX = int.Parse(CheckOption("LocationX", ds));
                this.m_LocationY = int.Parse(CheckOption("LocationY", ds));
            }
            catch
            {
                this.m_MonthDefault = System.DateTime.Now;
                this.m_ShowDiagram = true;
                this.m_ShowWorkdesk = true;
                this.m_ShowWelcome = false;
                this.m_ShowHelp = true;
                this.m_ShowSendMail = true;
                this.m_ShowTimekeeper = true;
                this.m_ShowSalary = true;
                this.m_Update = 1;
                this.m_Minimized = false;
                this.m_WindowState = "Maximized";
                this.m_SizeWidth = 0x400;
                this.m_SizeHeight = 0x300;
                this.m_LocationX = 0;
                this.m_LocationY = 0;
            }
        }

        public static string CheckOption(string FieldName)
        {
            try
            {
                DataSet set = new DataSet();
                set.ReadXml(Application.StartupPath + @"\Layout\allOption.xml");
                return set.Tables[0].Rows[0][FieldName].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string CheckOption(string FieldName, DataSet ds)
        {
            try
            {
                return ds.Tables[0].Rows[0][FieldName].ToString();
            }
            catch
            {
                return "";
            }
        }

        public void SaveOption()
        {
            DataSet set = new DataSet();
            using (DataTable table = new DataTable())
            {
                table.Columns.Add("MonthDefault", typeof(string));
                table.Columns.Add("ShowDiagram", typeof(string));
                table.Columns.Add("ShowWorkdesk", typeof(string));
                table.Columns.Add("ShowWelcome", typeof(string));
                table.Columns.Add("ShowHelp", typeof(string));
                table.Columns.Add("ShowSendMail", typeof(string));
                table.Columns.Add("ShowTimekeeper", typeof(string));
                table.Columns.Add("ShowSalary", typeof(string));
                table.Columns.Add("Update", typeof(string));
                table.Columns.Add("Minimized", typeof(string));
                table.Columns.Add("WindowState", typeof(string));
                table.Columns.Add("SizeWidth", typeof(string));
                table.Columns.Add("SizeHeight", typeof(string));
                table.Columns.Add("LocationX", typeof(string));
                table.Columns.Add("LocationY", typeof(string));
                object[] objArray = new object[] { this.m_MonthDefault.ToString(), this.m_ShowDiagram.ToString(), this.m_ShowWorkdesk.ToString(), this.m_ShowWelcome.ToString(), this.m_ShowHelp.ToString(), this.m_ShowSendMail.ToString(), this.m_ShowTimekeeper.ToString(), this.m_ShowSalary.ToString(), this.m_Update.ToString(), this.m_Minimized.ToString(), this.m_WindowState.ToString(), this.m_SizeWidth.ToString(), this.m_SizeHeight.ToString(), this.m_LocationX.ToString(), this.m_LocationY.ToString() };
                table.Rows.Add(new object[0]);
                table.Rows[0][0] = objArray[0];
                table.Rows[0][1] = objArray[1];
                table.Rows[0][2] = objArray[2];
                table.Rows[0][3] = objArray[3];
                table.Rows[0][4] = objArray[4];
                table.Rows[0][5] = objArray[5];
                table.Rows[0][6] = objArray[6];
                table.Rows[0][7] = objArray[7];
                table.Rows[0][8] = objArray[8];
                table.Rows[0][9] = objArray[9];
                table.Rows[0][10] = objArray[10];
                table.Rows[0][11] = objArray[11];
                table.Rows[0][12] = objArray[12];
                table.Rows[0][13] = objArray[13];
                table.Rows[0][14] = objArray[14];
                set.Tables.Add(table);
            }
            try
            {
                set.WriteXml(Application.StartupPath + @"\Layout\allOption.xml");
            }
            catch
            {
            }
        }

        public static void SaveOption(System.DateTime MonthDefault, bool ShowDiagram, bool ShowWorkdesk, bool ShowWelcome, bool ShowHelp, bool ShowSendMail, bool ShowTimekeeper, bool ShowSalary, int Update, bool Minimized, string WindowState, int SizeWidth, int SizeHeight, int LocationX, int LocationY)
        {
            DataSet set = new DataSet();
            using (DataTable table = new DataTable())
            {
                table.Columns.Add("MonthDefault", typeof(string));
                table.Columns.Add("ShowDiagram", typeof(string));
                table.Columns.Add("ShowWorkdesk", typeof(string));
                table.Columns.Add("ShowWelcome", typeof(string));
                table.Columns.Add("ShowHelp", typeof(string));
                table.Columns.Add("ShowSendMail", typeof(string));
                table.Columns.Add("ShowTimekeeper", typeof(string));
                table.Columns.Add("ShowSalary", typeof(string));
                table.Columns.Add("Update", typeof(string));
                table.Columns.Add("Minimized", typeof(string));
                table.Columns.Add("WindowState", typeof(string));
                table.Columns.Add("SizeWidth", typeof(string));
                table.Columns.Add("SizeHeight", typeof(string));
                table.Columns.Add("LocationX", typeof(string));
                table.Columns.Add("LocationY", typeof(string));
                object[] objArray = new object[] { MonthDefault.ToString(), ShowDiagram.ToString(), ShowWorkdesk.ToString(), ShowWelcome.ToString(), ShowHelp.ToString(), ShowSendMail.ToString(), ShowTimekeeper.ToString(), ShowSalary.ToString(), Update.ToString(), Minimized.ToString(), WindowState.ToString(), SizeWidth.ToString(), SizeHeight.ToString(), LocationX.ToString(), LocationY.ToString() };
                table.Rows.Add(new object[0]);
                table.Rows[0][0] = objArray[0];
                table.Rows[0][1] = objArray[1];
                table.Rows[0][2] = objArray[2];
                table.Rows[0][3] = objArray[3];
                table.Rows[0][4] = objArray[4];
                table.Rows[0][5] = objArray[5];
                table.Rows[0][6] = objArray[6];
                table.Rows[0][7] = objArray[7];
                table.Rows[0][8] = objArray[8];
                table.Rows[0][9] = objArray[9];
                table.Rows[0][10] = objArray[10];
                table.Rows[0][11] = objArray[11];
                table.Rows[0][12] = objArray[12];
                table.Rows[0][13] = objArray[13];
                table.Rows[0][14] = objArray[14];
                set.Tables.Add(table);
            }
            try
            {
                set.WriteXml(Application.StartupPath + @"\Layout\allOption.xml");
            }
            catch
            {
            }
        }

        public int LocationX
        {
            get => 
                this.m_LocationX;
            set
            {
                this.m_LocationX = value;
            }
        }

        public int LocationY
        {
            get => 
                this.m_LocationY;
            set
            {
                this.m_LocationY = value;
            }
        }

        public bool Minimized
        {
            get => 
                this.m_Minimized;
            set
            {
                this.m_Minimized = value;
            }
        }

        public System.DateTime MonthDefault
        {
            get => 
                this.m_MonthDefault;
            set
            {
                this.m_MonthDefault = value;
            }
        }

        public bool ShowDiagram
        {
            get => 
                this.m_ShowDiagram;
            set
            {
                this.m_ShowDiagram = value;
            }
        }

        public bool ShowHelp
        {
            get => 
                this.m_ShowHelp;
            set
            {
                this.m_ShowHelp = value;
            }
        }

        public bool ShowSalary
        {
            get => 
                this.m_ShowSalary;
            set
            {
                this.m_ShowSalary = value;
            }
        }

        public bool ShowSendMail
        {
            get => 
                this.m_ShowSendMail;
            set
            {
                this.m_ShowSendMail = value;
            }
        }

        public bool ShowTimekeeper
        {
            get => 
                this.m_ShowTimekeeper;
            set
            {
                this.m_ShowTimekeeper = value;
            }
        }

        public bool ShowWelcome
        {
            get => 
                this.m_ShowWelcome;
            set
            {
                this.m_ShowWelcome = value;
            }
        }

        public bool ShowWorkdesk
        {
            get => 
                this.m_ShowWorkdesk;
            set
            {
                this.m_ShowWorkdesk = value;
            }
        }

        public int SizeHeight
        {
            get => 
                this.m_SizeHeight;
            set
            {
                this.m_SizeHeight = value;
            }
        }

        public int SizeWidth
        {
            get => 
                this.m_SizeWidth;
            set
            {
                this.m_SizeWidth = value;
            }
        }

        public int Update
        {
            get => 
                this.m_Update;
            set
            {
                this.m_Update = value;
            }
        }

        public string WindowState
        {
            get => 
                this.m_WindowState;
            set
            {
                this.m_WindowState = value;
            }
        }
    }
}

