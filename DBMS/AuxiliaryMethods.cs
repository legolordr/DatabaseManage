namespace DBMS;

class AuxiliaryMethods
{
    public static string GetPathToFolder()
    {
        try
        {
            Console.WriteLine("Введите путь до папки");
            string pathToFolder = Console.ReadLine();
            if (Directory.Exists(pathToFolder)) return pathToFolder;
            throw new DirectoryNotFoundException("Папка не найдена");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetPathToFolder();
        }
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

        try
        {
            Console.WriteLine("Выберите с какой базой данных хотите работать, введите её название:");
            string nameTable =  Console.ReadLine().ToLower();

            for (int i = 0; i < arrayNameTableWithExt.Length; i++)
            {
                if  (arrayNameTableWithOutExt[i] == nameTable) nameTable = arrayNameTableWithExt[i];
            }
            if (arrayNameTableWithExt.Contains(nameTable))
            {
                return nameTable;
            }
            throw new ArgumentException("Таблица не найдена");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetNameTable(values);
        }
    }
    
    public static char DetectedSeparator(string pathToTable)
    {
        char separator = new char();
        if (pathToTable.Contains(".csv")) separator = ';';
        else if (pathToTable.Contains(".tsv")) separator = '\t';
        return separator;
    }

    public static Pagination GetPagination(string pathToTable)
    {
        try
        {
            Console.WriteLine("Введите сколько строк вы хотите пропустить,а сколько загрузить, через запятую");
            int[] pagination = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            bool flag = true;
            int sum = 0;
            int count = File.ReadLines(pathToTable).Skip(1).ToArray().Length;
            for (int i = 0; i < pagination.Length; i++)
            {
                sum += pagination[i];
                if (!(pagination[i] > 0 && pagination[i] < count && sum < count )) flag = false;
            }
            if (flag) return new Pagination(pagination[0], pagination[1]);
            throw new ArgumentException("Введено неверное число строк");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetPagination(pathToTable);
        }
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
        try
        {
            Console.WriteLine("Введите названия стобцов, которые хотите увидеть, если хотите увидеть всё, введите '*'");
            string[] headersFromUser = Console.ReadLine().Split(',');
            if (headersFromUser[0] == "*") return headersFromFile;
            bool flag = true;
            for (int i = 0; i < headersFromUser.Length; i++)
            {
                if (!(headersFromFile.Contains(headersFromUser[i]))) flag = false;
            }
            if (flag) return headersFromUser;
            throw new ArgumentException("Введите корректные названия стобиков через запятую");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return  GetHeadersFromUser(headersFromFile);
        }
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