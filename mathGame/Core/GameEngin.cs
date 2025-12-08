namespace mathGame.Core;

public class GameEngine
{
    private readonly Random _random = new();
    
    public int GenerateQuestion(int questionNumber, out string questionText)
    {
        int firstNumber = _random.Next(1, 100);
        int secondNumber = _random.Next(1, 100);
        int operation = _random.Next(4);
        
        return operation switch
        {
            0 => GenerateAddition(firstNumber, secondNumber, questionNumber, out questionText),
            1 => GenerateSubtraction(firstNumber, secondNumber, questionNumber, out questionText),
            2 => GenerateMultiplication(firstNumber, secondNumber, questionNumber, out questionText),
            3 => GenerateDivision(firstNumber, secondNumber, questionNumber, out questionText),
            _ => throw new InvalidOperationException("Invalid operation")
        };
    }
    
    private static int GenerateAddition(int a, int b, int questionNumber, out string question)
    {
        question = $"Question {questionNumber}: {a} + {b} = ?";
        return a + b;
    }
    
    private static int GenerateSubtraction(int a, int b, int questionNumber, out string question)
    {
        question = $"Question {questionNumber}: {a} - {b} = ?";
        return a - b;
    }
    
    private static int GenerateMultiplication(int a, int b, int questionNumber, out string question)
    {
        question = $"Question {questionNumber}: {a} × {b} = ?";
        return a * b;
    }
    
    private int GenerateDivision(int a, int b, int questionNumber, out string question)
    {
        while (a % b != 0)
        {
            a = _random.Next(1, 100);
            b = _random.Next(1, 100);
        }
        
        question = $"Question {questionNumber}: {a} ÷ {b} = ?";
        return a / b;
    } 
}