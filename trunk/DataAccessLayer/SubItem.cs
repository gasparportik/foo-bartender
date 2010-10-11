using System;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DataAccessLayer
{
    public abstract class SubItem : TableEntity
    {
        protected SqlDataAdapter subAdapter;
        protected TableDefinition subTableDef;
        protected DataTable items;

        protected SubItem()
        {
        }

        protected SubItem(int id) : base(id)
        {
        }

        public new DbValue this[String key]
        {
            get
            {
                if (values != null && values.Rows.Count > 0 && values.Columns.Contains(key))
                {
                    return new DbValue(values.Rows[0][key]);
                }
                return null;
            }
            set { values.Rows[0][key] = value.ToDb(); }
        }

        public DataRowCollection Items
        {
            get { return items.Rows; }
        }
        public virtual bool CreateNew()
        {
            values.Rows.Add(values.NewRow());
            return true;
        }

        public new virtual bool Load()
        {
            tabledef.filters.Clear();
            tabledef.filters.Add(tabledef.tableName + ".Id = " + base.Id);
            Select(tabledef.BuildQuery(false));
            mainAdapter = adapter;
            new SqlCommandBuilder(mainAdapter);
            values = Table();
            subTableDef.filters.Clear();
            subTableDef.filters.Add(subTableDef.tableName + "." + tabledef.tableName + "Id = " + base.Id);
            Select(subTableDef.BuildQuery(false));
            subAdapter = adapter;
            new SqlCommandBuilder(subAdapter);
            items = Table();
            return (values != null) ? values.Rows.Count > 0 : false;
        }

        public virtual bool Save()
        {
            return base.Id > 0 ? Update() : Create();
        }

        public override bool Create()
        {
            try
            {
                mainAdapter.Update(values);
                base.Id = GetInsertId();
                foreach (DataRow item in items.Rows)
                {
                    item[tabledef.tableName + "Id"] = base.Id;
                }
                subAdapter.Update(items);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        public virtual bool Update()
        {
            try
            {
                mainAdapter.Update(values);
                foreach (DataRow item in items.Rows)
                {
                    if (item.RowState == DataRowState.Added)
                        item[tabledef.tableName + "Id"] = base.Id;
                }
                subAdapter.Update(items);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        public virtual bool Delete()
        {
            try
            {
                values.Rows[0].Delete();
                foreach (DataRow item in items.Rows)
                {
                    item.Delete();
                }
                subAdapter.Update(items);
                mainAdapter.Update(values);
                return true;
            }
            catch (ArrayTypeMismatchException ex)
            {
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        public virtual DataRow AddItem(int productId, float amount)
        {
            var row = items.NewRow();
            row["ProductId"] = productId;
            row["Amount"] = amount;
            return row;
        }

        public virtual DataRow AddItem()
        {
            var row = items.NewRow();
            items.Rows.Add(row);
            return row;
        }

        public virtual bool Commit()
        {
            return false;
        }
    }
}