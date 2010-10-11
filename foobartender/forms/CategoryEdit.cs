using DataAccessLayer.DAO;

namespace foobartender.forms
{
    public class CategoryEdit : GenericEdit
    {
        public CategoryEdit() : base("Product categories", "Category", typeof(Category), EditorType.Generic) { }
    }
}
