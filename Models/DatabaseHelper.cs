using System;

public static class DatabaseHelper
{

    public static string InsertAndGetQuery(string tableName, string columnsInput, string valuesInput)
    {

        string[] columnsArray = columnsInput.Split(',');
        string[] valuesArray = valuesInput.Split(',');

        string formattedColumns = "";
        string formattedValues = "";

        for (int i = 0; i < columnsArray.Length; i++)
        {
            string col = columnsArray[i].Trim();
            string val = valuesArray[i].Trim();

            if (i == columnsArray.Length - 1)
            {
                formattedColumns += col;
                formattedValues += val;
            }
            else
            {
                formattedColumns += col + ", ";
                formattedValues += val + ", ";
            }
        }

        string insertQuery = $"INSERT INTO {tableName} ({formattedColumns}) VALUES ({formattedValues})";

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(insertQuery);
        Console.WriteLine("------------------------------------------");

        return insertQuery;
    }
}