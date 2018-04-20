namespace Vssoft.Common.Common.Class
{
    using System;

    public class RowClickEventArgs
    {
        private int _mColumnIndex;
        private string _mFieldName;
        private int _mRowIndex;

        public RowClickEventArgs()
        {
            this._mRowIndex = -1;
            this._mColumnIndex = -1;
            this._mFieldName = "";
        }

        public RowClickEventArgs(int rowIndex, int columnIndex)
        {
            this._mRowIndex = rowIndex;
            this._mColumnIndex = columnIndex;
            this._mFieldName = "";
        }

        public RowClickEventArgs(int rowIndex, string fieldName)
        {
            this._mRowIndex = rowIndex;
            this._mColumnIndex = -1;
            this._mFieldName = fieldName;
        }

        public RowClickEventArgs(int rowIndex, int columnIndex, string fieldName)
        {
            this._mRowIndex = rowIndex;
            this._mColumnIndex = columnIndex;
            this._mFieldName = fieldName;
        }

        public void Reset()
        {
            this._mRowIndex = -1;
            this._mColumnIndex = -1;
            this._mFieldName = "";
        }

        public void Set(int RowIndex, int ColumnIndex, string FieldName)
        {
            this._mRowIndex = RowIndex;
            this._mColumnIndex = ColumnIndex;
            this._mFieldName = FieldName;
        }

        public int ColumnIndex
        {
            get => 
                this._mColumnIndex;
            set
            {
                this._mColumnIndex = value;
            }
        }

        public string FieldName
        {
            get => 
                this._mFieldName;
            set
            {
                this._mFieldName = value;
            }
        }

        public int RowIndex
        {
            get => 
                this._mRowIndex;
            set
            {
                this._mRowIndex = value;
            }
        }
    }
}

