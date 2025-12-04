namespace DBMS;

class DrawTable
{
    public static void WriteHeaders(string[] headersFromFile)
    {
        foreach (string header in headersFromFile)
        {
            Console.Write(header + " ");
        }
    }
    public static void WriteLinesFromTable(LinesFromTable linesInfoTable,TableHeaders tableHeaders)
    {
        List<UniversalEntity> rowsFromTable = new List<UniversalEntity>();
        foreach (string[] values in linesInfoTable.LinesTable)
        {
            UniversalEntity rowFromTable = Factory.CreateEntity(tableHeaders, values);
            rowsFromTable.Add(rowFromTable);
        }
        Console.WriteLine(string.Join(" ", tableHeaders.HeadersFromUser));
        foreach (UniversalEntity row in rowsFromTable)
        {
            Console.WriteLine(row);
        }
    }
}