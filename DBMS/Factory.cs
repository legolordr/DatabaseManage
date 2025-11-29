namespace DBMS;

public class Factory
{
    public UniversalEntity CreateEntity(string[] headersFromUser,string[] headersFromFile, string[] values)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        for (int i = 0; i < headersFromUser.Length; i++)
        {
            int index = Array.IndexOf(headersFromFile, headersFromUser[i]);
            parameters[headersFromUser[i]] = values[index];
        }
        return new UniversalEntity(parameters);
    }
}