using System.Text;
using Ingredients;

public class Recipe(int id, string name, List<Ingredient> ingredients)
{
    public int ID { get; set; } = id;
    public string Name { get; set; } = name;
    public List<Ingredient> Ingredients { get; set; } = ingredients;

    public void AddIngredient(Ingredient ingredient) => Ingredients.Add(ingredient);

    public void RemoveIngredient(Ingredient ingredient) => Ingredients.Remove(ingredient);

    public override string ToString() => $"ID: {ID}\nName: {Name}\nIngredients:\n{string.Join(Environment.NewLine, Ingredients)}";

    public string DisplayRecipe() {
        var displayedRecipe = new StringBuilder();
        displayedRecipe.AppendLine($"*****{this.ID}*****");
        displayedRecipe.AppendLine($"{this.Name}");
        foreach(Ingredient ingredient in Ingredients) {
            displayedRecipe.AppendLine($"{ingredient.Name}. {ingredient.Instructions()}");
        }
        return displayedRecipe.ToString();
    }
}