namespace DBMS;

public class Factory
{
    public UniversalEntity CreateEntity(string[] headers, string[] values)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        for (int i = 0; i < headers.Length; i++)
        {
            parameters[headers[i]] = values[i];
        }
        return new UniversalEntity(parameters);
    }
}