public class UserInputService {

    public bool ValidateRange(string prompt, out int result) {
        // min and max might be changed in the future.
        int min = 1;
        int max = 8;
        bool success = int.TryParse(prompt, out result);
        return success && result >= min && result <= max;
    }

    public bool ValidateQuestion(string prompt, out string validAnswer) {
        validAnswer = "";
        if(prompt.Equals("Y") || prompt.Equals("N")) {
            validAnswer = prompt;
            return true;
        } 
        return false;
    }
    
}