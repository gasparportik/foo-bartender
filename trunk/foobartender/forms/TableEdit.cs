using DataAccessLayer.DAO;

namespace foobartender.forms
{
    internal class TableEdit : GenericEdit
    {
        public TableEdit() : base("Saloon tables", "SaloonTable", typeof (SaloonTable), EditorType.Generic)
        {
        }
    }
}