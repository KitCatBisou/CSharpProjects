namespace mathGame.Models;

public class GameState
{
    public bool IsRunning { get; set; } = true;
    public List<GameScore> ScoreHistory { get; } = [];
    public int CurrentPoints { get; set; }
    public string CurrentUserName { get; set; } = "Unknown";
}