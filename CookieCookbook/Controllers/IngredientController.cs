using Ingredients;

public class IngredientController {
    private FileService _fileService;

    public IngredientController(FileService fileService) {
        _fileService = fileService;
    }
    public Ingredient? GetIngredient(int id) {
        return id switch {
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
    }

    public List<Ingredient> GetIngredients() => _fileService.ReadIngredients();
}