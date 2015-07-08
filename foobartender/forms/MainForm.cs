using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using Util;

namespace foobartender.forms
{
    public partial class MainForm : Form
    {
        private static int accountId;
        private static MainForm instance;
        private List<Account> accounts;
        private Account activeAccount;
        private List<Form> children;
        private bool fullScreen;
        private LogonForm logonForm;
        private readonly Dictionary<int, List<Form>> storedForms;

        private MainForm()
        {
            InitializeComponent();
            children = new List<Form>();
            storedForms = new Dictionary<int, List<Form>>();
            SetMenuState(false);
            SetupLogon();
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public static int AccountId
        {
            get { return accountId; }
        }

        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm();
                }
                return instance;
            }
        }

        private void SetupLogon()
        {
            activeAccount = new Account();
            accounts = new List<Account>();
            ShowChild(logonForm = new LogonForm(this));
            //Login("cpotter", "12589");
            Login("jsmith", "kovacs");
            //new ProductEdit().ShowDialog();
        }

        public void AddChild(InnerForm child)
        {
            child.Icon = Icon;
            if (child.Singleton)
            {
                Form oldForm = null;
                foreach (var form in children)
                {
                    if (!form.GetType().Equals(child.GetType())) continue;
                    if (form.Visible)
                    {
                        child.Dispose();
                        return;
                    }
                    oldForm = form;
                    Logger.Instance.Warning("THERE CAN BE ONLY ONE... singleton form:" + child);
                }
                if (oldForm != null)
                {
                    children.Remove(oldForm);
                    oldForm.Dispose();
                }
                UpdateWindowsMenu();
            }
            children.Add(child);
            child.MdiParent = this;
            child.WindowState = FormWindowState.Maximized;
            if (child.HandleClosing)
                child.Closing += ChildWindowClosing;
            UpdateWindowsMenu();
        }

        private void ChildWindowClosing(object sender, CancelEventArgs e)
        {
            var form = (InnerForm)sender;
            foreach (var notifiedForm in form.NotifiedForms)
            {
                notifiedForm.ClosingNotification(form);
            }
            if (form.Closable)
            {
                form.Dispose();
                children.Remove(form);
            }
            else
            {
                form.Hide();
                e.Cancel = true;
            }
            UpdateWindowsMenu();
        }

        public void ShowChild(InnerForm child)
        {
            AddChild(child);
            if (!child.IsDisposed)
            {
                child.Show();
            }
        }

        private void ShowEditor(int type)
        {
            switch (type)
            {
                case Constants.CATEGORY_TABLE:
                    ShowChild(new CategoryEdit());
                    break;
                case Constants.PRODUCT_TABLE:
                    ShowChild(new ProductEdit());
                    break;
                case Constants.RECEPTION_TABLE:
                    ShowChild(new ReceptionEdit());
                    break;
                case Constants.RECIPE_TABLE:
                    ShowChild(new RecipeEdit());
                    break;
                case Constants.SALE_TABLE:
                    ShowChild(new SaleEdit());
                    break;
                case Constants.SALOON_TABLE:
                    ShowChild(new SaloonEdit());
                    break;
                case Constants.TABLE_TABLE:
                    ShowChild(new TableEdit());
                    break;
                case Constants.UNIT_TABLE:
                    ShowChild(new UnitEdit());
                    break;
                case Constants.WAITER_TABLE:
                    ShowChild(new AccountEdit());
                    break;
                case Constants.BANK_TABLE:
                    ShowChild(new BankEdit());
                    break;
                case Constants.COMPANY_TABLE:
                    ShowChild(new CompanyEdit());
                    break;
                case Constants.SECTION_TABLE:
                    ShowChild(new SectionEdit());
                    break;
                case Constants.TRANSFER_TABLE:
                    ShowChild(new TransferEdit());
                    break;
                case Constants.INVOICE_TABLE:
                    ShowChild(new InvoiceEdit());
                    break;
            }
        }

        private void ShowQueryResult(ColumnHeader[] headers, DataTable data)
        {
            ShowChild(new DataView(data, headers));
        }

        private void ShowHelpPanel()
        {
            ShowChild(new HelpForm());
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.CATEGORY_TABLE);
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.PRODUCT_TABLE);
        }

        private void waitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.WAITER_TABLE);
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.UNIT_TABLE);
        }

        private void saloonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.SALOON_TABLE);
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.TABLE_TABLE);
        }

        private void recipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.RECIPE_TABLE);
        }

        private void receptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.RECEPTION_TABLE);
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.SALE_TABLE);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stock = new Stock();
            var headers = new[]
                              {
                                  new ColumnHeader{Text = "ProductName", Width = 500},
                                  new ColumnHeader{Text = "Quantity", Width = 100},
                                  new ColumnHeader{Text = "Unit", Width = 100},
                                  new ColumnHeader{Text = "Price", Width = 100}
                              };
            ShowQueryResult(headers, stock.GetCurrentStock());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void showHelpPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHelpPanel();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sale = new Sale();
            var headers = new ColumnHeader[3];
            headers[0] = new ColumnHeader();
            headers[0].Text = "ProductName";
            headers[0].Width = 500;
            headers[1] = new ColumnHeader();
            headers[1].Text = "Quantity";
            headers[1].Width = 100;
            headers[2] = new ColumnHeader();
            headers[2].Text = "Price";
            headers[2].Width = 100;
            ShowQueryResult(headers, sale.GetSalesForDay(0, 0, 0));
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cc = new CashClosing();
            var headers = new ColumnHeader[3];
            headers[0] = new ColumnHeader();
            headers[0].Text = "Date";
            headers[0].Width = 500;
            headers[1] = new ColumnHeader();
            headers[1].Text = "Amount";
            headers[1].Width = 100;
            headers[2] = new ColumnHeader();
            headers[2].Text = "VAT";
            headers[2].Width = 100;
            ShowQueryResult(headers, cc.GetDailyCashClosings());
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prod = new Production();
            var headers = new ColumnHeader[3];
            headers[0] = new ColumnHeader();
            headers[0].Text = "Date";
            headers[0].Width = 500;
            headers[1] = new ColumnHeader();
            headers[1].Text = "Amount";
            headers[1].Width = 100;
            headers[2] = new ColumnHeader();
            headers[2].Text = "VAT";
            headers[2].Width = 100;
            ShowQueryResult(headers, prod.GetDailyProductions());
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var headers = new ColumnHeader[2];
            headers[0] = new ColumnHeader();
            headers[0].Text = "Date";
            headers[0].Width = 500;
            headers[1] = new ColumnHeader();
            headers[1].Text = "Balance";
            headers[1].Width = 100;
            ShowQueryResult(headers, Database.Instance.GetBalance());
        }

        private void generateCashClosingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Database.CallProcedure("GenerateCashClosing", null);
                MessageBox.Show("Action executed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Action execution failed due to error: " + ex.Message);
            }
        }

        private void generateProductionNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Database.CallProcedure("GenerateProduction", null);
                MessageBox.Show("Action executed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Action execution failed due to error: " + ex.Message);
            }
        }

        private void UpdateWindowsMenu()
        {
            mnuShowWindow.DropDownItems.Clear();
            foreach (var child in children)
            {
                //if (!child.Visible) continue;
                var item = new ToolStripMenuItem(child.Text) { Tag = child };
                item.Click += ShowChildWindow;
                mnuShowWindow.DropDownItems.Add(item);
            }
        }

        private void ShowChildWindow(object sender, EventArgs e)
        {
            ((Form)((ToolStripMenuItem)sender).Tag).BringToFront();
        }

        private void SetAdminMenu()
        {
            SetMenuState(false);
            mnuActions.Visible = true;
            mnuManage.Visible = true;
            mnuQueries.Visible = true;
            mnuHelp.Visible = true;
            MainMenuStrip.Font = new Font("Arial", 9F);
        }

        private void SetAccountantMenu()
        {
            SetMenuState(false);
            mnuManage.Visible = true;
            mnuHelp.Visible = true;
            MainMenuStrip.Font = new Font("Arial", 9F);
        }

        private void SetWaiterMenu()
        {
            SetMenuState(false);
            mnuHelp.Visible = true;
            mnuWaiter.Visible = true;
            SetWaiterMenuItems();
            MainMenuStrip.Font = new Font("Arial", 16F);
        }

        private void SetMenuState(bool enabled)
        {
            mnuActions.Visible = enabled;
            mnuManage.Visible = enabled;
            mnuQueries.Visible = enabled;
            mnuWaiter.Visible = enabled;
            mnuHelp.Visible = enabled;
        }

        private void SetWaiterMenuItems()
        {
            mnuWaiter.DropDownItems.Clear();
            var saloons = new Saloon();
            saloons.LoadAll();
            foreach (DataRow i in saloons.Table().Rows)
            {
                var item = new ToolStripMenuItem(i["Name"] + " tables") { Tag = i[0].ToString() };
                item.Click += ShowSaloonView;
                mnuWaiter.DropDownItems.Add(item);
            }
        }

        private void ShowSaloonView(Object sender, EventArgs e)
        {
            ShowChild(new TablesView(int.Parse(((ToolStripMenuItem)sender).Tag.ToString())));
        }

        public void Login(string username, string password)
        {
            DAL.SetLogin(username, password);
            if (activeAccount.Login(username, password))
            {
                accountId = activeAccount.Id;
                try
                {
                    Account current = null;
                    foreach (var a in accounts)
                    {
                        if (a.Id == accountId) current = a;
                    }
                    accounts.Remove(current);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Exception(this, ex);
                }
                finally
                {
                    accounts.Add((Account)activeAccount.Clone());
                }
                switch (activeAccount.AccessLevel)
                {
                    case 1:
                        SetAdminMenu();
                        break;
                    case 2:
                        SetAccountantMenu();
                        break;
                    case 3:
                        SetWaiterMenu();
                        break;
                    default:
                        Logger.Instance.Log("Corrupted value for AccessLevel for account with id:" + activeAccount.Id);
                        break;
                }
                mnuUsername.Text = activeAccount.Name;
                foreach (var i in children)
                {
                    i.Visible = false;
                }
                if (storedForms.Keys.Contains(accountId))
                {
                    children = storedForms[accountId];
                    foreach (var i in children)
                    {
                        if (!i.IsDisposed)
                        {
                            i.Visible = true;
                        }
                    }
                }
                else
                {
                    children = new List<Form>();
                    storedForms[accountId] = children;
                }
                logonForm.Hide();
                mnuShowWindow.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Can't log in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUsername_Click(object sender, EventArgs e)
        {
            ShowLogon();
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fullScreen)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                fullScreen = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                fullScreen = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuState(false);
            if (accountId <= 0) return;
            try
            {
                foreach (Account a in accounts)
                {
                    if (a.Id == accountId) accounts.Remove(a);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            accountId = 0;
            mnuUsername.Text = "";
            ShowLogon();
        }

        private void ShowLogon()
        {
            logonForm.WindowState = FormWindowState.Maximized;
            logonForm.Show();
            SetMenuState(false);
            mnuShowWindow.Enabled = false;
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.BANK_TABLE);
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.COMPANY_TABLE);
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.INVOICE_TABLE);
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.SECTION_TABLE);
        }

        private void transfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditor(Constants.TRANSFER_TABLE);
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in children)
            {
                child.WindowState = FormWindowState.Minimized;
            }
        }
    }
}