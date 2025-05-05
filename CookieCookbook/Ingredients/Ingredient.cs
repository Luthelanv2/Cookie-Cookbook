using System.Text.Json.Serialization;

namespace Ingredients;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Butter), "Butter")]
[JsonDerivedType(typeof(Cardamom), "Cardamom")]
[JsonDerivedType(typeof(Chocolate), "Chocolate")]
[JsonDerivedType(typeof(Cinnamon), "Cinnamon")]
[JsonDerivedType(typeof(CocoaPowder), "CocoaPowder")]
[JsonDerivedType(typeof(CoconutFlour), "CoconutFlour")]
[JsonDerivedType(typeof(Sugar), "Sugar")]
[JsonDerivedType(typeof(WheatFlour), "WheatFlour")]
public abstract class Ingredient(int id, string name)
{
    public int ID { get; set; } = id;
    public string Name { get; set; } = name;

    public abstract string Instructions();
}