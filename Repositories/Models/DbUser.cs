namespace Repositories.Models;

public class DbUser
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
}