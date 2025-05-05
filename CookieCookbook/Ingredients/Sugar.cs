namespace Ingredients;
public class Sugar(int id, string name) : Ingredient(id, name)
{
    public override string Instructions() => $"Add to other ingredients.";
    public override string ToString() => $"{Name}";
}