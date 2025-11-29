using DBMS;

class Program
{
    static void Main()
    {
        Factory factory = new Factory();
        TablePath tablePath = factory.CreateTablePath();
        Separators separator = factory.CreateSeparators(tablePath);
        
        AuxiliaryMethods.WriteHeaders(tablePath, separator);
        
        TableHeaders tableHeaders = factory.CreateTableHeaders(tablePath, separator);
        
        Pagination pagination = factory.CreatePagination(tablePath); 
        
        LinesFromTable linesTable = factory.CreateTable(tablePath, pagination, separator);
        
        AuxiliaryMethods.WriteLinesFromTable(linesTable,tableHeaders.HeadersFromFile,tableHeaders.HeadersFromUser);
    }
}