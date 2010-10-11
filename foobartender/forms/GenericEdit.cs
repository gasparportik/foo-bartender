using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using foobartender.GUI;
using Util;

namespace foobartender.forms
{
    public enum EditorType
    {
        Generic,
        ListOnly,
        SubItems
    }

    public partial class GenericEdit : InnerForm
    {
        protected TableEntity dao;
        protected DataSet data;
        protected DataRow editedRow;
        protected bool editing;
        private string filterString;
        protected TableDefinition tableDefinition;
        private readonly EditorType type;
        protected string allowedActions = "IUD";
        private Type subItemEditorType;

        public GenericEdit()
        {
            InitializeComponent();
        }

        protected GenericEdit(string formName, EditorType type)
            : this()
        {
            base.Text = formName;
            this.type = type;
        }

        protected GenericEdit(string formName, string tableName, Type daoClass, EditorType type)
            : this(formName, type)
        {
            tableDefinition = new TableDefinition(tableName);
            dao = (TableEntity)daoClass.GetConstructor(new Type[] { }).Invoke(new object[] { });
            SetupComponent();
            if (dao.LoadAll())
            {
                tableDefinition.BuildQuery();
                data = dao.Data();
                PopulateTable();
            }
        }

        protected void SetupComponent()
        {
            switch (type)
            {
                case EditorType.Generic:
                    SetupListViewer();
                    SetupEditorPanel();
                    break;
                case EditorType.ListOnly:
                    SetupListViewer();
                    lstData.Size = new Size(lstData.Size.Width, ClientSize.Height - lstData.Location.Y - 10);
                    panEditor.Visible = false;
                    panActions.Visible = false;
                    break;
                case EditorType.SubItems:
                    SetupListViewer();
                    lstData.Size = new Size(lstData.Size.Width,
                                            ClientSize.Height - lstData.Location.Y - panActions.Size.Height - 20);
                    panActions.Location = new Point(panActions.Location.X,
                                                    ClientSize.Height - panActions.Size.Height - 10);
                    panEditor.Visible = false;
                    btnDiscard.Visible = false;
                    btnSave.Visible = false;
                    var t = GetType();
                    subItemEditorType = t.Assembly.GetType(t.FullName.Replace("Edit", "SubEdit"));
                    break;
            }
        }

        private void SetupListViewer()
        {
            for (var i = 0; i < tableDefinition.columnCount; ++i)
            {
                lstData.Columns.Add(new ColumnHeader { Text = tableDefinition.Columns[i].name });
            }
        }

        private void SetupEditorPanel()
        {
            btnInsert.Visible = allowedActions.Contains("I");
            btnUpdate.Visible = allowedActions.Contains("U");
            btnDelete.Visible = allowedActions.Contains("D");
            for (var i = 0; i < tableDefinition.columnCount; ++i)
            {
                var editor = new FieldEditor(tableDefinition.Columns[i]) { Enabled = false, Size = new Size(300, 50) };
                panEditor.Controls.Add(editor);
                editor.Reset();
            }
        }

        private DataRowCollection Rows()
        {
            return data.Tables[0].Rows;
        }

        protected void PopulateTable()
        {
            lstData.Items.Clear();
            if (data != null && Rows().Count > 0)
            {
                foreach (DataRow i in Rows())
                {
                    var matched = false;
                    if (filterString != null) matched = i[0].ToString().Contains(filterString);
                    ListViewItem item = null;
                    foreach (var cd in tableDefinition.Columns)
                    {
                        var value = ValueFormatter.Format(cd.format, i[cd.colName]) ?? "";
                        if (item == null)
                        {
                            item = new ListViewItem(value);
                        }
                        else
                        {
                            item.SubItems.Add(value);
                            if (filterString != null && !matched) matched = value.Contains(filterString);
                        }
                    }
                    if (filterString != null && !matched) continue;
                    if (item != null) lstData.Items.Add(item);
                }
            }
            foreach (ColumnHeader i in lstData.Columns)
            {
                i.Width = -2;
            }
        }

