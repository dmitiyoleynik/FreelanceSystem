using DataAccessLayer;

namespace BussinessLayer.Validators
{
    public class UsersValidator : IUsersValidator
    {
        private readonly IUsersManager _usersManager;
        public UsersValidator(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        public bool IsExists(string login,string pass)
        {
            return _usersManager.GetUserPassword(login) == pass;
        }
    }
}
