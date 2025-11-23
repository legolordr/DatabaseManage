using System.Net.ServerSentEvents;
using System.Xml;

namespace DBMS;

class AuxiliaryMethods
{
    public static string GetPathToFolder()
    {
        Console.WriteLine("Введите путь до папки");
        return Console.ReadLine();
    }
    public static string[] GetArrayTables(string pathToFolder)
    {
        string[] tables = Directory.GetFiles(pathToFolder);
        return tables;
    }

    public static string GetNameTable(string[] values) // выводим юзеру список доступных таблиц и возвращаем выбранную им таблицу, указывая расширение
    {
        string[] arrayNameTableWithOutExt = new string[values.Length];
        string[] arrayNameTableWithExt = new string[values.Length];
        foreach (string value in values)
        {
            string name = Path.GetFileNameWithoutExtension(value);
            for (int i = 0; i < values.Length; i++)
            {
                arrayNameTableWithOutExt[i] = Path.GetFileNameWithoutExtension(values[i]);
                arrayNameTableWithExt[i] = Path.GetFileName(values[i]);
            }
            Console.WriteLine(name);
        }
        Console.WriteLine("Выберите с какой базой данных хотите работать, введите её название:");
        string nameTable =  Console.ReadLine().ToLower();

        for (int i = 0; i < arrayNameTableWithExt.Length; i++)
        {
           if  (arrayNameTableWithOutExt[i] == nameTable) nameTable = arrayNameTableWithExt[i];
        }
        // проверка на существование таблицы
        if (arrayNameTableWithExt.Contains(nameTable))
        {
            return nameTable;
        }
        throw new ArgumentException();
    }
    
    public static void WriteAllLinesFromTable(string pathToTable,char separator)
    {
        foreach (string line in File.ReadAllLines(pathToTable))
        {
            foreach (string lineSplit in line.Split(separator))
            {
                Console.Write(lineSplit + ' ');
            }
            Console.WriteLine();
        }
    }

    public static char DetectedSeparator(string pathToTable)
    {
        char separator = new char();
        if (pathToTable.Contains("csv")) separator = ';';
        else if (pathToTable.Contains("tsv")) separator = '\t';
        return separator;
    }
    public static List<object[]> ReadAllLinesFromTable(string pathToTable, char separator)
    {
        List<object[]> listLineSplit = new List<object[]>();
        
        foreach (string line in File.ReadAllLines(pathToTable))
        {
            string[] lineSplit = line.Split(separator);
            listLineSplit.Add(lineSplit);
        }
        return  listLineSplit;
    }
}