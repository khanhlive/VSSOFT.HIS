namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.Utils.Menu;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Menu;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class GridViewColumnButtonMenu : GridViewMenu
    {
        private string PathXml;

        public GridViewColumnButtonMenu(GridView view) : base(view)
        {
            this.PathXml = Application.StartupPath + @"\LayoutGrid";
        }

        protected override void CreateItems()
        {
            base.Items.Clear();
            DXSubMenuItem item = new DXSubMenuItem("Danh S\x00e1ch C\x00e1c Cột") {
                Image = GridMenuImages.Column.Images[5]
            };
            base.Items.Add(item);
            base.Items.Add(base.CreateMenuItem("Tuỳ Chọn Cột", GridMenuImages.Column.Images[4], "Customization", true));
            base.Items.Add(base.CreateMenuItem("Co Gi\x00e3n Cột", GridMenuImages.Column.Images[6], "BestFit", true));
            if (base.View.OptionsView.ShowGroupPanel)
            {
                //base.Items.Add(this.CreateMenuItem("Ẩn Khung Nh\x00f3m Dữ Liệu", null, "HideGroupPanel", true, true));
            }
            else
            {
                //base.Items.Add(this.CreateMenuItem("Hiện Khung Nh\x00f3m Dữ Liệu", null, "ShowGroupPanel", true, true));
            }
            //base.Items.Add(this.CreateMenuCheckItem("Chọn Hết", false, null, "SelectAll", true, true));
            //base.Items.Add(this.CreateMenuItem("Bỏ Chọn", null, "UnSelectAll", true, false));
            //base.Items.Add(this.CreateMenuItem("Lưu Lại Vị Tr\x00ed V\x00e0 Sắp Xếp C\x00e1c Cột", null, "SaveLayout", true, true));
            //base.Items.Add(base.CreateMenuItem("Lấy Lại Vị Tr\x00ed V\x00e0 Sắp Xếp Mặc Định", null, "DefaultLayout", true));
            foreach (GridColumn column in base.View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                {
                    item.Items.Add(base.CreateMenuCheckItem(column.GetTextCaption(), column.VisibleIndex >= 0, null, column, true));
                }
            }
        }

        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (!this.RaiseClickEvent(sender, null))
            {
                DXMenuItem item = sender as DXMenuItem;
                if (item.Tag != null)
                {
                    if (item.Tag is GridColumn)
                    {
                        GridColumn tag = item.Tag as GridColumn;
                        tag.VisibleIndex = (tag.VisibleIndex >= 0) ? -1 : base.View.VisibleColumns.Count;
                    }
                    else if (item.Tag.ToString() == "Customization")
                    {
                        base.View.ColumnsCustomization();
                    }
                    else if (item.Tag.ToString() == "BestFit")
                    {
                        base.View.BestFitColumns();
                    }
                    else if (item.Tag.ToString() != "Filter")
                    {
                        if (item.Tag.ToString() == "HideGroupPanel")
                        {
                            base.View.OptionsView.ShowGroupPanel = false;
                        }
                        else if (item.Tag.ToString() == "ShowGroupPanel")
                        {
                            base.View.OptionsView.ShowGroupPanel = true;
                        }
                        else if (item.Tag.ToString() == "SelectAll")
                        {
                            base.View.SelectAll();
                        }
                        else if (item.Tag.ToString() == "UnSelectAll")
                        {
                            base.View.ClearSelection();
                        }
                        else if (item.Tag.ToString() == "SaveLayout")
                        {
                            try
                            {
                                string pathXml = this.PathXml;
                                if (!Directory.Exists(pathXml))
                                {
                                    Directory.CreateDirectory(pathXml);
                                    if (!Directory.Exists(pathXml))
                                    {
                                        return;
                                    }
                                }
                                if ((this.ParentControlName == "") || (this.ParentControlName == null))
                                {
                                    base.View.SaveLayoutToXml(this.PathXml + @"\" + this.ParentControl.Name + ".xml", OptionsLayoutBase.FullLayout);
                                }
                                else
                                {
                                    base.View.SaveLayoutToXml(this.PathXml + @"\" + this.ParentControlName + ".xml", OptionsLayoutBase.FullLayout);
                                }
                            }
                            catch
                            {
                            }
                        }
                        else if (item.Tag.ToString() == "DefaultLayout")
                        {
                            try
                            {
                                FileInfo info;
                                if ((this.ParentControlName == "") || (this.ParentControlName == null))
                                {
                                    info = new FileInfo(this.PathXml + @"\" + this.ParentControl.Name + ".xml");
                                }
                                else
                                {
                                    info = new FileInfo(this.PathXml + @"\" + this.ParentControlName + ".xml");
                                }
                                info.Delete();
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        public void RestoreLayout()
        {
            try
            {
                if ((this.ParentControlName == "") || (this.ParentControlName == null))
                {
                    base.View.RestoreLayoutFromXml(this.PathXml + @"\" + this.ParentControl.Name + ".xml", OptionsLayoutBase.FullLayout);
                }
                else
                {
                    base.View.RestoreLayoutFromXml(this.PathXml + @"\" + this.ParentControlName + ".xml", OptionsLayoutBase.FullLayout);
                }
            }
            catch
            {
            }
        }

        public Control ParentControl { get; set; }

        public string ParentControlName { get; set; }
    }
}

