using DBMS;

class Program
{

    static void Main()
    {
        string pathToFolder = AuxiliaryMethods.GetPathToFolder(); // путь до папки
        string[] tables = AuxiliaryMethods.GetArrayTables(pathToFolder); // тут лежит массив путей до каждой таблицы
        string nameTable = AuxiliaryMethods.GetNameTable(tables); //возваращется значение с расширением для построения пути до файла
        string pathToTable = Path.Combine(pathToFolder, nameTable); // путь до выбранной юзерой таблицы
        
        char separator = AuxiliaryMethods.DetectedSeparator(pathToTable);
        
        List<string[]> linesInfoTable = AuxiliaryMethods.ReadAllLinesFromTable(pathToTable, separator);
        
        List<UniversalEntity> rowsFromTable = new List<UniversalEntity>();// лист со всеми объектами из выбранной таблицы
        
        AuxiliaryMethods.WriteAllLinesFromTable(linesInfoTable,rowsFromTable);
    }
}