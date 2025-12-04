namespace DBMS;

public static class ReadUserInfo
{
    public static string[] GetHeadersFromUser(string[] headersFromFile)
    {
        try
        {
            Console.WriteLine("\nВведите названия стобцов, которые хотите увидеть, если хотите увидеть всё, введите '*'");
            string[] headersFromUser = Console.ReadLine().Split(',');
        
            if (headersFromUser[0] == "*") 
                return headersFromFile;
            
            string headers = string.Join(" ", headersFromUser);
            foreach (string header in headersFromUser)
            {
                if (!headers.Contains(header.Trim()))
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
    public static Pagination CreatePagination(TablePath tablePath)
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