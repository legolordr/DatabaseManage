namespace DBMS;

public class UniversalEntity
{
    public Dictionary<string,string>  Parameters { get; }
    public UniversalEntity(Dictionary<string,string> parameters)
    {
        Parameters = parameters;
    }
    // переопределим Tostring, чтобы WriteLine выводил конкретные значения
    public override string ToString()
    {
        var parameters = string.Join(" ", Parameters.Select(p => $"{p.Value}"));
        return parameters;
    }
}