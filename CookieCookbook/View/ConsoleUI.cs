using Ingredients;
public class ConsoleUI {

    private readonly UserInputService _userInputService;
    private readonly RecipeController _recipeController;
    private readonly IngredientController _ingredientController;

    public ConsoleUI(UserInputService userInputService, RecipeController recipeController, IngredientController ingredientController) {
        _userInputService = userInputService;
        _recipeController = recipeController;
        _ingredientController = ingredientController;
    }

    public void Menu() {
        bool running = true;
        while(running) {
            Console.WriteLine("[1] CREATE COOKIE RECIPE");
            Console.WriteLine("[2] SEE ALL COOKIE RECIPES");
            Console.WriteLine("[E] EXIT COOKIE COOKBOOK");
            var userChoice = Console.ReadLine() ?? string.Empty;
            switch(userChoice) {
                case "1":
                    RunRecipeCreation();
                    break;
                case "2":
                    List<Recipe> recipes = _recipeController.GetRecipes();
                    foreach(Recipe recipe in recipes) Console.WriteLine(recipe.DisplayRecipe());
                    break;
                case "E":
                    Console.WriteLine("Exiting program..");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input..");
                    break;
            }
        }
    }

    public void RunRecipeCreation() {
        Console.WriteLine("Let's create a new recipe!");
        List<Ingredient> ingredients = [];
        bool running = true;
        while(running) {

        }
    }
}