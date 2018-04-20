namespace Vssoft.HumanResource.DS
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), HelpKeyword("vs.data.DataSet"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("dsUPDATE")]
    public class dsUPDATE : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private KillProcessDataTable tableKillProcess;
        private SQLDataTable tableSQL;
        private UPDATEDataTable tableUPDATE;

        [DebuggerNonUserCode]
        public dsUPDATE()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode]
        protected dsUPDATE(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["UPDATE"] != null)
                    {
                        base.Tables.Add(new UPDATEDataTable(dataSet.Tables["UPDATE"]));
                    }
                    if (dataSet.Tables["KillProcess"] != null)
                    {
                        base.Tables.Add(new KillProcessDataTable(dataSet.Tables["KillProcess"]));
                    }
                    if (dataSet.Tables["SQL"] != null)
                    {
                        base.Tables.Add(new SQLDataTable(dataSet.Tables["SQL"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
        }

        [DebuggerNonUserCode]
        public override DataSet Clone()
        {
            dsUPDATE supdate = (dsUPDATE) base.Clone();
            supdate.InitVars();
            supdate.SchemaSerializationMode = this.SchemaSerializationMode;
            return supdate;
        }

        [DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            dsUPDATE supdate = new dsUPDATE();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = supdate.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = supdate.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode]
        private void InitClass()
        {
            base.DataSetName = "dsUPDATE";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dsUPDATE.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableUPDATE = new UPDATEDataTable();
            base.Tables.Add(this.tableUPDATE);
            this.tableKillProcess = new KillProcessDataTable();
            base.Tables.Add(this.tableKillProcess);
            this.tableSQL = new SQLDataTable();
            base.Tables.Add(this.tableSQL);
        }

        [DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableUPDATE = (UPDATEDataTable) base.Tables["UPDATE"];
            if (initTable && (this.tableUPDATE != null))
            {
                this.tableUPDATE.InitVars();
            }
            this.tableKillProcess = (KillProcessDataTable) base.Tables["KillProcess"];
            if (initTable && (this.tableKillProcess != null))
            {
                this.tableKillProcess.InitVars();
            }
            this.tableSQL = (SQLDataTable) base.Tables["SQL"];
            if (initTable && (this.tableSQL != null))
            {
                this.tableSQL.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["UPDATE"] != null)
                {
                    base.Tables.Add(new UPDATEDataTable(dataSet.Tables["UPDATE"]));
                }
                if (dataSet.Tables["KillProcess"] != null)
                {
                    base.Tables.Add(new KillProcessDataTable(dataSet.Tables["KillProcess"]));
                }
                if (dataSet.Tables["SQL"] != null)
                {
                    base.Tables.Add(new SQLDataTable(dataSet.Tables["SQL"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeKillProcess() => 
            false;

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations() => 
            false;

        [DebuggerNonUserCode]
        private bool ShouldSerializeSQL() => 
            false;

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables() => 
            false;

        [DebuggerNonUserCode]
        private bool ShouldSerializeUPDATE() => 
            false;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public KillProcessDataTable KillProcess =>
            this.tableKillProcess;

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRelationCollection Relations =>
            base.Relations;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true), DebuggerNonUserCode]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get => 
                this._schemaSerializationMode;
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false)]
        public SQLDataTable SQL =>
            this.tableSQL;

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTableCollection Tables =>
            base.Tables;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public UPDATEDataTable UPDATE =>
            this.tableUPDATE;

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class KillProcessDataTable : DataTable, IEnumerable
        {
            private DataColumn columnKillProcess;

            public event dsUPDATE.KillProcessRowChangeEventHandler KillProcessRowChanged;

            public event dsUPDATE.KillProcessRowChangeEventHandler KillProcessRowChanging;

            public event dsUPDATE.KillProcessRowChangeEventHandler KillProcessRowDeleted;

            public event dsUPDATE.KillProcessRowChangeEventHandler KillProcessRowDeleting;

            [DebuggerNonUserCode]
            public KillProcessDataTable()
            {
                base.TableName = "KillProcess";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal KillProcessDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            protected KillProcessDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddKillProcessRow(dsUPDATE.KillProcessRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsUPDATE.KillProcessRow AddKillProcessRow(string KillProcess)
            {
                dsUPDATE.KillProcessRow row = (dsUPDATE.KillProcessRow) base.NewRow();
                row.ItemArray = new object[] { KillProcess };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsUPDATE.KillProcessDataTable table = (dsUPDATE.KillProcessDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance() => 
                new dsUPDATE.KillProcessDataTable();

            [DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator() => 
                base.Rows.GetEnumerator();

            [DebuggerNonUserCode]
            protected override Type GetRowType() => 
                typeof(dsUPDATE.KillProcessRow);

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsUPDATE supdate = new dsUPDATE();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = supdate.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "KillProcessDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = supdate.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnKillProcess = new DataColumn("KillProcess", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnKillProcess);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnKillProcess = base.Columns["KillProcess"];
            }

            [DebuggerNonUserCode]
            public dsUPDATE.KillProcessRow NewKillProcessRow() => 
                ((dsUPDATE.KillProcessRow) base.NewRow());

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => 
                new dsUPDATE.KillProcessRow(builder);

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.KillProcessRowChanged != null)
                {
                    this.KillProcessRowChanged(this, new dsUPDATE.KillProcessRowChangeEvent((dsUPDATE.KillProcessRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.KillProcessRowChanging != null)
                {
                    this.KillProcessRowChanging(this, new dsUPDATE.KillProcessRowChangeEvent((dsUPDATE.KillProcessRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.KillProcessRowDeleted != null)
                {
                    this.KillProcessRowDeleted(this, new dsUPDATE.KillProcessRowChangeEvent((dsUPDATE.KillProcessRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.KillProcessRowDeleting != null)
                {
                    this.KillProcessRowDeleting(this, new dsUPDATE.KillProcessRowChangeEvent((dsUPDATE.KillProcessRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveKillProcessRow(dsUPDATE.KillProcessRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, Browsable(false)]
            public int Count =>
                base.Rows.Count;

            [DebuggerNonUserCode]
            public dsUPDATE.KillProcessRow this[int index] =>
                ((dsUPDATE.KillProcessRow) base.Rows[index]);

            [DebuggerNonUserCode]
            public DataColumn KillProcessColumn =>
                this.columnKillProcess;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class KillProcessRow : DataRow
        {
            private dsUPDATE.KillProcessDataTable tableKillProcess;

            [DebuggerNonUserCode]
            internal KillProcessRow(DataRowBuilder rb) : base(rb)
            {
                this.tableKillProcess = (dsUPDATE.KillProcessDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsKillProcessNull() => 
                base.IsNull(this.tableKillProcess.KillProcessColumn);

            [DebuggerNonUserCode]
            public void SetKillProcessNull()
            {
                base[this.tableKillProcess.KillProcessColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string KillProcess
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableKillProcess.KillProcessColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'KillProcess' in table 'KillProcess' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableKillProcess.KillProcessColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class KillProcessRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsUPDATE.KillProcessRow eventRow;

            [DebuggerNonUserCode]
            public KillProcessRowChangeEvent(dsUPDATE.KillProcessRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action =>
                this.eventAction;

            [DebuggerNonUserCode]
            public dsUPDATE.KillProcessRow Row =>
                this.eventRow;
        }

        public delegate void KillProcessRowChangeEventHandler(object sender, dsUPDATE.KillProcessRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SQLDataTable : DataTable, IEnumerable
        {
            private DataColumn columnSql;

            public event dsUPDATE.SQLRowChangeEventHandler SQLRowChanged;

            public event dsUPDATE.SQLRowChangeEventHandler SQLRowChanging;

            public event dsUPDATE.SQLRowChangeEventHandler SQLRowDeleted;

            public event dsUPDATE.SQLRowChangeEventHandler SQLRowDeleting;

            [DebuggerNonUserCode]
            public SQLDataTable()
            {
                base.TableName = "SQL";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal SQLDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            protected SQLDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddSQLRow(dsUPDATE.SQLRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsUPDATE.SQLRow AddSQLRow(string Sql)
            {
                dsUPDATE.SQLRow row = (dsUPDATE.SQLRow) base.NewRow();
                row.ItemArray = new object[] { Sql };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsUPDATE.SQLDataTable table = (dsUPDATE.SQLDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance() => 
                new dsUPDATE.SQLDataTable();

            [DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator() => 
                base.Rows.GetEnumerator();

            [DebuggerNonUserCode]
            protected override Type GetRowType() => 
                typeof(dsUPDATE.SQLRow);

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsUPDATE supdate = new dsUPDATE();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = supdate.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SQLDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = supdate.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnSql = new DataColumn("Sql", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSql);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSql = base.Columns["Sql"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => 
                new dsUPDATE.SQLRow(builder);

            [DebuggerNonUserCode]
            public dsUPDATE.SQLRow NewSQLRow() => 
                ((dsUPDATE.SQLRow) base.NewRow());

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SQLRowChanged != null)
                {
                    this.SQLRowChanged(this, new dsUPDATE.SQLRowChangeEvent((dsUPDATE.SQLRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SQLRowChanging != null)
                {
                    this.SQLRowChanging(this, new dsUPDATE.SQLRowChangeEvent((dsUPDATE.SQLRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SQLRowDeleted != null)
                {
                    this.SQLRowDeleted(this, new dsUPDATE.SQLRowChangeEvent((dsUPDATE.SQLRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SQLRowDeleting != null)
                {
                    this.SQLRowDeleting(this, new dsUPDATE.SQLRowChangeEvent((dsUPDATE.SQLRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveSQLRow(dsUPDATE.SQLRow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false), DebuggerNonUserCode]
            public int Count =>
                base.Rows.Count;

            [DebuggerNonUserCode]
            public dsUPDATE.SQLRow this[int index] =>
                ((dsUPDATE.SQLRow) base.Rows[index]);

            [DebuggerNonUserCode]
            public DataColumn SqlColumn =>
                this.columnSql;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SQLRow : DataRow
        {
            private dsUPDATE.SQLDataTable tableSQL;

            [DebuggerNonUserCode]
            internal SQLRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSQL = (dsUPDATE.SQLDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsSqlNull() => 
                base.IsNull(this.tableSQL.SqlColumn);

            [DebuggerNonUserCode]
            public void SetSqlNull()
            {
                base[this.tableSQL.SqlColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Sql
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSQL.SqlColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sql' in table 'SQL' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSQL.SqlColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SQLRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsUPDATE.SQLRow eventRow;

            [DebuggerNonUserCode]
            public SQLRowChangeEvent(dsUPDATE.SQLRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action =>
                this.eventAction;

            [DebuggerNonUserCode]
            public dsUPDATE.SQLRow Row =>
                this.eventRow;
        }

        public delegate void SQLRowChangeEventHandler(object sender, dsUPDATE.SQLRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class UPDATEDataTable : DataTable, IEnumerable
        {
            private DataColumn columnApplicationID;
            private DataColumn columnApplicationName;
            private DataColumn columnApplicationPath;
            private DataColumn columnNewVersion;
            private DataColumn columnOldVersion;
            private DataColumn columnPackNo;
            private DataColumn columnPriority;
            private DataColumn columnSoftType;
            private DataColumn columnUpdateLink;

            public event dsUPDATE.UPDATERowChangeEventHandler UPDATERowChanged;

            public event dsUPDATE.UPDATERowChangeEventHandler UPDATERowChanging;

            public event dsUPDATE.UPDATERowChangeEventHandler UPDATERowDeleted;

            public event dsUPDATE.UPDATERowChangeEventHandler UPDATERowDeleting;

            [DebuggerNonUserCode]
            public UPDATEDataTable()
            {
                base.TableName = "UPDATE";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal UPDATEDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            protected UPDATEDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddUPDATERow(dsUPDATE.UPDATERow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public dsUPDATE.UPDATERow AddUPDATERow(string ApplicationID, string ApplicationName, string OldVersion, string NewVersion, int Priority, string UpdateLink, int PackNo, string SoftType, string ApplicationPath)
            {
                dsUPDATE.UPDATERow row = (dsUPDATE.UPDATERow) base.NewRow();
                row.ItemArray = new object[] { ApplicationID, ApplicationName, OldVersion, NewVersion, Priority, UpdateLink, PackNo, SoftType, ApplicationPath };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsUPDATE.UPDATEDataTable table = (dsUPDATE.UPDATEDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance() => 
                new dsUPDATE.UPDATEDataTable();

            [DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator() => 
                base.Rows.GetEnumerator();

            [DebuggerNonUserCode]
            protected override Type GetRowType() => 
                typeof(dsUPDATE.UPDATERow);

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsUPDATE supdate = new dsUPDATE();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = supdate.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "UPDATEDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = supdate.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnApplicationID = new DataColumn("ApplicationID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnApplicationID);
                this.columnApplicationName = new DataColumn("ApplicationName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnApplicationName);
                this.columnOldVersion = new DataColumn("OldVersion", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOldVersion);
                this.columnNewVersion = new DataColumn("NewVersion", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNewVersion);
                this.columnPriority = new DataColumn("Priority", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPriority);
                this.columnUpdateLink = new DataColumn("UpdateLink", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUpdateLink);
                this.columnPackNo = new DataColumn("PackNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPackNo);
                this.columnSoftType = new DataColumn("SoftType", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSoftType);
                this.columnApplicationPath = new DataColumn("ApplicationPath", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnApplicationPath);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnApplicationID = base.Columns["ApplicationID"];
                this.columnApplicationName = base.Columns["ApplicationName"];
                this.columnOldVersion = base.Columns["OldVersion"];
                this.columnNewVersion = base.Columns["NewVersion"];
                this.columnPriority = base.Columns["Priority"];
                this.columnUpdateLink = base.Columns["UpdateLink"];
                this.columnPackNo = base.Columns["PackNo"];
                this.columnSoftType = base.Columns["SoftType"];
                this.columnApplicationPath = base.Columns["ApplicationPath"];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => 
                new dsUPDATE.UPDATERow(builder);

            [DebuggerNonUserCode]
            public dsUPDATE.UPDATERow NewUPDATERow() => 
                ((dsUPDATE.UPDATERow) base.NewRow());

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UPDATERowChanged != null)
                {
                    this.UPDATERowChanged(this, new dsUPDATE.UPDATERowChangeEvent((dsUPDATE.UPDATERow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UPDATERowChanging != null)
                {
                    this.UPDATERowChanging(this, new dsUPDATE.UPDATERowChangeEvent((dsUPDATE.UPDATERow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UPDATERowDeleted != null)
                {
                    this.UPDATERowDeleted(this, new dsUPDATE.UPDATERowChangeEvent((dsUPDATE.UPDATERow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UPDATERowDeleting != null)
                {
                    this.UPDATERowDeleting(this, new dsUPDATE.UPDATERowChangeEvent((dsUPDATE.UPDATERow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveUPDATERow(dsUPDATE.UPDATERow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn ApplicationIDColumn =>
                this.columnApplicationID;

            [DebuggerNonUserCode]
            public DataColumn ApplicationNameColumn =>
                this.columnApplicationName;

            [DebuggerNonUserCode]
            public DataColumn ApplicationPathColumn =>
                this.columnApplicationPath;

            [Browsable(false), DebuggerNonUserCode]
            public int Count =>
                base.Rows.Count;

            [DebuggerNonUserCode]
            public dsUPDATE.UPDATERow this[int index] =>
                ((dsUPDATE.UPDATERow) base.Rows[index]);

            [DebuggerNonUserCode]
            public DataColumn NewVersionColumn =>
                this.columnNewVersion;

            [DebuggerNonUserCode]
            public DataColumn OldVersionColumn =>
                this.columnOldVersion;

            [DebuggerNonUserCode]
            public DataColumn PackNoColumn =>
                this.columnPackNo;

            [DebuggerNonUserCode]
            public DataColumn PriorityColumn =>
                this.columnPriority;

            [DebuggerNonUserCode]
            public DataColumn SoftTypeColumn =>
                this.columnSoftType;

            [DebuggerNonUserCode]
            public DataColumn UpdateLinkColumn =>
                this.columnUpdateLink;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class UPDATERow : DataRow
        {
            private dsUPDATE.UPDATEDataTable tableUPDATE;

            [DebuggerNonUserCode]
            internal UPDATERow(DataRowBuilder rb) : base(rb)
            {
                this.tableUPDATE = (dsUPDATE.UPDATEDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsApplicationIDNull() => 
                base.IsNull(this.tableUPDATE.ApplicationIDColumn);

            [DebuggerNonUserCode]
            public bool IsApplicationNameNull() => 
                base.IsNull(this.tableUPDATE.ApplicationNameColumn);

            [DebuggerNonUserCode]
            public bool IsApplicationPathNull() => 
                base.IsNull(this.tableUPDATE.ApplicationPathColumn);

            [DebuggerNonUserCode]
            public bool IsNewVersionNull() => 
                base.IsNull(this.tableUPDATE.NewVersionColumn);

            [DebuggerNonUserCode]
            public bool IsOldVersionNull() => 
                base.IsNull(this.tableUPDATE.OldVersionColumn);

            [DebuggerNonUserCode]
            public bool IsPackNoNull() => 
                base.IsNull(this.tableUPDATE.PackNoColumn);

            [DebuggerNonUserCode]
            public bool IsPriorityNull() => 
                base.IsNull(this.tableUPDATE.PriorityColumn);

            [DebuggerNonUserCode]
            public bool IsSoftTypeNull() => 
                base.IsNull(this.tableUPDATE.SoftTypeColumn);

            [DebuggerNonUserCode]
            public bool IsUpdateLinkNull() => 
                base.IsNull(this.tableUPDATE.UpdateLinkColumn);

            [DebuggerNonUserCode]
            public void SetApplicationIDNull()
            {
                base[this.tableUPDATE.ApplicationIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetApplicationNameNull()
            {
                base[this.tableUPDATE.ApplicationNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetApplicationPathNull()
            {
                base[this.tableUPDATE.ApplicationPathColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetNewVersionNull()
            {
                base[this.tableUPDATE.NewVersionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetOldVersionNull()
            {
                base[this.tableUPDATE.OldVersionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPackNoNull()
            {
                base[this.tableUPDATE.PackNoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetPriorityNull()
            {
                base[this.tableUPDATE.PriorityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSoftTypeNull()
            {
                base[this.tableUPDATE.SoftTypeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetUpdateLinkNull()
            {
                base[this.tableUPDATE.UpdateLinkColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string ApplicationID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.ApplicationIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ApplicationID' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.ApplicationIDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string ApplicationName
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.ApplicationNameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ApplicationName' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.ApplicationNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string ApplicationPath
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.ApplicationPathColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ApplicationPath' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.ApplicationPathColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string NewVersion
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.NewVersionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'NewVersion' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.NewVersionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string OldVersion
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.OldVersionColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'OldVersion' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.OldVersionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int PackNo
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableUPDATE.PackNoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PackNo' in table 'UPDATE' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUPDATE.PackNoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int Priority
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableUPDATE.PriorityColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Priority' in table 'UPDATE' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUPDATE.PriorityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string SoftType
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.SoftTypeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SoftType' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.SoftTypeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string UpdateLink
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUPDATE.UpdateLinkColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UpdateLink' in table 'UPDATE' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUPDATE.UpdateLinkColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class UPDATERowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsUPDATE.UPDATERow eventRow;

            [DebuggerNonUserCode]
            public UPDATERowChangeEvent(dsUPDATE.UPDATERow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action =>
                this.eventAction;

            [DebuggerNonUserCode]
            public dsUPDATE.UPDATERow Row =>
                this.eventRow;
        }

        public delegate void UPDATERowChangeEventHandler(object sender, dsUPDATE.UPDATERowChangeEvent e);
    }
}

