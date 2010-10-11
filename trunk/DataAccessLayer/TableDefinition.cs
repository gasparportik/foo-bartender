using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccessLayer
{
    public class TableDefinition
    {
        public int columnCount;
        private ColumnDefinition[] columns;
        public List<string> filters;
        public string tableName;

        public TableDefinition(string tableName)
        {
            this.tableName = tableName;
            filters = new List<string>();
            LoadDefinition();
        }

        //indexer for columns with arrayindex
        public ColumnDefinition this[int pos]
        {
            get
            {
                return pos < columnCount ? Columns[pos] : null;
            }
        }

        //indexer for columns with columnid index
        public ColumnDefinition this[string colId]
        {
            get
            {
                for (var i = 0; i < columnCount; ++i)
                {
                    if (Columns[i].id.Equals(colId))
                    {
                        return Columns[i];
                    }
                }
                return null;
            }
        }

        public ColumnDefinition[] Columns
        {
            get
            {
                if (columns == null)
                {
                    LoadDefinition();
                }
                return columns;
            }
        }

        private void LoadDefinition()
        {
            var tableDef = Database.Instance.GetTableStructure(tableName);
            columnCount = tableDef.Rows.Count;
            if (columnCount == 0) return;
            columns = new ColumnDefinition[columnCount];
            for (var i = 0; i < columnCount; ++i)
            {
                var d = tableDef.Rows[i];
                var charlen = (d["MaxLen"].ToString().Length == 0) ? 0 : int.Parse(d["MaxLen"].ToString());
                Columns[i] = new ColumnDefinition(tableName, d["Name"].ToString(), d["Type"].ToString(),
                                                  d["Nullable"].ToString().Equals("YES"), d["DefaultValue"].ToString(), charlen);
            }
        }


        public string BuildQuery(bool allowJoins)
        {
            var joins = "";
            var query = "SELECT ";
            string lastJoinedTable = null;
            foreach (var i in Columns)
            {
                if (i != Columns[0]) query += ", ";
                if (!allowJoins || i.joinTableName == null)
                {
                    query += tableName + "." + i.id;
                }
                else
                {
                    string joinAs = null;
                    if (lastJoinedTable != null && i.joinTableName == lastJoinedTable)
                    {
                        joinAs = lastJoinedTable + "1";
                        i.colName = (joinAs ?? i.joinTableName) + i.joinColumnName;
                    }
                    lastJoinedTable = i.joinTableName;
                    query += (joinAs ?? i.joinTableName) + "." + i.joinColumnName + " AS " + (joinAs ?? i.joinTableName) + i.joinColumnName;
                    query += ", " + i.tableName + "." + i.id + " AS " + i.id;
                    joins += " LEFT JOIN " + i.joinTableName;
                    if (joinAs != null) joins += " AS " + joinAs;
                    joins += " ON " + (joinAs ?? i.joinTableName) + ".Id = " + tableName + "." + i.id;
                }
            }
            query += " FROM \"" + tableName + "\"";
            var where = " WHERE ";
            if (filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    if (filter != filters[0]) where += " AND ";
                    where += filter;
                }
            }
            else
            {
                where = "";
            }
            return query + joins + where;
        }

        public string BuildQuery()
        {
            return BuildQuery(true);
        }

        public string BuildUpdateQuery(DataRow row)
        {
            var query = "UPDATE " + tableName + " SET ";
            for (var i = 1; i < Columns.Count(); ++i)
            {
                if (i > 1) query += ", ";
                query += Columns[i].id + " = ";
                if (row[Columns[i].id].Equals(DBNull.Value))
                {
                    query += "NULL "; }
                else
                {
                    query += "'" + row[Columns[i].id] + "' ";
                }
            }
            //row.Table.
            query += " WHERE " + Columns[0].id + " = " + row[0];
            return query;
        }

        public string BuildInsertQuery(DataRow row)
        {
            var query = "INSERT INTO " + tableName + " (";
            var values = ") VALUES (";
            for (var i = 1; i < Columns.Count(); ++i)
            {
                if (i > 1)
                {
                    query += ", ";
                    values += ", ";
                }
                query += Columns[i].id;
                if (row[Columns[i].id].Equals(DBNull.Value))
                {
                    values += "NULL ";
                }
                else
                {
                    values += "'" + row[Columns[i].id] + "' ";
                }
            }
            return query + values + ")";
        }

        public string BuildDeleteQuery(DataRow row)
        {
            return "DELETE FROM " + tableName + " WHERE " + Columns[0].id + " = " + row[Columns[0].colName];
        }
    }
}