        protected void AddAction(string label, string command)
        {
            var button = new Button { Text = label, Tag = command, Size = btnInsert.Size, Margin = btnInsert.Margin };
            panActions.Controls.Add(button);
            button.Click += CustomButtonClick;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            filterString = txtSearch.Text.Length > 0 ? txtSearch.Text : null;
            PopulateTable();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!allowedActions.Contains("I")) return;
            if (type == EditorType.Generic)
            {
                if (CancelEditing())
                {
                    return;
                }
                editing = true;
                SetEditorsEnabledState(true);
                editedRow = dao.Table().NewRow();
                UpdateEditors();
            }
            else
            {
                var editor = GetSubItemEditor();
                editor.CreateNew();
                MainForm.Instance.ShowChild(editor);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!allowedActions.Contains("U")) return;
            if (lstData.SelectedItems.Count <= 0) return;
            if (type == EditorType.Generic)
            {
                if (CancelEditing())
                {
                    return;
                }
                editing = true;
                SetEditorsEnabledState(true);
                dao.Id = int.Parse(lstData.SelectedItems[0].Text);
                dao.Load();
                if (dao.Row() == null) return;
                editedRow = dao.Row();
                UpdateEditors();
            }
            else
            {
                var editor = GetSubItemEditor();
                editor.LoadData(int.Parse(lstData.SelectedItems[0].Text));
                MainForm.Instance.ShowChild(editor);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!allowedActions.Contains("D")) return;
            if (lstData.SelectedItems.Count <= 0) return;
            var response = MessageBox.Show("Are you sure?", "Delete selected Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response != DialogResult.Yes) return;
            if (type == EditorType.Generic)
            {
                dao.LoadFiltered("Id = " + lstData.SelectedItems[0].Text);
                if (dao.Row() == null)
                {
                    MessageBox.Show("The row does not exist(might be deleted already).");
                    return;
                }
                if (dao.DeleteRow(dao.Row()))
                {
                    ReloadData();
                }
                else
                {
                    MessageBox.Show("Could not delete row.");
                }
            }
            else
            {
                var editor = GetSubItemEditor();
                editor.LoadData(int.Parse(lstData.SelectedItems[0].Text));
                editor.Delete();
                ReloadData();
            }
        }

        private void CustomButtonClick(object sender, EventArgs e)
        {
            CustomCommand(((Button)sender).Tag.ToString());
        }

        protected virtual void CustomCommand(string command)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected virtual void Save()
        {
            if (!editing) return;
            if (!ValidateEditors())
            {
                MessageBox.Show("Some fields were incorrectly completed!", "Invalid values", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            UpdateEditedRow();
            var ret = dao.SaveRow(editedRow);
            if (ret <= 0)
            {
                if (ret == -1)
                {
                    const string warningtext = "The record has been altered after you've opened it. Are you sure you want to update anyways? (Modifications of the other user will be lost)";
                    if (MessageBox.Show(this, warningtext, "Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dao.ForcedSaveRow(editedRow) <= 0)
                        {
                            return;
                        }
                    } else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Some error occured!");
                    return;
                }
            }
            SetEditorsEnabledState(false);
            editing = false;
            ReloadData();
            ResetEditors();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (CancelEditing())
            {
                return;
            }
            SetEditorsEnabledState(false);
            editing = false;
            ResetEditors();
        }

        protected void ReloadData()
        {
            dao.LoadAll();
            data = dao.Data();
            PopulateTable();
        }

        private void UpdateEditors()
        {
            ResetEditors();
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    var b = ValueFormatter.FormatHidesValue(i.Column.format) && editedRow.RowState != DataRowState.Detached;
                    i.ReadOnly = b;
                    i.UseFormatter = b;
                    i.UpdateValueFrom(ref editedRow);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        protected void ResetEditors()
        {
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    i.Reset();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        protected void UpdateEditedRow()
        {
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    i.UpdateValueTo(ref editedRow);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        protected void SetEditorsEnabledState(bool enabled)
        {
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    i.Enabled = enabled;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        protected bool ValidateEditors()
        {
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    if (!i.IsValid())
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        public override void ClosingNotification(InnerForm form)
        {
            ReloadData();
        }

        private bool CancelEditing()
        {
            if (!editing) return false;
            var modified = false;
            try
            {
                foreach (FieldEditor i in panEditor.Controls)
                {
                    modified = i.Modified;
                    if (modified) break;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            if (!modified) return false;
            return MessageBox.Show("Are you sure?", "Cancel changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private SubItemEdit GetSubItemEditor()
        {
            var editor = (SubItemEdit)subItemEditorType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            editor.NotifiedForms.Add(this);
            return editor;
        }
    }
}