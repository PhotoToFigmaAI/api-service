using DataAccess.Interfaces;

namespace DataAccess.Models;

public class QueryObject : IQueryObject
{
    public string Sql { get; }
    public object Params { get; }

    public QueryObject(string sql, object parameters)
    {
        Sql = sql;
        Params = parameters;
    }
}