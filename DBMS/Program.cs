using DBMS;

class Program
{
    static void Main()
    {
        TablePath tablePath = Factory.CreateTablePath();
        Separators separator = ReadFile.CreateSeparators(tablePath);
        
        string[] headersFromFile = ReadFile.GetHeadersFromFile(tablePath,separator);
        
        DrawTable.WriteHeaders(headersFromFile);
        
        TableHeaders tableHeaders = Factory.CreateTableHeaders(headersFromFile);
        
        Pagination pagination = ReadUserInfo.CreatePagination(tablePath); 
        
        LinesFromTable linesTable = ReadFile.CreateTable(tablePath, pagination, separator);
        
        DrawTable.WriteLinesFromTable(linesTable,tableHeaders);
    }
}