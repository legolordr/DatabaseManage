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