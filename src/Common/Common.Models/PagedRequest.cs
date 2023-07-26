namespace Common.Models;

public record PagedRequest
{
    public int Skip { get; set; }

    public int Take { get; set; }
    
    public List<SortExpression> SortExpressions { get; set; }
}