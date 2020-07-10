using DataAccessLayer.Models;
namespace DataAccessLayer
{
    public interface IUsersManager
    {
        string GetUserPassword(string email);
    }
}
