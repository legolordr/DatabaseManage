namespace DBMS;

public static class ReadUserInfo
{
    public static string GetNameTable()
    {
        Console.WriteLine("Выберите с какой базой данных хотите работать, введите её название:");
        return Console.ReadLine().ToLower();
    }
    public static string GetPathToFolder()
    {
        Console.WriteLine("Введите путь до папки");
        return Console.ReadLine();
    }

    private static string[] GetHeadersFromUser()
    {
        Console.WriteLine("\nВведите названия стобцов, которые хотите увидеть, если хотите увидеть всё, введите '*'");
        return Console.ReadLine().Split(',');
    }
    public static string[] GetHeadersFromUser(string[] headersFromFile)
    {
        try
        {
            string[] headersFromUser = GetHeadersFromUser();
        
            if (headersFromUser[0] == "*") 
                return headersFromFile;
            
            string headersFile = string.Join(" ", headersFromFile);
            foreach (string header in headersFromUser)
            {
                if (!headersFile.Contains(header.Trim()))
                    throw new ArgumentException("Ошибка ввода значений");
            }
        
            return headersFromUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return GetHeadersFromUser(headersFromFile);
        }
    }

    public static int[] GetPagination()
    {
        Console.WriteLine("Введите сколько строк вы хотите пропустить,а сколько загрузить, через запятую");
        return Console.ReadLine().Split(',').Select(int.Parse).ToArray();
    }
}