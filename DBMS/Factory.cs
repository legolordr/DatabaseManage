namespace DBMS;

public class Factory
{
    enum EntityType
    {
        contractors,
        employees
    }
    
    public IEntity CreateEntity(string entityType, params object[] parameters)
    {
        string[] stringParams = parameters.Select(p => p.ToString()).ToArray();
        
        return entityType switch
        {
            nameof(EntityType.contractors) => CreateContractor(stringParams),
            nameof(EntityType.employees) => CreateEmployee(stringParams),
            _ => throw new ArgumentException()
        };
    }
    
    Employees CreateEmployee(string[] parameters)
    {
        if (parameters.Length < 4)
            throw new ArgumentException();
        
        return new Employees(
            int.Parse(parameters[0]),
            parameters[1],
            parameters[2],
            int.Parse(parameters[3])  
        );
    }

    Contractors CreateContractor(string[] parameters)
    {
        if (parameters.Length < 4)
            throw new ArgumentException();

        return new Contractors(
            int.Parse(parameters[0]),
            parameters[1],
            int.Parse(parameters[2]),
            parameters[3]
        );
    }
}