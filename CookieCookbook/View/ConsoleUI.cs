using Ingredients;

public class ConsoleUI
{

    public Ingredient? IngredientSelection()
    {
        Console.WriteLine("HERE ARE THE AVAILABLE INGREDIENTS TO CHOOSE FROM");
        DisplayIngredients();
        Console.WriteLine("SELECT THE NUMBER TO ADD AN INGREDIENT");

        var userChoice = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(userChoice, out int result))
        {
            Ingredient? ingredient = result switch
            {
                1 => new WheatFlour(id: 1, name: "Wheat Flour"),
                2 => new CoconutFlour(id: 2, name: "Coconut flour"),
                3 => new Butter(id: 3, name: "Butter"),
                4 => new Chocolate(id: 4, name: "Chocolate"),
                5 => new Sugar(id: 5, name: "Sugar"),
                6 => new Cardamom(id: 6, name: "Cardamom"),
                7 => new Cinnamon(id: 7, name: "Cinnamon"),
                8 => new CocoaPowder(id: 8, name: "CocoaPowder"),
                _ => null

            };
            return ingredient;
        }
        return null;
    }

    public bool Menu()
    {
        Console.WriteLine("*****COOKIE COOKBOOK*****");
        Console.WriteLine("[1] CREATE A NEW COOKIE-RECIPE");
        Console.WriteLine("[2] SEE ALL CREATED RECIPES");
        Console.WriteLine("[E] EXIT");
        var userChoice = Console.ReadLine() ?? string.Empty;
        switch (userChoice)
        {
            case "1":
                CreateRecipeLoop();
                return true;
            case "2":
                DisplayRecipes();
                return true;
            case "E":
                Console.WriteLine("PROGRAM SUCCESFULLY TERMINATED");
                return false;
            default:
                Console.WriteLine("INVALID INPUT");
                return true;
        }
    }

    public void AddIngredient(List<Ingredient> ingredients) {
        Ingredient? ingredient = IngredientSelection();
        if (ingredient is not null) {
            ingredients.Add(ingredient);
            Console.WriteLine($"{ingredient} SUCCESSFULLY ADDED TO YOUR RECIPE!");
        }
    }

    public Recipe CreateRecipe(List<Ingredient> ingredients) {
        Console.WriteLine("HOW WOULD YOU LIKE TO NAME YOUR RECIPE?");
        var nameOfRecipe = Console.ReadLine() ?? string.Empty;
        var recipe = new Recipe(id: 1, name: nameOfRecipe, ingredients: ingredients);
        return recipe;
    }

    public void SaveRecipe(Recipe recipe) {
        FileService fileService = new FileService();
        fileService.WriteRecipe(recipe: recipe);
        Console.WriteLine("RECIPE SUCCESFULLY SAVED");
    }

    public void CreateRecipeLoop() {
        Console.WriteLine("CREATE YOUR RECIPE");
        List<Ingredient> ingredients = [];
        while (true) {
            Console.WriteLine("WOULD YOU LIKE TO ADD AN INGREDIENT?");
            Console.WriteLine("[Y] YES / [N] NO");
            var userChoice = Console.ReadLine() ?? string.Empty;
            if (userChoice.Equals("Y")) {
                AddIngredient(ingredients: ingredients);
            }
            else if(userChoice.Equals("N")) {
                var recipe = CreateRecipe(ingredients: ingredients);
                Console.WriteLine($"SAVE RECIPE? [Y] YES / [N] NO");
                var confirmed = Console.ReadLine() ?? string.Empty;
                if(confirmed.Equals("Y")) {
                    SaveRecipe(recipe: recipe);
                    break;
                }
                else if(confirmed.Equals("N")) {
                    Console.WriteLine("PROCESS OF CREATING COOKIE RECIPE INTERRUPTED");
                    break;
                }
            }
        }
    }

    public void Main()
    {
        while (Menu()) { }
    }
    public void DisplayRecipes()
    {
        FileService fileService = new FileService();
        List<Recipe> recipes = fileService.ReadRecipes();
        foreach (Recipe recipe in recipes)
        {
            Console.WriteLine(recipe.DisplayRecipe());
        }
    }

    public void DisplayIngredients()
    {
        FileService fileService = new FileService();
        List<Ingredient> ingredients = fileService.ReadIngredients();
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"[{ingredient.ID}] {ingredient.Name}");
        }
    }

}