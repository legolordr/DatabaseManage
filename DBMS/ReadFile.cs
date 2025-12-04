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
}