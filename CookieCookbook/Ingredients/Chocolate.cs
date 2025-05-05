namespace  Ingredients;

public class Chocolate(int id, string name) : Ingredient(id, name)
{
    public override string Instructions() => $"Melt in a water bath. Add to other ingredients.";
    public override string ToString() => $"{Name}";
}