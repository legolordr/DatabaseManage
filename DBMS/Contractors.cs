namespace DBMS;

public class Contractors : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public int Account{ get; }
    public string Bic { get; }
    
    public Contractors(int id, string name, int account, string bic)
    {
        Id = id;
        Name = name;
        Account = account;
        Bic = bic;
    }
    public override string ToString()
    {
        return $"{Id} {Name} {Account} {Bic}";
    }
}