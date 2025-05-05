namespace Ingredients;
public class Cinnamon(int id, string name) : Ingredient(id, name)
{
    public override string Instructions() => $"Take half a teaspoon. Add to other ingredients.";
    public override string ToString() => $"{Name}";
}