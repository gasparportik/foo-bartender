using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer.DAO;
using foobartender.GUI;
using foobartender.Properties;
using Util;

namespace foobartender.forms
{
    public partial class OrderForm : InnerForm
    {
        private TablesView parent;
        private Sale sale;
        private SaloonTable table;
        private int selectedProductId;
        private readonly ItemManager itemManager;
        private readonly ItemEditor iHeader;
        private readonly int tableId;
        private readonly NumPad numPad;

        private OrderForm()
        {
            closable = true;
            singleton = false;
            InitializeComponent();
            numPad = new NumPad();
            Controls.Add(numPad);
            numPad.BringToFront();
            iHeader = new ItemEditor { Header = true, Style = ItemEditorStyle.SaleItemEditor, NumPad = numPad, Size = new Size(1000,40)};
            itemManager = new SaleItemManager(this, panItems, iHeader);
        }

        public OrderForm(int saleId, int tableId)
            : this()
        {
            this.tableId = tableId;
            sale = new Sale(saleId);
            SetupComponent();
            LoadOrder();
        }

        public OrderForm(int tableId)
            : this()
        {
            this.tableId = tableId;
            SetupComponent();
            AddOrder();
        }

        private void SetupComponent()
        {
            LoadCategories();
            table = new SaloonTable(tableId);
            txtTable.Text = table["Name"] == null ? "No table" : table["Name"].ToString();
        }

        public void SetParent(TablesView tv)
        {
            parent = tv;
        }

        private void AddOrder()
        {
            sale = new Sale(tableId, MainForm.AccountId);
            if (!sale.Order())
            {
                MessageBox.Show(this,"Failed to create order!");
                Dispose();
            } else
            {
                sale.Load();
            }
        }

        private void LoadOrder()
        {
            sale.Load();
            itemManager.Clear();
            foreach (DataRow row in sale.Items)
            {
                var editor = new ItemEditor();
                itemManager.AddItem(editor);
                editor.UpdateFromRow(row);
            }
        }

        private void LoadCategories()
        {
            LoadCategoryIcons();
            var category = new Category();
            category.LoadAll();
            foreach (DataRow i in category.Table().Rows)
            {
                lstCategories.Items.Add(new ListViewItem(i["Name"].ToString()) { ImageIndex = 0, Tag = i["Id"].ToString() });
            }
        }

        private void LoadCategoryIcons()
        {
            var imageList = new ImageList {ImageSize = new Size(48, 48), ColorDepth = ColorDepth.Depth32Bit};
            imageList.Images.Add(Resources.button);
            lstCategories.LargeImageList = imageList;
        }

        private void LoadProducts(int categoryId)
        {
            LoadProductIcons();
            lstProducts.Items.Clear();
            var products = new Product();
            if (!products.LoadByCategory(categoryId)) return;
            foreach (DataRow i in products.Table().Rows)
            {
                lstProducts.Items.Add(new ListViewItem(i["Name"].ToString()) { ImageIndex = 0, Tag = i["Id"].ToString() });
            }
        }

        private void LoadProductIcons()
        {
            var imageList = new ImageList { ImageSize = new Size(48, 48), ColorDepth = ColorDepth.Depth32Bit };
            imageList.Images.Add(Resources.meal);
            lstProducts.LargeImageList = imageList;
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var categoryId = Convert.ToInt32(lstCategories.SelectedItems[0].Tag);
                LoadProducts(categoryId);
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedProductId = int.Parse(lstProducts.SelectedItems[0].Tag.ToString());
            }
            catch
            {
                selectedProductId = 0;
            }
        }

        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            foreach (var item in itemManager.Items)
            {
                if (item.UpdateRow()) continue;
                var row = sale.AddItem();
                item.UpdateRow(ref row);
            }
            sale.Save();
        }

        private void AddProduct(int productId)
        {
            if (productId <= 0) return;
            foreach (var editor in itemManager.Items)
            {
                if (editor.ProductId != productId || editor.ReadOnly) continue;
                editor.Quantity++;
                return;
            }
            var item = new ItemEditor();
            itemManager.AddItem(item);
            item.ProductId = selectedProductId;
            item.Quantity = 1D;
        }

        private void lstProducts_DoubleClick(object sender, EventArgs e)
        {
            AddProduct(selectedProductId);
        }

        private void ScrollCategories(object sender, EventArgs e)
        {
            if (lstCategories.Items.Count == 0) return;
            if (sender.Equals(btnCatScrollUp))
            {
                lstCategories.Items[0].EnsureVisible();
            }
            else
            {
                lstCategories.Items[lstCategories.Items.Count - 1].EnsureVisible();
            }
        }

        public void UpdateTotals(double net, double vat, double total)
        {
            txtTotal.Text = Converter.ToString(total);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Save();
            Hide();
            parent.LoadTables();
        }

        public void DeliverItem(ItemEditor editor)
        {
            Save();
            if (sale.DeliverItem(editor.Row))
            {
                editor.ReadOnly = true;
            } else
            {
                MessageBox.Show("There is not enough quantity on the stock.");
            }
        }
    }
}