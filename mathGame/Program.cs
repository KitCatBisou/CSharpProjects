using mathGame.Core;
using mathGame.Models;

    var gameState = new GameState();
    var gameEngine = new GameEngine();
    var ui = new UserInterface();
    var scoreManager = new ScoreManager(gameState.ScoreHistory);

    while (gameState.IsRunning)
    {
        ui.DisplayMenu();
        string choice = ui.GetMenuChoice();

        switch (choice)
        {
            case "Q":
                gameState.IsRunning = false;
                Console.WriteLine("Thanks for playing!");
                break;

            case "H":
                scoreManager.DisplayHistory();
                break;

            case "P":
                PlayGame(gameEngine, ui, scoreManager);
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    static void PlayGame(
        GameEngine engine, 
        UserInterface ui, 
        ScoreManager scoreManager)
    {
        ui.DisplayGameStart();
        
        int points = 0;
        const int totalQuestions = 5;
        
        for (int i = 0; i < totalQuestions; i++)
        {
        int correctAnswer = engine.GenerateQuestion(i + 1, out string question);

        int userAnswer = ui.GetUserAnswer(question);
            bool isCorrect = userAnswer == correctAnswer;
            
            if (isCorrect) points++;
            
            ui.DisplayResult(isCorrect, correctAnswer, points);
        }
        
        ui.DisplayGameOver(points);
        
        string userName = ui.GetUserName();
        scoreManager.AddScore(userName, points);
    }