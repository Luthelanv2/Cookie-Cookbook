namespace Ingredients;
public class CoconutFlour(int id, string name) : Ingredient(id, name)
{
    public override string Instructions() => $"Sieve. Add to other ingredients.";
    public override string ToString() => $"{Name}";
}