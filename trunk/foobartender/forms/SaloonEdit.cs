using DataAccessLayer.DAO;

namespace foobartender.forms
{
    class SaloonEdit : GenericEdit
    {
        public SaloonEdit() : base("Saloons", "Saloon", typeof(Saloon), EditorType.Generic) { }
    }
}
