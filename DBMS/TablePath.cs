namespace DBMS;

public class TablePath
{
    public string PathToFodler { get; }
    public string TableName { get; }
    public string PathToTable { get; }
    public TablePath(string pathToFodler, string tableName)
    {
        PathToFodler = pathToFodler;
        TableName = tableName;
        PathToTable = Path.Combine(pathToFodler, tableName);
    }
}