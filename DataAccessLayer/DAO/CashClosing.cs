using System.Data;

namespace DataAccessLayer.DAO
{
    public class CashClosing : TableEntity
    {

        public DataTable GetDailyCashClosings()
        {
            Select("SELECT Date, Total, (Total * 0.19) AS Vat FROM CashClosing ORDER BY Date DESC ");
            return Table();
        }
    }
}