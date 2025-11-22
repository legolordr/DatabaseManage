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
    
    public static void GetLinesTable(string pathToTable)
    {
        
    }
}