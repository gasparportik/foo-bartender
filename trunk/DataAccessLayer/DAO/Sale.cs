using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DataAccessLayer.DAO
{
    public class Sale : SubItem
    {
        private readonly int waiterId;
        private int tableId;

        public Sale()
        {
            tabledef = new TableDefinition("Sale");
            subTableDef = new TableDefinition("SaleItem");
        }

        public Sale(int saleId)
            : this()
        {
            ((TableEntity) this).Id = saleId;
            Load();
            waiterId = this["AccountId"].ToInt();
            tableId = this["SaloonTableId"].ToInt();
        }

        public Sale(int tableId, int waiterId)
            : this()
        {
            this.tableId = tableId;
            this.waiterId = waiterId;
        }

        private bool ModifyTable(int action)
        {
            return ExecuteScalar("ModifyTable", new Hashtable { { "@Action", action }, { "@TableId", tableId }, { "@AccountId", waiterId } }) == 0;
        }

        public bool Order()
        {
            return ModifyTable(1);
        }

        public bool Occupy()
        {
            return ModifyTable(2);
        }

        public bool Release()
        {
            return ModifyTable(3);
        }

        public override bool Save()
        {
            return ((TableEntity) this).Id > 0 ? Update() : false;
        }

        public DataTable GetSalesForDay(int year, int month, int day)
        {
            DateTime now = DateTime.Now;
            if (year == 0) year = now.Year;
            if (month == 0) month = now.Month;
            if (day == 0) day = now.Day;
            String query = "SELECT P.Name, SUM(SI.Quantity), SUM(SI.Price) " +
                           "FROM Sale S INNER JOIN SaleItem SI ON SI.SaleId = S.Id " +
                           "INNER JOIN Product P ON P.Id = SI.ProductId " +
                           "WHERE YEAR(S.Date) = " + year + " AND MONTH(S.Date) = " + month + " AND DAY(S.Date) = " +
                           day + " " +
                           "GROUP BY P.Name ";
            Select(query);
            return Table();
        }

        public void InsertItem(string productId, string quantity, string unitId, string price)
        {
            Execute("INSERT INTO SaleItem VALUES(" + Id + ", " + productId + ", " + quantity + ", " + unitId + ", " +
                    price + ")");
        }

        public float GetTotal()
        {
            Select("SELECT SUM(Price) FROM SaleItem WHERE SaleId = " + Id);
            return Scalar().Equals(DBNull.Value) ? 0F : float.Parse(Scalar().ToString());
        }

        public bool DeliverItem(DataRow row)
        {
            var success = Select("SELECT Sa.SectionId FROM Saloon Sa INNER JOIN SaloonTable ST ON ST.Id = " +
                      DbValue.ToString(this["SaloonTableId"]) + " AND ST.SaloonId = Sa.Id");
            if (!success) return false;
            var section = DbValue.ToInt(Scalar());
            if (connection.State != ConnectionState.Open)
                connection.Open();
            var t = connection.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                var callCommand = new SqlCommand("DeductStockForProduct", connection, t);
                callCommand.CommandType = CommandType.StoredProcedure;
                callCommand.Parameters.AddWithValue("@ProductId", row["ProductId"]);
                callCommand.Parameters.AddWithValue("@SectionId", section);
                callCommand.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                var returnValue = new SqlParameter
                                      {
                                          ParameterName = "@Ret",
                                          Direction = ParameterDirection.ReturnValue,
                                          DbType = DbType.Int32
                                      };
                callCommand.Parameters.Add(returnValue);
                callCommand.ExecuteNonQuery();
                var ret = DbValue.ToInt(callCommand.Parameters["@Ret"].Value);
                if (ret > 0) throw new Exception();
                callCommand =
                    new SqlCommand("UPDATE SaleItem SET Delivered = 1 WHERE Id = " + DbValue.ToString(row["Id"]),
                                   connection, t);
                if (callCommand.ExecuteNonQuery() == 0) throw new Exception();
                t.Commit();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
                t.Rollback();
                connection.Close();
                return false;
            }
        }
    }
}