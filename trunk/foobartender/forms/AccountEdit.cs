using System.Data;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DAO;
using foobartender.GUI;

namespace foobartender.forms
{
    public class AccountEdit : GenericEdit
    {
        private readonly FieldEditor passwordEditor;

        public AccountEdit()
            : base("Accounts", EditorType.Generic)
        {
            allowedActions = "ID";
            tableDefinition = new TableDefinition("Account");
            dao = new Account();
            AddAction("Change password", "CH_PWD");
            AddAction("(Un)Suspend", "CH_SUSP");
            SetupComponent();
            passwordEditor = new FieldEditor(new ColumnDefinition("Account", "Password", "varchar", false, null, 30)) { Enabled = false, Size = panEditor.Controls[0].Size };
            panEditor.Controls.Add(passwordEditor);
            passwordEditor.Reset();
            if (!dao.LoadAll()) return;
            data = dao.Data();
            PopulateTable();
        }

        protected override void Save()
        {
            if (!editing) return;
            if (!ValidateEditors())
            {
                MessageBox.Show("Some fields were incorrectly completed!", "Invalid values", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            UpdateEditedRow();
            if (editedRow.RowState == DataRowState.Detached || editedRow.RowState == DataRowState.Added)
            {
                foreach (DataColumn column in editedRow.Table.Columns)
                {
                    dao[column.ToString()] = new DbValue(editedRow[column]);
                }
                ((Account)dao).Password = passwordEditor.Value.ToString();
                if (!dao.Create())
                {
                    MessageBox.Show("Failed to create new user!", "Invalid values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (dao.SaveRow(editedRow) == 0)
            {
                MessageBox.Show("Some error occured!");
                return;
            }
            SetEditorsEnabledState(false);
            editing = false;
            ReloadData();
            ResetEditors();
        }

        protected override void CustomCommand(string command)
        {
            if (command.Equals("CH_PWD"))
            {
                if (lstData.SelectedItems.Count <= 0) return;
                var newPassword = InputDialogBox.Show("Enter new password", "", "Password change",true);
                if (newPassword == null) return;
                var accountId = int.Parse(lstData.SelectedItems[0].Text);
                if (new Account(accountId).ChangePassword(newPassword))
                {
                    MessageBox.Show(this, "Password changed.", "New Password", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Password could not be changed.", "New Password", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            if (command.Equals("CH_SUSP"))
            {
                if (lstData.SelectedItems.Count <= 0) return;
                var accountId = int.Parse(lstData.SelectedItems[0].Text);
                if (accountId == MainForm.AccountId)
                {
                    MessageBox.Show(this, "Can't suspend your own account!", "Suspension", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return;
                }
                if (new Account(accountId).ChangeSuspensionState())
                {
                    MessageBox.Show(this, "Suspension changed.", "Suspension", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ReloadData();
                }
                else
                {
                    MessageBox.Show(this, "Failed to change suspension.", "Suspension", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}