namespace DBMS;

public class TableHeaders
{
    public string[] HeadersFromFile { get; }
    public string[] HeadersFromUser { get; }

    public TableHeaders(string[] headersFromFile, string[] headersFromUser)
    {
        HeadersFromFile = headersFromFile;
        HeadersFromUser = headersFromUser;
    }
}