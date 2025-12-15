namespace ProjectManagement.RestAPI.Contracts.Persistence;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveChangesAsync();
}
/*
public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
}



public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersWithItemsAsync();

    IQueryable<Order> Query();

    IQueryable<Order> FilterByCategory(
        IQueryable<Order> query, Category catrogry);

    IQueryable<Order> FilterByPriceRange(
        IQueryable<Order> query, decimal? minPrice, decimal? maxPrice);

    IQueryable<Order> FilterBySearchText(
        IQueryable<Order> query, string searchText);

    // server-side paging
    Task<(IReadOnlyList<Order> Items, int Total)> GetPagedAsync(
        IQueryable<Order> query, int page, int limit);
}

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(Category category);
    Task<IEnumerable<Product>> GetProductsInStockAsync();
    Task<IEnumerable<Product>> GetProductsWithLowestStockAsync();
}
*/