using Ingredients;

public class RecipeController {

    private FileService _fileService;

    public RecipeController(FileService fileService) {
        _fileService = fileService;
    }

    public void AddIngredient(Ingredient ingredient, List<Ingredient> ingredients) {
        if (ingredient is not null) ingredients.Add(ingredient);
    }
    public Recipe CreateRecipe(int id, string name, List<Ingredient> ingredients) => new Recipe(id: id, name: name, ingredients: ingredients); 
    public void SaveRecipe(Recipe recipe) => _fileService.WriteRecipe(recipe: recipe);
    public List<Recipe> GetRecipes() => _fileService.ReadRecipes();


}