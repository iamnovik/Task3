namespace task3_1.Shared;

public static class Shared
{
    public static string[] moves { get; set; }
    public enum GameResult
    {
        Win,
        Lose,
        Draw
    }
    
    public enum Player
    {
        User,
        Computer
    }
    
    public enum MenuOptions
    {
        PlayerMove,
        Exit,
        HelpTable
    }
}