namespace DBMS;

class AuxiliaryMethods
{
    public static void WriteHeaders(TablePath tablePath, Separators separator)
    {
        string[] headersFromFile = File.ReadLines(tablePath.PathToTable).First().Split(separator.Separator);
        foreach (string header in headersFromFile)
        {
            Console.Write(header + " ");
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
    public static void WriteLinesFromTable(LinesFromTable linesInfoTable,string[] headersFromFile,string[] headersFromUser)
    {
        List<UniversalEntity> rowsFromTable = new List<UniversalEntity>();
        var factory = new Factory();
        foreach (string[] values in linesInfoTable.LinesTable)
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