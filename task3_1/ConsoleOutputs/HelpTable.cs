using System.Collections;
using ConsoleTables;

namespace task3_1.ConsoleOutputs;

public static class HelpTable
{
    
    public static void WriteHelpTable()
    {
        var moves = Shared.Shared.moves;
        int n = moves.Length;

        // Создание таблицы
        var table = new ConsoleTable();
        
        // Добавление заголовков столбцов
        table.AddColumn(new[] {"PC\\User"});
        
        foreach (var name in moves)
        {
            table.AddColumn(new[] { name });
        }
        
        // Добавление строк с именами
        for (int i = 0; i < n; i++)
        {
            var row = new string[n + 1];
            row[0] = moves[i];
            for (int j = 1; j <= n; j++)
            {
                row[j] = GameLogic.GameLogic.CheckWinner(i, j - 1).ToString();
            }
            table.AddRow(row);
        }

        // Вывод таблицы в консоль
        table.Write(Format.Minimal);
        
    }
}