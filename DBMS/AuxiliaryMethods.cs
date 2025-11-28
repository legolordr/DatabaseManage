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
    
    public static char DetectedSeparator(string pathToTable)
    {
        char separator = new char();
        if (pathToTable.Contains(".csv")) separator = ';';
        else if (pathToTable.Contains(".tsv")) separator = '\t';
        return separator;
    }

    public static int[] GetPagination()
    {
        Console.WriteLine("Сколько строк нужно пропустить?");
        int paginationSkip = int.Parse(Console.ReadLine());
        Console.WriteLine("Сколько строк нужно загрузить?");
        int paginationRead = int.Parse(Console.ReadLine());
        int[] pagination = new int[2];
        pagination[0] = paginationSkip;
        pagination[1] = paginationRead;
        return pagination;
    }
    public static List<string[]> GetLinesFromTable(string pathToTable, char separator, int paginationSkip,int paginationRead)
    {
        List<string[]> listLineSplit = new List<string[]>();
        foreach (string line in File.ReadLines(pathToTable).Skip(1).Skip(paginationSkip).Take(paginationRead))
        {
            string[] lineSplit = line.Split(separator);
            listLineSplit.Add(lineSplit);
        }
        return  listLineSplit;
    }

    public static string[] GetHeadersFromFiles(string pathToTable,char separator)
    {
        string headers = File.ReadLines(pathToTable).First();
        return headers.Split(separator);
    }

    public static string[] GetHeadersFromUser(string[] headersFromFile)
    {
        Console.WriteLine("Введите названия стобцов, которые хотите увидеть, если хотите увидеть всё, введите '*'");
        string[] headersFromUser = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
        if (headersFromUser[0] == "*") return headersFromFile;
        return headersFromUser;
    }
    
    public static void WriteLinesFromTable(List<string[]> linesInfoTable,string[] headersFromFile,string[] headersFromUser)
    {
        List<UniversalEntity> rowsFromTable = new List<UniversalEntity>();
        var factory = new Factory();
        foreach (string[] values in linesInfoTable)
        {
            UniversalEntity rowFromTable = factory.CreateEntity(headersFromUser,headersFromFile, values);
            rowsFromTable.Add(rowFromTable);
        }
        Console.WriteLine(string.Join(" ", headersFromUser));
        foreach (UniversalEntity row in rowsFromTable)
        {
            Console.WriteLine(row);
        }
    }
}