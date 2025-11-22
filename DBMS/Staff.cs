namespace DBMS;

public class Staff
{
    int Id { get; }
    string Name { get; }
    string Position { get; }
    int Salary { get; }

    public Staff(int id, string name, string position, int salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }
}

public class StaffFactory
{
    public Staff CreateStaff(int id, string name, string position, int salary)
    {
        return new Staff(id, name, position, salary);
    }

    // public List<Staff> CreateStaffList(int id, string name, string position, int salary)
    // {
    //     List<Staff> staffs = new List<Staff>();
    // }
}


