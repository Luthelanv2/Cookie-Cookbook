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

    private void RunRecipeCreation() {
        Console.WriteLine("Let's create a new recipe!");
        List<Ingredient> ingredients = [];
        bool running = true;
        while(running) {
            IngredientSelection(ingredients: ingredients);
            string answer = PromptToAddAnotherIngredient();
            if(answer == "N") {
                running = false;
            } 
        }
        Console.WriteLine("How would you like to name your recipe?");
        var name = Console.ReadLine() ?? "Unnamed Recipe";
        Recipe recipe = _recipeController.CreateRecipe(id: 1, name: name, ingredients: ingredients);
        _recipeController.SaveRecipe(recipe);
        Console.WriteLine($"Recipe {recipe.Name} successfully added to your cookbook!");
    }

    private string PromptToAddAnotherIngredient() {
        while (true) {
            Console.WriteLine("Would you like to add another ingredient?");
            Console.WriteLine("[Y] Yes / [N] No");
            var userChoice = Console.ReadLine() ?? string.Empty;
            if (_userInputService.ValidateQuestion(userChoice, out string validAnswer)) {
                return validAnswer;
            }
            Console.WriteLine("Invalid input, please choose Y or N.");
        }
    }
    private void IngredientSelection(List<Ingredient> ingredients) {
        Console.WriteLine("Here are all available ingredients to choose from.");
        foreach (Ingredient ingredient in _ingredientController.GetIngredients()) {
            Console.WriteLine($"[{ingredient.ID}] {ingredient.Name}");
        }

        Console.WriteLine("Select a number to add an ingredient.");
        var userChoice = Console.ReadLine() ?? string.Empty;
        if (_userInputService.ValidateRange(userChoice, out int result)) {
            Ingredient? ingredient = _ingredientController.GetIngredient(result);
            if (ingredient != null) {
                _recipeController.AddIngredient(ingredient, ingredients);
                Console.WriteLine($"{ingredient.Name} was added to your recipe.");
            }
        } 
        else {
            Console.WriteLine("Invalid input, please select a proper number.");
        }
    }
}