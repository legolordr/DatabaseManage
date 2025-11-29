namespace DBMS;

public class Pagination
{
    public int PaginationSkip { get; }
    public int PaginationRead  { get; }

    public Pagination(int paginationSkip, int paginationRead)
    {
        PaginationSkip = paginationSkip;
        PaginationRead = paginationRead;
    }
}