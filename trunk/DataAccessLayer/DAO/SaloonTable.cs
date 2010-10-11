namespace DataAccessLayer.DAO
{
    public class SaloonTable : TableEntity
    {
        public SaloonTable()
        {
        }

        public SaloonTable(int id) :this()
        {
            this.Id = id;
            Load();
        }
    }
}