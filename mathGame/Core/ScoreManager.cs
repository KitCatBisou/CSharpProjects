using mathGame.Models;

namespace mathGame.Core;

public class ScoreManager(List<GameScore> scores)
{
    private readonly List<GameScore> _scores = scores;

    public void AddScore(string name, int points)
    {
        var score = new GameScore
        {
            Name = name,
            Points = points,
            Date = DateTime.Now
        };

        _scores.Add(score);
    }

    public void DisplayHistory()
    {
        if (_scores.Count == 0)
        {
            Console.WriteLine("No scores recorded yet.");
            return;
        }

        Console.WriteLine("\n=== SCORE HISTORY ===");
        for (int i = 0; i < _scores.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scores[i]}");
        }
        Console.WriteLine("=====================\n");
    }

}