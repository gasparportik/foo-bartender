using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using foobartender.Properties;
using Util;

namespace foobartender.GUI
{
    public partial class FieldEditor : UserControl
    {
        private const int LETTER_WIDTH = 7;
        private ColumnDefinition column;
        private Control mainControl;
        private bool modified;
        private bool readOnly;
        private bool useFormatter;
        private object value;

        public FieldEditor()
        {
            InitializeComponent();
        }

        public FieldEditor(ColumnDefinition columnDefinition)
            : this()
        {
            column = columnDefinition;
            SetupComponent();
        }

        public ColumnDefinition Column
        {
            get { return column; }
            set { column = value; }
        }

        public bool Modified
        {
            get { return modified; }
        }

        public bool UseFormatter
        {
            get { return useFormatter; }
            set
            {
                useFormatter = value;
                UpdateComponent();
            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                UpdateComponent();
            }
        }

        public object Value
        {
            get { return value; }
            set
            {
                Logger.Instance.Log("New value for " + column.id + " is " + value);
                this.value = value;
                UpdateValue();
            }
        }

        private void SetupComponent()
        {
            BorderStyle = BorderStyle.FixedSingle;
            if (column == null)
            {
                return;
            }
            panControls.Controls.Add(new Label { Text = column.name, Size = new Size(500, 15) });
            if (column.joinColumnName == null)
            {
                switch (column.type)
                {
                    case "bit":
                        mainControl = new CheckBox();
                        ((CheckBox)mainControl).CheckedChanged += CheckboxChanged;
                        break;
                    case "tinyint":
                    case "int":
                        mainControl = new NumericUpDown();
                        ((NumericUpDown)mainControl).Maximum = int.MaxValue;
                        break;
                    case "float":
                    case "char":
                    case "varchar":
                        mainControl = new TextBox();
                        ((TextBox)mainControl).MaxLength = column.length;
                        break;
                    default:
                        mainControl = new Label();
                        break;
                }
                //this.mainControl.Size = new Size(50, 20);
                //this.mainControl.Anchor = AnchorStyles.Left & AnchorStyles.Right;
                mainControl.Text = (string)column.defaultValue ?? "";
                mainControl.Tag = column.id;
                if (column.id.Equals("Id"))
                {
                    mainControl.Enabled = false;
                }
                panControls.Controls.Add(mainControl);
                mainControl.TextChanged += BoxChanged;
                if (column.length > 10)
                {
                    var s = mainControl.Size;
                    s.Width = Math.Min(column.length * LETTER_WIDTH + 10, Size.Width - 10);
                    mainControl.Size = s;
                }
            }
            else
            {
                var cmb = new ComboBox
                              {
                                  Size = new Size(150 - 50, 20),
                                  Text = column.type,
                                  Tag = column.id,
                                  Enabled = true,
                                  DropDownStyle = ComboBoxStyle.DropDownList
                              };
                cmb.Items.AddRange(column.GetItems());
                cmb.Items.Add(DataHolder.NullValue);
                panControls.Controls.Add(cmb);
                mainControl = cmb;
                cmb.SelectedIndexChanged += ComboboxChanged;
            }
        }

        private void UpdateComponent()
        {
            mainControl.Enabled = !readOnly;
            if (useFormatter)
            {
                mainControl.Text = ValueFormatter.Format(column.format, value);
            }
        }

        private void UpdateValue()
        {
            if (column.id.Equals("Id"))
            {
                readOnly = true;
                if (value == null || value.ToString().Equals("")) value = 0;
            }
            if (value != null)
            {
                if (mainControl.GetType().Equals(typeof(ComboBox)))
                {
                    if (value == null || value == DBNull.Value)
                    {
                        ((ComboBox)mainControl).SelectedItem = null;
                    }
                    else
                    {
                        foreach (DataHolder i in ((ComboBox)mainControl).Items)
                        {
                            if (i["value"] != null && i["value"].ToString().Equals(value.ToString()))
                            {
                                ((ComboBox)mainControl).SelectedItem = i;
                            }
                        }
                    }
                }
                else if (mainControl.GetType().Equals(typeof(CheckBox)))
                {
                    ((CheckBox)mainControl).Checked = value != null && Boolean.Parse(value.ToString());
                }
                else
                {
                    mainControl.Text = (value == null ? "" : value.ToString());
                }
            }
            else
            {
                mainControl.Text = "";
            }
            UpdateComponent();
        }

        public void UpdateValueFrom(ref DataRow dataRow)
        {
            Value = dataRow[column.id];
        }

        public void UpdateValueTo(ref DataRow dataRow)
        {
            dataRow[column.id] = Value ?? DBNull.Value;
        }

        private void CheckboxChanged(object sender, EventArgs e)
        {
            modified = true;
            value = ((CheckBox)mainControl).Checked ? 1 : 0;
        }

        private void ComboboxChanged(object sender, EventArgs e)
        {
            try
            {
                var newValue = ((DataHolder)((ComboBox)mainControl).SelectedItem)["value"];
                modified = value == null || newValue == null || !newValue.Equals(value.ToString());
                value = newValue;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        private void BoxChanged(object sender, EventArgs e)
        {
            Logger.Instance.Log(sender.ToString());
            try
            {
                modified = value == null || !mainControl.Text.Equals(value.ToString());
                value = mainControl.Text;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        private void FieldEditor_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValid();
        }

        private void FieldEditor_Validated(object sender, EventArgs e)
        {
        }

        public bool IsValid()
        {
            var valid = (((Value == null || Value == DBNull.Value) && column.nullable) || (Value != null && column.GetRegex().IsMatch(Value.ToString())));
            imgValidation.Image = valid ? Resources.valid : Resources.invalid;
            return valid;
        }

        public void Reset()
        {
            imgValidation.Image = null;
            modified = false;
            Value = null;
        }
    }
}