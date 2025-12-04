namespace DBMS;

public static class Factory
{
    public static UniversalEntity CreateEntity(TableHeaders tableHeaders, string[] values)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        for (int i = 0; i < tableHeaders.HeadersFromUser.Length; i++)
        {
            int index = Array.IndexOf(tableHeaders.HeadersFromFile, tableHeaders.HeadersFromUser[i]);
            parameters[tableHeaders.HeadersFromUser[i]] = values[index];
        }
        return new UniversalEntity(parameters);
    }
}