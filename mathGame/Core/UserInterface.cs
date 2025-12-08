namespace mathGame.Core;

public class UserInterface 
{
    public void DisplayMenu()
    {
        Console.WriteLine("\n=== MATH GAME ===");
        Console.WriteLine("P - Play Game");
        Console.WriteLine("H - View Score History");
        Console.WriteLine("Q - Quit");
        Console.WriteLine("=================");
        Console.Write("Enter choice: ");
    }

    public string GetMenuChoice()
        => Console.ReadLine()?.ToUpper() ?? "";


    public void DisplayGameStart()
    {
        Console.Clear();
        Console.WriteLine("=== MATH GAME START ===\n");
    }

    public string GetUserName()
    {
        Console.Write("Enter your username: ");
        return Console.ReadLine()?.Trim() ?? "Unknown";
    }

    public int GetUserAnswer(string question)
    {
        Console.WriteLine(question);
        Console.Write("Your answer: ");

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int answer))
            {
                return answer;
            }
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Your answer: ");
        }
    }

    public void DisplayResult(bool isCorrect, int correctAnswer, int points)
    {
        if (isCorrect)
        {
            Console.WriteLine("✅ Correct!");
        }
        else
        {
            Console.WriteLine($"❌ Incorrect! The correct answer is {correctAnswer}");
        }
        Console.WriteLine($"Points: {points}\n");
    }

    public void DisplayGameOver(int totalPoints)
    {
        Console.WriteLine("\n=== GAME OVER ===");
        Console.WriteLine($"Total points: {totalPoints}/5");
        Console.WriteLine("================\n");
    }
}