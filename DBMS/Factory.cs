namespace DBMS;

public static class Factory
{
    public static UniversalEntity CreateEntity(TableHeaders tableHeaders, string[] values)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        for (int i = 0; i < tableHeaders.HeadersFromUser.Length; i++)
        {
            int index = Array.IndexOf(tableHeaders.HeadersFromFile, tableHeaders.HeadersFromUser[i]);
            parameters[tableHeaders.HeadersFromUser[i]] = values[index];
        }
        return new UniversalEntity(parameters);
    }
    public static TableHeaders CreateTableHeaders(string[] headersFromFile)
    {
        string[] userHeaders = ReadUserInfo.GetHeadersFromUser(headersFromFile);
        return new TableHeaders(headersFromFile, userHeaders);
    }
    public static TablePath CreateTablePath()
    {
        try
        {
            Console.WriteLine("Введите путь до папки");
            string pathToFolder = Console.ReadLine();
            if (Directory.Exists(pathToFolder))
            {
                string[] tables = Directory.GetFiles(pathToFolder);
                List<string> tableNames = new List<string>();
                List<string> tableNamesExts = new List<string>();
                foreach (string table in tables)
                {
                    string nameTable = Path.GetFileNameWithoutExtension(table);
                    string nameTableExt = Path.GetFileName(table);
                    tableNames.Add(nameTable);
                    tableNamesExts.Add(nameTableExt);
                    Console.WriteLine(nameTable);
                }
                Console.WriteLine("Выберите с какой базой данных хотите работать, введите её название:");
                string tableName = Console.ReadLine().ToLower();
                bool flag = false;
                foreach (string nameExt in tableNamesExts)
                {
                    if (nameExt.Contains(tableName))
                    {
                        tableName = nameExt;
                        flag = true;
                    }
                }
                if (flag) return new TablePath(pathToFolder,tableName);
                throw new DirectoryNotFoundException("Таблица не найдена");
            } 
            throw new DirectoryNotFoundException("Папка не найдена");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return CreateTablePath();
        }
    }
}