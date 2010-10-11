using DataAccessLayer.DAO;

namespace foobartender.forms
{
    internal class RecipeEdit : GenericEdit
    {
        public RecipeEdit()
            : base("Recipes", "Recipe", typeof(Recipe), EditorType.SubItems)
        {
        }
    }
}