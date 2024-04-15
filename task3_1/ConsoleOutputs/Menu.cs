namespace task3_1.ConsoleOutputs;
using static Shared.Shared;
public static class Menu
{
    private static string[] _moves = moves;
    public static void WriteMenu()
    {
        
        //Console.WriteLine("HMAC:{0}",hmac);
        Console.WriteLine("Available Moves:");
        
        int movesCount = moves.Length;
        for (int i = 0; i < movesCount; i++)
        {
            Console.WriteLine("{0} - {1}",i + 1,moves[i]);
        }
        
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    public static int PlayerMove()
    {
        Console.Write("Enter your move: ");
        int move;
        string playermove = Console.ReadLine()!;
        if (int.TryParse(playermove,out move))
        {
            return move;
        }
        if (playermove == "?")
        {
            return Convert.ToInt32('?');
        }
        return -1;
    }

    public static void WriteMove(int move, Player player)
    {
        if (player == Player.User)
        {
            Console.WriteLine("Your move: {0}",_moves[move]);
        }
        else
        {
            Console.WriteLine("Computer move: {0}",_moves[move]);
        }
    }
    public static bool IsCorrectGameMove(int  move)
    {
        return move >= 0 && move <= _moves.Length ;
    }

    
}