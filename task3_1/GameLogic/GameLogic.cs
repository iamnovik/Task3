namespace task3_1.GameLogic;

using static Shared.Shared;

public static class GameLogic
{
    private static string[] _moves = moves;
    
    public static GameResult CheckWinner(int move1, int move2)
    {
        if (move1 == move2)
        {
            return GameResult.Draw;
        }
        int n = _moves.Length;
            
        int halfSize = n / 2;
        int[] nextHalfMoves = new int[halfSize];
        for (int i = 0; i < halfSize; i++)
        {
            nextHalfMoves[i] = (move1 + i + 1) % n;
        }

        if (Array.IndexOf(nextHalfMoves, move2) != -1)
        {
            return GameResult.Win;
        }
        return GameResult.Lose;
    }
    
}