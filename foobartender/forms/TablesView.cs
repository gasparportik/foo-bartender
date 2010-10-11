using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer.DAO;
using foobartender.Properties;
using Util;

namespace foobartender.forms
{
    public partial class TablesView : InnerForm
    {
        private readonly Saloon saloon;
        private readonly int saloonId;

        public TablesView(int saloonId)
        {
            InitializeComponent();
            this.saloonId = saloonId;
            saloon = new Saloon(this.saloonId);
            Text = saloon.Name;
            LoadListImages();
            LoadTables();
            btnOccupy.Click += EventHandler;
            btnOrder.Click += EventHandler;
            btnRelease.Click += EventHandler;
            lstTables.DoubleClick += EventHandler;
        }

        private void LoadListImages()
        {
            var imageList = new ImageList { ImageSize = new Size(72, 72) };
            try
            {
                imageList.Images.Add(Resources.tableOccupied);
                imageList.Images.Add(Resources.tableOrder);
                imageList.Images.Add(Resources.tableFree);
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            lstTables.LargeImageList = imageList;
        }

        public void LoadTables()
        {
            saloon.LoadTables();
            lstTables.Items.Clear();
            foreach (DataRow i in saloon.Table().Rows)
            {
                var itemName = i["Name"].ToString();
                if (!i[1].ToString().Equals("FREE"))
                {
                    itemName += "(" + i["Waiter"] + ")";
                }
                var item = new ListViewItem(itemName);
                item.SubItems.Add(i["Id"].ToString());
                item.SubItems.Add(i["Status"].ToString());
                item.SubItems.Add(i["Waiter"].ToString());
                item.SubItems.Add(i["WaiterId"].ToString());
                item.SubItems.Add(i["SaleId"].ToString());


                item.ImageIndex = 0;
                if (i[2].ToString().Equals("FREE"))
                {
                    item.ImageIndex = 2;
                }
                if (i[2].ToString().Equals("WAI"))
                {
                    item.ImageIndex = 1;
                }
                lstTables.Items.Add(item);
            }
        }

        private void EventHandler(Object sender, EventArgs e)
        {
            string tableStatus = "";
            int tableId = 0;
            if (lstTables.SelectedItems.Count > 0)
            {
                tableStatus = lstTables.SelectedItems[0].SubItems[2].Text;
                tableId = int.Parse(lstTables.SelectedItems[0].SubItems[1].Text);
            }
            if (tableId == 0 && !sender.Equals(lstTables))
            {
                LoadTables();
                return;
            }
            if (sender.Equals(btnOccupy))
            {
                if (tableStatus.Equals("FREE"))
                {
                    Occupy(tableId);
                }
                else
                {
                    MessageBox.Show("Only a free table can be occupied");
                }
            }
            if (sender.Equals(btnOrder))
            {
                if (tableStatus.Equals("WAI"))
                {
                    if (int.Parse(lstTables.SelectedItems[0].SubItems[4].Text) == MainForm.AccountId)
                    {
                        EditOrder(int.Parse(lstTables.SelectedItems[0].SubItems[5].Text), tableId);
                    }
                    else
                    {
                        MessageBox.Show("You can't edit another waiters/waitress' order!");
                    }
                }
                else
                {
                    if (tableStatus.Equals("OCC"))
                    {
                        if (int.Parse(lstTables.SelectedItems[0].SubItems[4].Text) == MainForm.AccountId)
                        {
                            NewOrder(tableId);
                        }
                        else
                        {
                            MessageBox.Show("You can't edit another waiters/waitress' occupation!");
                        }
                    }
                    else
                    {
                        NewOrder(tableId);
                    }
                }
            }
            if (sender.Equals(btnRelease))
            {
                if (tableStatus.Equals("FREE"))
                {
                    MessageBox.Show("This table is not occupied");
                }
                else
                {
                    if (int.Parse(lstTables.SelectedItems[0].SubItems[4].Text) == MainForm.AccountId)
                    {
                        Free(int.Parse(lstTables.SelectedItems[0].SubItems[5].Text));
                    }
                    else
                    {
                        MessageBox.Show("You can't release another waiters/waitress' table!");
                    }
                }
            }
            if (sender.Equals(lstTables))
            {
                if (tableId > 0)
                {
                    EventHandler(btnOrder, e);
                }
            }
            LoadTables();
        }

        private void EditOrder(int saleId, int tableId)
        {
            var form = new OrderForm(saleId, tableId);
            form.NotifiedForms.Add(this);
            form.SetParent(this);
            MainForm.Instance.ShowChild(form);
        }

        private void NewOrder(int tableId)
        {
            var form = new OrderForm(tableId);
            form.NotifiedForms.Add(this);
            form.SetParent(this);
            MainForm.Instance.ShowChild(form);
        }

        private void Occupy(int tableId)
        {
            if (new Sale(tableId, MainForm.AccountId).Occupy())
            {
                LoadTables();
            }
            else
            {
                MessageBox.Show(this, "Failed to occupy table!");
            }
        }

        private void Free(int saleId)
        {
            var sale = new Sale(saleId);
            var ordered = sale["Status"].ToString().Equals("WAI");
            if (sale.Release())
            {
                if (!ordered) return;
                var price = sale.GetTotal();
                MessageBox.Show(this, "You must be paid: " + price + " in $");
            }
            else
            {
                MessageBox.Show(this, "Failed to release table.");
            }
        }
    }
}