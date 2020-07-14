using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IUsersManager
    {
        User GetUser(string email);
    }
}
