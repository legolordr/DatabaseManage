using DBMS;

class Program
{
    static void Main()
    {
        Factory factory = new Factory();
        TablePath tablePath = factory.CreateTablePath();
        Separators separator = factory.CreateSeparators(tablePath);
        
        //получение заголовков столбцов
        AuxiliaryMethods.WriteHeaders(tablePath, separator);
        
        TableHeaders tableHeaders = factory.CreateTableHeaders(tablePath, separator);
        
        Pagination pagination = factory.CreatePagination(tablePath) ; // получение кол-во строк пропуска/загрузки
        
        //получение строк таблицы с учетом пагинации в виде листа с массивами строк
        LinesFromTable linesTable = factory.CreateTable(tablePath, pagination, separator);
        
        //вывод с учетом нужных столбцов
        AuxiliaryMethods.WriteLinesFromTable(linesTable,tableHeaders.HeadersFromFile,tableHeaders.HeadersFromUser);
    }
}