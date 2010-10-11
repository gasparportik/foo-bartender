using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using foobartender.forms;
using Util;

namespace foobartender.GUI
{
    public class ItemManager
    {
        protected readonly Panel container;
        protected readonly Form parent;
        protected readonly ItemEditor header;

        public ItemManager(Form parent, Panel container, ItemEditor header)
        {
            this.parent = parent;
            this.container = container;
            this.container.SizeChanged += AutoSize;
            this.container.Controls.Clear();
            this.container.BorderStyle = BorderStyle.FixedSingle;
            this.header = header;
            AddItem(this.header);
        }

        public List<ItemEditor> Items
        {
            get
            {
                var list = new List<ItemEditor>();
                foreach (ItemEditor item in container.Controls)
                {
                    if (item.Header || !item.Visible) continue;
                    list.Add(item);
                }
                return list;
            }
        }

        private void AutoSize(object sender, EventArgs e)
        {
            foreach (Control item in container.Controls)
            {
                item.Size = new Size(container.Size.Width - 10, header.Size.Height);
            } 
        }

        public void AddItem(ItemEditor item)
        {
            item.Size = new Size(container.Size.Width - 10, header.Size.Height);
            item.Manager = this;
            item.Style = header.Style;
            item.NumPad = header.NumPad;
            container.Controls.Add(item);
            Renumber();
            Recalculate();
        }

        public void Delete(ItemEditor caller)
        {
            caller.Delete();
            Renumber();
            Recalculate();
        }

        public virtual void Insert(ItemEditor caller)
        {
            var add = new ItemEditor();
            AddItem(add);
            container.Controls.SetChildIndex(add, container.Controls.IndexOf(caller));
            Renumber();
        }

        public void Append(ItemEditor caller)
        {
            AddItem(new ItemEditor());
            Renumber();
        }

        public void Renumber()
        {
            var i = 0;
            foreach (ItemEditor item in container.Controls)
            {
                if (item.Header || item.Deleted) continue;
                item.ItemNumber = ++i;
            }
        }

        public void Recalculate()
        {
            var sumNet = 0D;
            var sumVat = 0D;
            foreach (ItemEditor item in container.Controls)
            {
                if (item.Header || !item.Visible) continue;
                sumNet += item.Value;
                sumVat += item.Vat;
            }
            try
            {
                if (parent.GetType().IsSubclassOf(typeof(SubItemEdit)))
                {
                    ((SubItemEdit) parent).UpdateTotals(sumNet, sumVat, sumNet + sumVat);
                } else
                {
                    var method = parent.GetType().GetMethod("UpdateTotals");
                    method.Invoke(parent, new object[] {sumNet, sumVat, sumNet + sumVat});
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        public void MakeReadOnly()
        {
            ChangeReadOnlyState(true);
        }

        public void ChangeReadOnlyState(bool readOnly)
        {
            foreach (ItemEditor item in container.Controls)
            {
                if (item.Visible)
                    item.ReadOnly = readOnly;
            }
        }

        public bool Validate(out string error)
        {
            foreach (var item in Items)
            {
                if (item.Header || !item.Visible) continue;
                string itemError;
                if (item.Validate(out itemError)) continue;
                error = "Item:" + item + ": \n" + itemError;
                return false;
            }
            error = null;
            return true;
        }

        public void Clear()
        {
            container.Controls.Clear();
            container.Controls.Add(header);
        }
    }
}