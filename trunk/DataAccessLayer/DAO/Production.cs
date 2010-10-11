using System.Data;

namespace DataAccessLayer.DAO
{
    public class Production : TableEntity
    {
        public DataTable GetDailyProductions()
        {
            Select("SELECT Date, Total, (Total * 0.19) AS Vat FROM Production ORDER BY Date DESC ");
            return Table();
        }
    }
}