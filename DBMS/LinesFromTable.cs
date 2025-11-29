namespace DBMS;

public class LinesFromTable
{
    public List<string[]> LinesTable { get; }

    public LinesFromTable(List<string[]> linesTable)
    {
        LinesTable = linesTable;
    }
}