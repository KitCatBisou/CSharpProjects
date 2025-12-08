namespace mathGame.Models;

public class GameScore
{
    public string Name { get; set; } = "Unknown";
    public int Points { get; set; }
    public DateTime Date { get; set; }
    public override string ToString()
    {
        return $"{Date:yyyy-MM-dd HH:mm} | {Name}: {Points} points";
    }
}