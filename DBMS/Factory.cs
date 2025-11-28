namespace DBMS;

public class Factory
{
    public UniversalEntity CreateEntity(string[] headersFromUser,string[] headersFromFile, string[] values)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        for (int i = 0; i < headersFromUser.Length; i++)
        {
            int index = Array.IndexOf(headersFromFile, headersFromUser[i]);
            parameters[headersFromUser[i]] = values[index];
        }
        return new UniversalEntity(parameters);
    }
}