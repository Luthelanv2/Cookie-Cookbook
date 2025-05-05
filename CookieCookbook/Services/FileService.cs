using System.Text.Json;
using Ingredients;

public class FileService
{
    public readonly string IngredientsLocation = @"D:\Coding_Documents\C#\CookieCookbook\Data\Ingredients.txt";
    public readonly string RecipesLocation = @"D:\Coding_Documents\C#\CookieCookbook\Data\Recipes.txt";

    public Task WriteRecipe(Recipe recipe) => Write(fileLocation: RecipesLocation, item: recipe);
    public Task WriteIngredient(Ingredient ingredient) => Write(fileLocation: IngredientsLocation, item: ingredient);
    public List<Recipe> ReadRecipes() => Read<Recipe>(fileLocation: RecipesLocation);
    public List<Ingredient> ReadIngredients() => Read<Ingredient>(fileLocation: IngredientsLocation);

    private async Task Write<T>(string fileLocation, T item) {
        try {
            var options = new JsonSerializerOptions { WriteIndented = false };
            var asJson = JsonSerializer.Serialize(value: item, options: options);
            await using StreamWriter writer = new StreamWriter(path: fileLocation, append: true);
            await writer.WriteLineAsync(asJson);
        } catch(IOException exception) {
            Console.WriteLine(exception.Message);
        } catch(JsonException exception) {
            Console.WriteLine(exception.Message);
        }
    }

    private List<T> Read<T>(string fileLocation) {
        List<T> items = [];
        try {
            var options = new JsonSerializerOptions {};
            using StreamReader reader = new(path: fileLocation);
            string? line;
            while ((line = reader.ReadLine()) is not null) {
                var item = JsonSerializer.Deserialize<T>(line, options);
                    if (item is not null) {
                        items.Add(item);
                    }
            }
        } catch(IOException exception) {
            Console.WriteLine(exception.Message);
        } catch(JsonException exception) {
            Console.WriteLine(exception.Message);
        }
        return items;
    }
}