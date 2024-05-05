namespace DataAccess.Interfaces;

public interface IDapperContext
{
    Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject);
    Task<T?> FirstOrDefault<T>(IQueryObject queryObject);
    Task Command(IQueryObject queryObject);
    Task<T> CommandWithResponse<T>(IQueryObject queryObject);
}