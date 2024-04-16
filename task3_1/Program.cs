using System.Text;
using task3_1.ConsoleOutputs;
using task3_1.GameLogic;
using task3_1.SecretKey;
using task3_1.Shared;

string[] moves;
moves = args;
Shared.moves = moves;

if (moves.Length == 0)
{
    Console.WriteLine("You need to give moves.\nCount of moves must be even and > 1");
    return 0;
}
if (moves.Length <= 1 || moves.Length % 2 == 0)
{
    Console.WriteLine("Wrong count of moves.\nCount of moves must be even and >1");
    return 0;
}

HashSet<string> set = new HashSet<string>();
foreach (string item in moves)
{
    if (!set.Add(item))
    {
        Console.WriteLine("You need to write unique names for moves");
        return 0;
    }
}
var key = SecretKey.GenerateKey();
int moveComp = new Random().Next(1,moves.Length);
var sha3 = HMACSHA3.CalculateHMACSHA3(moveComp.ToString(),key);
moveComp--;
int moveUser;
Console.WriteLine("HMAC: {0}",ByteArrayToHexString(sha3));
do
{
    Menu.WriteMenu();
    moveUser = Menu.PlayerMove();
    if (moveUser == Convert.ToInt32('?'))
    {
        HelpTable.WriteHelpTable();
    }
} while (!Menu.IsCorrectGameMove(moveUser));

if (moveUser != 0)
{
    moveUser--;
    Menu.WriteMove(moveUser,Shared.Player.User);
    Menu.WriteMove(moveComp,Shared.Player.Computer);
    var compGameRes = GameLogic.CheckWinner(moveUser,moveComp);
    switch (compGameRes)
    {
        case Shared.GameResult.Draw : Console.WriteLine("Draw");
            break;
        case Shared.GameResult.Lose : Console.WriteLine("You win");
            break;
        case Shared.GameResult.Win : Console.WriteLine("You lose");
            break;
    }
    Console.WriteLine("HMAC key: {0}",ByteArrayToHexString(key));
}
return 0;


static string ByteArrayToHexString(byte[] bytes)
{
    StringBuilder hex = new StringBuilder(bytes.Length * 2);
    foreach (byte b in bytes)
    {
        hex.AppendFormat("{0:x2}", b);
    }
    return hex.ToString();
}