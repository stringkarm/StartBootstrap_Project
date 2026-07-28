using System;
using System.Globalization;

public static class DatabaseHelper
{
    public static string InsertAndGetQuery(string tableName, string[] columns, object[] values)
    {
        if (columns.Length != values.Length)
        {
            throw new ArgumentException("Columns and values count must match.");
        }

        string columnsPart = "";
        string valuesPart = "";

        for (int i = 0; i < columns.Length; i++)
        {
            columnsPart += columns[i].Trim();
            valuesPart += FormatValue(values[i]);

            if (i < columns.Length - 1)
            {
                columnsPart += ", ";
                valuesPart += ", ";
            }
        }

        string insertQuery = $"INSERT INTO {tableName} ({columnsPart}) VALUES ({valuesPart})";

        //WAY GAMIT
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC INSERT QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(insertQuery);
        Console.WriteLine("------------------------------------------");

        return insertQuery;
    }

    public static string UpdateAndGetQuery(string tableName, string[] columns, object[] values, string condition)
    {
        if (columns.Length != values.Length)
        {
            throw new ArgumentException("Columns and values count must match.");
        }

        string setPart = "";

        for (int i = 0; i < columns.Length; i++)
        {
            setPart += columns[i].Trim() + " = " + FormatValue(values[i]);

            if (i < columns.Length - 1)
            {
                setPart += ", ";
            }
        }

        string updateQuery = $"UPDATE {tableName} SET {setPart} WHERE {condition}";

        //WAY GAMIT
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC UPDATE QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(updateQuery);
        Console.WriteLine("------------------------------------------");

        return updateQuery;
    }

    public static string DeleteAndGetQuery(string tableName, string condition)
    {
        string deleteQuery = $"DELETE FROM {tableName} WHERE {condition}";

        //WAY GAMIT
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"DYNAMIC DELETE QUERY FOR [{tableName}] STORED IN CONSOLE:");
        Console.WriteLine(deleteQuery);
        Console.WriteLine("------------------------------------------");

        return deleteQuery;
    }

    private static string FormatValue(object value)
    {
        if (value == null)
        {
            return "NULL";
        }

        string strValue = value.ToString();

        if (int.TryParse(strValue, out int intResult))
        {
            return intResult.ToString();
        }

        if (decimal.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decResult))
        {
            return decResult.ToString(CultureInfo.InvariantCulture);
        }

        if (bool.TryParse(strValue, out bool boolResult))
        {
            return boolResult ? "1" : "0";
        }

        return "'" + strValue.Replace("'", "''") + "'";
    }
}