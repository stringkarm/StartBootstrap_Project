using System;

public static class DatabaseHelper
{

    public static string InsertAndGetQuery(string tableName, string[] columns, string[] values)
    {
        string formattedColumns = "";
        string formattedValues = "";

 
        for (int i = 0; i < columns.Length; i++)
        {
            string col = columns[i].Trim();
            string val = values[i].Trim();


            if (i == columns.Length - 1)
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

        // Store and log the data in the console window
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(insertQuery);
        Console.WriteLine("------------------------------------------");

        return insertQuery;
    }
}