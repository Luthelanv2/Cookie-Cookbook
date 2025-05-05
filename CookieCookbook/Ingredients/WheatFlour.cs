namespace Ingredients;
public class WheatFlour(int id, string name) : Ingredient(id, name)
{
    public override string Instructions() => $"Sieve. Add to other ingredients.";
    public override string ToString() => $"{Name}";
}