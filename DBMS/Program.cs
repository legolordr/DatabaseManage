using DBMS;

class Program
{

    static void Main()
    {
        string pathToFolder = AuxiliaryMethods.GetPathToFolder(); // путь до папки
        string[] tables = AuxiliaryMethods.GetArrayTables(pathToFolder); // тут лежит массив путей до каждой таблицы
        string nameTable = AuxiliaryMethods.GetNameTable(tables); //возваращется значение с расширением для построения пути до файла
        string pathToTable = Path.Combine(pathToFolder, nameTable); // путь до выбранной юзерой таблицы
        
        char separator = AuxiliaryMethods.DetectedSeparator(pathToTable); // определение разделителя
        
        //получение заголовков столбцов
        string[] headersFromFile = AuxiliaryMethods.GetHeadersFromFiles(pathToTable,separator);
        
        Console.WriteLine(string.Join(" ",headersFromFile)); // предоставление юзеру названий столбцов
        
        string[] headersFromUser = AuxiliaryMethods.GetHeadersFromUser(headersFromFile);// столбики от юзера
        
        int[] pagination = AuxiliaryMethods.GetPagination(); // получение кол-во строк пропуска/загрузки
        int paginationSkip =  pagination[0];
        int paginationRead =  pagination[1];
        //получение строк таблицы с учетом пагинации в виде листа с массивами строк
        List<string[]> linesTable = AuxiliaryMethods.GetLinesFromTable(pathToTable, separator, paginationSkip, paginationRead);
        
        //вывод с учетом нужных столбцов
        AuxiliaryMethods.WriteLinesFromTable(linesTable,headersFromFile,headersFromUser);
    }
}