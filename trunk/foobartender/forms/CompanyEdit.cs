using DataAccessLayer.DAO;

namespace foobartender.forms
{
    public class CompanyEdit : GenericEdit
    {
        public CompanyEdit() : base("Partner companies", "Company", typeof(Company), EditorType.Generic) { }
    }
}
