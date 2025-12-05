Random rnd = new Random();

int questions = 5;
string question = "null";
int answer = 0;
int points = 0;


for (int i = 0; i < questions; i++) {
    int num1 = rnd.Next(1, 100);
    int num2 = rnd.Next(1, 100);
    int signal = rnd.Next(4);
    

    if (signal == 0) {
        question = $"How much is {num1} + {num2}";
        answer = num1 + num2;
    }
    
    else if (signal == 1) {
       question = $"How much is {num1} - {num2}";
       answer = num1 - num2;
    }
    
    else if (signal == 2) {
        question = $"How much is {num1} * {num2}";
        answer = num1 * num2;
    }
    else {
        while (num1 % num2 != 0)
        {
            num1 = rnd.Next(1, 100);
            num2 = rnd.Next(1, 100);
        }

        question = $"How much is {num1} / {num2}"; 
        answer = num1 / num2;
        
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
}

Console.WriteLine($"Game over\nYou finished with {points} points!");