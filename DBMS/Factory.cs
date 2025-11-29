namespace DBMS;

public class Factory
{
    public UniversalEntity CreateEntity(string[] headersFromUser,string[] headersFromFile, string[] values)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        for (int i = 0; i < headersFromUser.Length; i++)
        {
            int index = Array.IndexOf(headersFromFile, headersFromUser[i]);
            parameters[headersFromUser[i]] = values[index];
        }
        return new UniversalEntity(parameters);
    }
    public TablePath CreateTablePath()
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

    public Separators CreateSeparators(TablePath tablePath)
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
    public TableHeaders CreateTableHeaders(TablePath tablePath, Separators separators)
    {
        string headersFromFile = File.ReadLines(tablePath.PathToTable).First();
        string[] headersFromFileSplit = headersFromFile.Split(separators.Separator);
        
        try
        {
            Console.WriteLine("\nВведите названия стобцов, которые хотите увидеть, если хотите увидеть всё, введите '*'");
            string[] headersFromUser = Console.ReadLine().Split(',');
            if (headersFromUser[0] == "*") headersFromUser = headersFromFileSplit;
            bool flag = true;
            for (int i = 0; i < headersFromUser.Length; i++)
            {
                if (!(headersFromFile.Contains(headersFromUser[i]))) flag = false;
            }
            if (flag) return new TableHeaders(headersFromFileSplit, headersFromUser);
            throw new ArgumentException("Введите корректные названия стобиков через запятую");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return  CreateTableHeaders(tablePath,separators);
        }
    }

    public Pagination CreatePagination(TablePath tablePath)
    {
        try
        {
            Console.WriteLine("Введите сколько строк вы хотите пропустить,а сколько загрузить, через запятую");
            int[] pagination = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
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