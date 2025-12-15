namespace ProjectManagement.RestAPI.DTOs;

// 4) Example: unified read DTOs usage (choose one flavor in your API)
public class PagedResultDto<T>
{
    public int TotalCount { get; set; }
    public List<T> Items { get; set; } = new List<T>();
}