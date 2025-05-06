public class UserInputService {

    public bool ValidateRange(string prompt, out int result) {
        // min and max might be changed in the future.
        int min = 1;
        int max = 8;
        bool success = int.TryParse(prompt, out result);
        return success && result >= min && result <= max;
    }

    public void ValidateQuestion(string prompt) {
        if(prompt.Equals("Y")) {

        }
        else if(prompt.Equals("N")) {
            
        }
    }
    
}