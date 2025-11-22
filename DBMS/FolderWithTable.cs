namespace DBMS;

public class FolderWithTable
{
    string TableName { get; }
    
    public FolderWithTable(string tableName)
    {
        TableName = tableName;
    }
}