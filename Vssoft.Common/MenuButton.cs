namespace Vssoft.Common
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Designer("Bar")]
    public class MenuButton
    {
        private ItemCommand _add = new ItemCommand();
        private ItemCommand _cancel = new ItemCommand();
        private ItemCommand _change = new ItemCommand();
        private ItemCommand _close = new ItemCommand();
        private ItemCommand _custom = new ItemCommand();
        private ItemCommand _delete = new ItemCommand();
        private ItemCommand _export = new ItemCommand();
        private ItemCommand _filter = new ItemCommand();
        private ItemCommand _filterCustomer = new ItemCommand();
        private ItemCommand _filterStock = new ItemCommand();
        private ItemCommand _find = new ItemCommand();
        private ItemCommand _go = new ItemCommand();
        private ItemCommand _import = new ItemCommand();
        private ItemCommand _next = new ItemCommand();
        private ItemCommand _pageSetup = new ItemCommand();
        private ItemCommand _previous = new ItemCommand();
        private ItemCommand _print = new ItemCommand();
        private ItemCommand _printPreview = new ItemCommand();
        private ItemCommand _redo = new ItemCommand();
        private ItemCommand _refresh = new ItemCommand();
        private ItemCommand _save = new ItemCommand();
        private ItemCommand _saveAndClose = new ItemCommand();
        private ItemCommand _saveAndNew = new ItemCommand();
        private ItemCommand _search = new ItemCommand();
        private ItemCommand _searchText = new ItemCommand();
        private ItemCommand _task = new ItemCommand();
        private ItemCommand _undo = new ItemCommand();
        private ItemCommand _vaildate = new ItemCommand();
        private ItemCommand _view = new ItemCommand();

        [DisplayName("Add"), Category("Bar")]
        public ItemCommand Add
        {
            get => 
                this._add;
            set
            {
                this._add = value;
            }
        }

        public ItemCommand Cancel
        {
            get => 
                this._cancel;
            set
            {
                this._cancel = value;
            }
        }

        [Category("Bar"), DisplayName("Change")]
        public ItemCommand Change
        {
            get => 
                this._change;
            set
            {
                this._change = value;
            }
        }

        public ItemCommand Close
        {
            get => 
                this._close;
            set
            {
                this._close = value;
            }
        }

        public ItemCommand Custom
        {
            get => 
                this._custom;
            set
            {
                this._custom = value;
            }
        }

        public ItemCommand Delete
        {
            get => 
                this._delete;
            set
            {
                this._delete = value;
            }
        }

        public ItemCommand Export
        {
            get => 
                this._export;
            set
            {
                this._export = value;
            }
        }

        public ItemCommand Filter
        {
            get => 
                this._filter;
            set
            {
                this._filter = value;
            }
        }

        public ItemCommand FilterCustomer
        {
            get => 
                this._filterCustomer;
            set
            {
                this._filterCustomer = value;
            }
        }

        public ItemCommand FilterStock
        {
            get => 
                this._filterStock;
            set
            {
                this._filterStock = value;
            }
        }

        public ItemCommand Find
        {
            get => 
                this._find;
            set
            {
                this._find = value;
            }
        }

        public bool GClose { get; set; }

        public bool GCommand { get; set; }

        public bool GExport { get; set; }

        public ItemCommand Go
        {
            get => 
                this._go;
            set
            {
                this._go = value;
            }
        }

        public bool GOption { get; set; }

        public bool GPrint { get; set; }

        public bool GRecords { get; set; }

        public bool GSearchBar { get; set; }

        public bool GSettings { get; set; }

        public bool GVaildation { get; set; }

        public ItemCommand Import
        {
            get => 
                this._import;
            set
            {
                this._import = value;
            }
        }

        public ItemCommand Next
        {
            get => 
                this._next;
            set
            {
                this._next = value;
            }
        }

        public ItemCommand PageSetup
        {
            get => 
                this._pageSetup;
            set
            {
                this._pageSetup = value;
            }
        }

        public bool PHome { get; set; }

        public ItemCommand Previous
        {
            get => 
                this._previous;
            set
            {
                this._previous = value;
            }
        }

        public ItemCommand Print
        {
            get => 
                this._print;
            set
            {
                this._print = value;
            }
        }

        public ItemCommand PrintPreview
        {
            get => 
                this._printPreview;
            set
            {
                this._printPreview = value;
            }
        }

        public bool PTool { get; set; }

        public ItemCommand Redo
        {
            get => 
                this._redo;
            set
            {
                this._redo = value;
            }
        }

        public ItemCommand Refresh
        {
            get => 
                this._refresh;
            set
            {
                this._refresh = value;
            }
        }

        public ItemCommand Save
        {
            get => 
                this._save;
            set
            {
                this._save = value;
            }
        }

        public ItemCommand SaveAndClose
        {
            get => 
                this._saveAndClose;
            set
            {
                this._saveAndClose = value;
            }
        }

        public ItemCommand SaveAndNew
        {
            get => 
                this._saveAndNew;
            set
            {
                this._saveAndNew = value;
            }
        }

        public ItemCommand Search
        {
            get => 
                this._search;
            set
            {
                this._search = value;
            }
        }

        public ItemCommand SearchText
        {
            get => 
                this._searchText;
            set
            {
                this._searchText = value;
            }
        }

        public ItemCommand Task
        {
            get => 
                this._task;
            set
            {
                this._task = value;
            }
        }

        public ItemCommand Undo
        {
            get => 
                this._undo;
            set
            {
                this._undo = value;
            }
        }

        public ItemCommand Vaildate
        {
            get => 
                this._vaildate;
            set
            {
                this._vaildate = value;
            }
        }

        public ItemCommand View
        {
            get => 
                this._view;
            set
            {
                this._view = value;
            }
        }
    }
}

