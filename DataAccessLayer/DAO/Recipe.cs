namespace DataAccessLayer.DAO
{
    public class Recipe : SubItem
    {
        public Recipe()
        {
            tabledef = new TableDefinition("Recipe");
            subTableDef = new TableDefinition("RecipeItem");
        }
    }
}