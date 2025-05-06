FileService fileService = new FileService();
RecipeController recipeController = new RecipeController(fileService: fileService);
IngredientController ingredientController = new IngredientController(fileService: fileService);
UserInputService userInputService = new UserInputService();

ConsoleUI consoleUI = new ConsoleUI(recipeController: recipeController, userInputService: userInputService, ingredientController: ingredientController);
consoleUI.Menu();