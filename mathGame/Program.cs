Random rnd = new Random();

int questions = 5;
string question = "null";


for (int i = 0; i < questions; i++) {
    int num1 = rnd.Next(1, 100);
    int num2 = rnd.Next(1, 100);
    int signal = rnd.Next(3);
    

    if (signal == 0) {
        question = $"How much is {num1} + {num2}"; 
    }
    
    else if (signal == 1) {
       question = $"How much is {num1} - {num2}";
    }
    
    else if (signal == 2) {
        question = $"How much is {num1} * {num2}";
    }
    else {
        question = $"How much is {num1} / {num2}";
    }
    Console.WriteLine(question);
    string answer = Console.ReadLine();
    
    /*
    if (dividend1 % dividend2 == 0)
    {
        string question = $"How much is {dividend1} x {dividend2}";
        Console.WriteLine(question);
        string answer = Console.ReadLine();
    }
*/
}