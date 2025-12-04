namespace DBMS;

public class TablePath
{
    public string PathToFolder { get; }
    public string TableName  { get; }
    public string PathToTable { get; }

    public TablePath(string pathToFolder, string tableName)
    {
        PathToFolder = pathToFolder;
        TableName = tableName;
        PathToTable = Path.Combine(pathToFolder, tableName);
    }
}