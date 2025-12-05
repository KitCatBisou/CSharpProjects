Random rnd = new Random();

int questions = 5;
string question = "null";


for (int i = 0; i < questions; i++) {
    int num1 = rnd.Next(1, 100);
    int num2 = rnd.Next(1, 100);
    int signal = rnd.Next(4);
    

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
        while (num1 % num2 != 0)
        {
            num1 = rnd.Next(1, 100);
            num2 = rnd.Next(1, 100);
        }

        question = $"How much is {num1} / {num2}"; 
        
    }
    Console.WriteLine(question);
    string answer = Console.ReadLine();
}