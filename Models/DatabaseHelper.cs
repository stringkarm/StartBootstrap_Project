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

        //WALA RANI DIRI SIRRR, EME RANI POOO//
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC INSERT QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(insertQuery);
        Console.WriteLine("------------------------------------------");

        return insertQuery;
    }

    public static string UpdateAndGetQuery(string tableName, string[] columns, string[] values, string idValue)
    {
        string setClause = "";

        for (int i = 0; i < columns.Length; i++)
        {
            string col = columns[i].Trim();
            string val = values[i].Trim();

            if (i == columns.Length - 1)
            {
                setClause += $"{col} = {val}";
            }
            else
            {
                setClause += $"{col} = {val}, ";
            }
        }

        string updateQuery = $"UPDATE {tableName} SET {setClause} WHERE Id = {idValue}";

        //WALA RANI DIRI SIRRR//
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC UPDATE QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(updateQuery);
        Console.WriteLine("------------------------------------------");

        return updateQuery;
    }

    public static string DeleteAndGetQuery(string tableName, string idValue)
    {
        string deleteQuery = $"DELETE FROM {tableName} WHERE Id = {idValue}";

        //WALA RANI DIRI SIRRR//
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC DELETE QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(deleteQuery);
        Console.WriteLine("------------------------------------------");

        return deleteQuery;
    }
}