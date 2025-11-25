namespace DBMS;

public class UniversalEntity
{
    public Dictionary<string,object>  Parameters { get; }
    public UniversalEntity(Dictionary<string,object> parameters)
    {
        Parameters = parameters;
    }
    // переопределим Tostring, чтобы WriteLine работал корректно
    public override string ToString()
    {
        var parameters = string.Join(" ", Parameters.Select(p => $"{p.Key}:{p.Value}"));
        return $"{parameters}";
    }
}