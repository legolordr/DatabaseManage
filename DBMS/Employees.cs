namespace DBMS;

public class Employees : IEntity
{
    public int Id { get; }
    public string Name { get; }
    public string Position { get; }
    public int Salary { get; }

    public Employees(int id, string name, string position, int salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }
    public override string ToString()
    {
        return $"{Id} {Name} {Position} {Salary}";
    }
}


