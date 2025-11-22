namespace DBMS;

public class Contractors
{
    int Id { get; }
    string Name { get; }
    int Account{ get; }
    string Bic { get; }
    
    public Contractors(int id, string name, int account, string bic)
    {
        Id = id;
        Name = name;
        Account = account;
        Bic = bic;
    }
}