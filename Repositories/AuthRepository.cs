using DataAccess.Interfaces;
using DataAccess.Models;
using Repositories.Models;

namespace Repositories;

public class AuthRepository
{
    private IDapperContext _dapperContext;

    public AuthRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    
    public async Task<DbUser> AddUser(string username, string hashedPassword)
    {
        return await _dapperContext.CommandWithResponse<DbUser>(
            new QueryObject($"INSERT INTO USERS(username, hashed_password) VALUES(@username, @hashedPassword) RETURNING id, username, hashed_password as {nameof(DbUser.HashedPassword)}", new {username, hashedPassword}));
    }

    public async Task<DbUser?> GetUserByUsername(string username)
    {
        return await _dapperContext.FirstOrDefault<DbUser>(
            new QueryObject($"SELECT id, username, hashed_password as {nameof(DbUser.HashedPassword)} FROM USERS WHERE username = @username", new { username }));
    }
}