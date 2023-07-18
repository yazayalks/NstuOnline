namespace Common.Models;

public class PagedList<T>
    where T: class
{
    public int TotalCount { get; set; }
    
    public List<T> Items { get; set; }
}