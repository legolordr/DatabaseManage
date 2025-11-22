using DBMS;

class Program
{

    static void Main()
    {
        string pathToFolder = AuxiliaryMethods.GetPathToFolder();
        string[] tables = AuxiliaryMethods.GetArrayTables(pathToFolder); 
        string nameTable = AuxiliaryMethods.GetNameTable(tables); //возваращется значение с расширением для построения пути до файла
        
    }
}