namespace DBMS;

public static class ReadFile
{
    public static LinesFromTable CreateTable(TablePath tablePath, Pagination pagination,Separators separator)
    {
        List<string[]> listLineSplit = new List<string[]>();
        foreach (string line in File.ReadLines(tablePath.PathToTable).Skip(1).Skip(pagination.PaginationSkip).Take(pagination.PaginationRead))
        {
            string[] lineSplit = line.Split(separator.Separator);
            listLineSplit.Add(lineSplit);
        }
        return  new LinesFromTable(listLineSplit);
    }
   
    public static Separators CreateSeparators(TablePath tablePath)
    {
        try
        {
            char separator = new char();
            if (tablePath.PathToTable.Contains(".csv")) separator = ';';
            else if (tablePath.PathToTable.Contains(".tsv")) separator = '\t';
            return new Separators(separator);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception();
        }
    }
    public static string[] GetHeadersFromFile(TablePath tablePath, Separators separators)
    {
        string headersFromFile = File.ReadLines(tablePath.PathToTable).First();
        return headersFromFile.Split(separators.Separator);
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
            string pathToFolder = ReadUserInfo.GetPathToFolder();
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

                string tableName = ReadUserInfo.GetNameTable();
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
    public static Pagination CreatePagination(TablePath tablePath)
    {
        try
        {   
            int[] pagination = ReadUserInfo.GetPagination();
            bool flag = true;
            int sum = 0;
            int count = File.ReadLines(tablePath.PathToTable).Skip(1).ToArray().Length;
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
            return CreatePagination(tablePath);
        }
    }

}
