using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DataAccessLayer
{
    public class TableEntity : DAL
    {
        protected int id;
        protected TableDefinition tabledef;
        protected DataTable values;
        protected SqlDataAdapter mainAdapter;

        public DbValue this[string key]
        {
            get
            {
                try
                {
                    return new DbValue(values.Rows[0][key]);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Exception(this, ex);
                    return new DbValue(null);
                }
            }
            set
            {
                if (values == null)
                {
                    LoadFiltered(tabledef.tableName + ".Id = 0");
                    values = Table();
                }
                if (values.Rows.Count == 0)
                {
                    values.Rows.Add(values.NewRow());
                }
                try
                {
                    values.Rows[0][key] = value.ToDb();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Exception(this, ex);
                }
            }
        }

        protected TableEntity()
        {
            tabledef = new TableDefinition(GetType().Name);
        }

        protected TableEntity(int id) : this()
        {
            this.id = id;
            Load();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DataProxy[] AsDataProxies()
        {
            if (dataSet == null) return null;
            var list = new List<DataProxy>();
            foreach (DataRow row in Table().Rows)
            {
                list.Add(new DataProxy(row, "Name"));
            }
            return list.ToArray();
        }

        public bool Load()
        {
            LoadFiltered(tabledef.tableName + ".Id = " + id);
            mainAdapter = adapter;
            values = Table();
            return Row() != null;
        }

        public bool LoadById(int id)
        {
            this.id = id;
            return Load();
        }

        public bool LoadAll()
        {
            return Select(tabledef.BuildQuery());
        }

        public bool LoadFiltered(string filter)
        {
            var query = tabledef.BuildQuery(false);
            if (filter != null)
            {
                query += " WHERE ";
                if (!filter.StartsWith(tabledef.tableName))
                {
                    query += tabledef.tableName + ".";
                }
                query += filter;
            }

            return Select(query);
        }

        protected virtual int SaveRow(DataRow row, bool forced)
        {
            LoadById(0);
            var cb = new SqlCommandBuilder(mainAdapter);
            mainAdapter.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
            mainAdapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);

            cb.ConflictOption = forced ? ConflictOption.OverwriteChanges : ConflictOption.CompareAllSearchableValues;
            mainAdapter.InsertCommand = cb.GetInsertCommand();
            var r = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.Add(r);
            r.ItemArray = row.ItemArray;
            try
            {
                var res = mainAdapter.Update(dataSet);
                return 1;
            }
            catch (DBConcurrencyException ex)
            {
                Logger.Instance.Exception(this, ex);
                return -1;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                return 0;
            }
        }

        protected static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args)
        {
            if (args.StatementType == StatementType.Delete)
            {
                System.IO.TextWriter tw = System.IO.File.AppendText("Deletes.log");
                tw.WriteLine(
                  "{0}: Customer {1} Deleted.", DateTime.Now,
                   args.Row["CustomerID", DataRowVersion.Original]);
                tw.Close();
            }
        }

        protected static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
        {
            if (args.Status == UpdateStatus.ErrorsOccurred)
            {
                args.Row.RowError = args.Errors.Message;
                args.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        public int SaveRow(DataRow row)
        {
            return SaveRow(row, false);
        }

        public int ForcedSaveRow(DataRow row)
        {
            return SaveRow(row, true);
        }

        public virtual bool DeleteRow(DataRow row)
        {
            return Execute(tabledef.BuildDeleteQuery(row));
        }

        protected int GetInsertId()
        {
            int insertId;
            try
            {
                connection.Open();
                insertId = int.Parse(
                    new SqlCommand("SELECT IDENT_CURRENT('" + tabledef.tableName + "')", connection).ExecuteScalar()
                        .
                        ToString());
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                insertId = 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return insertId;
        }

        public virtual bool Create()
        {
            // this may be implemented to create a new Row
            return false;
        }
    }
}