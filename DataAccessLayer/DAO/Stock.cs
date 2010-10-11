using System.Data;

namespace DataAccessLayer.DAO
{
    public class Stock : TableEntity
    {
        public Stock()
        {
            tabledef = new TableDefinition("Stock");
        }

        public DataTable GetCurrentStock()
        {
            var query =
                "SELECT P.Name AS ProductName, SUM(S.Quantity) AS QuantIn, U.Name AS Unit, SUM(S2.Quantity) AS QuantOut " +
                ", SUM(S.Price) AS PriceIn, SUM(S2.Price) AS PriceOut " +
                "FROM Stock S  " +
                "LEFT JOIN Stock S2 ON S2.ProductId = S.ProductId AND S2.Action = 'CON' " +
                "INNER JOIN Product P ON P.Id = S.ProductId " +
                "INNER JOIN Unit U ON U.Id = P.UnitId " +
                "WHERE S.Action = 'REC' " +
                "GROUP BY P.Name, U.Name";
            Select(query);
            foreach (DataRow i in Table().Rows)
            {
                if (!i.IsNull("QuantOut"))
                {
                    i["QuantIn"] = int.Parse(i["QuantIn"].ToString()) - int.Parse(i["QuantOut"].ToString());
                    i["QuantOut"] = int.Parse(i["PriceIn"].ToString()) - int.Parse(i["PriceOut"].ToString());
                }
                else
                {
                    i["QuantOut"] = i["PriceIn"];
                }
            }
            return Table();
        }
    }
}