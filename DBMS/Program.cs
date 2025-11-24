using DBMS;

class Program
{

    static void Main()
    {
        string pathToFolder = AuxiliaryMethods.GetPathToFolder(); // путь до папки
        string[] tables = AuxiliaryMethods.GetArrayTables(pathToFolder); // тут лежит массив путей до каждой таблицы
        string nameTable = AuxiliaryMethods.GetNameTable(tables); //возваращется значение с расширением для построения пути до файла
        string entityType = Path.GetFileNameWithoutExtension(nameTable).ToLower();
        string pathToTable = Path.Combine(pathToFolder, nameTable); // путь до выбранной юзерой таблицы
        char separator = AuxiliaryMethods.DetectedSeparator(pathToTable);
        List<string[]> linesInfoTable = AuxiliaryMethods.ReadAllLinesFromTable(pathToTable, separator);
        List<IEntity> rowsFromTable = new List<IEntity>();// лист со всеми объектами из выбранной таблицы
        var factory = new Factory();
        foreach (string[] line in linesInfoTable.Skip(1))
        {
            IEntity rowFromTable = factory.CreateEntity(entityType,line);
            rowsFromTable.Add(rowFromTable);
        }
        foreach (IEntity row in rowsFromTable)
        {
            Console.WriteLine(row);
        }
    }
}