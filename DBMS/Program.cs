using DBMS;

class Program
{
    static void Main()
    {
        TablePath tablePath = ReadFile.CreateTablePath();
        Separators separator = ReadFile.CreateSeparators(tablePath);
        
        string[] headersFromFile = ReadFile.GetHeadersFromFile(tablePath,separator);
        
        DrawTable.WriteHeaders(headersFromFile);
        
        TableHeaders tableHeaders = ReadFile.CreateTableHeaders(headersFromFile);
        
        Pagination pagination = ReadFile.CreatePagination(tablePath); 
        
        LinesFromTable linesTable = ReadFile.CreateTable(tablePath, pagination, separator);
        
        DrawTable.WriteLinesFromTable(linesTable,tableHeaders);
    }
}