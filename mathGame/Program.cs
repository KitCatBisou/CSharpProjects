Random rnd = new Random();

int questions = 5;
string question = "null";
int answer = 0;
int points = 0;

Console.WriteLine("--- MATH GAME START ---");

for (int i = 0; i < questions; i++) {
    int num1 = rnd.Next(1, 100);
    int num2 = rnd.Next(1, 100);
    int signal = rnd.Next(4);

    switch (signal) {
        case 0:
            question = $"Question {i + 1}: How much is {num1} + {num2}?";
            answer = num1 + num2;
            break;
        case 1:
            question = $"Question {i + 1}: How much is {num1} - {num2}?";
            answer = num1 - num2;
            break;
        case 2:
            question = $"Question {i + 1}: How much is {num1} * {num2}?";
            answer = num1 * num2;
            break;
        case 3:
            while (num1 % num2 != 0)
            {
                num1 = rnd.Next(1, 100);
                num2 = rnd.Next(1, 100);
            }

            question = $"Question {i + 1}: How much is {num1} / {num2}?"; 
            answer = num1 / num2;
            break;
    }
    
    Console.WriteLine(question);
    string userAnswer = Console.ReadLine();
    
    if (int.TryParse(userAnswer, out int userAnswerInt))
    {
        if (userAnswerInt == answer)
        {
            Console.WriteLine("Correct!");
            points++;
            Console.WriteLine($"Points: {points}");
        }
        else
        {
            Console.WriteLine($"Incorrect!\nThe answer is {answer}");
            Console.WriteLine($"Points: {points}");
        }
    }
    else
    {
        Console.WriteLine("That is not a valid number!");
    }
   
    Console.WriteLine($"--------------------------");
}

Console.WriteLine($"Game over\nYou finished with {points} points!");