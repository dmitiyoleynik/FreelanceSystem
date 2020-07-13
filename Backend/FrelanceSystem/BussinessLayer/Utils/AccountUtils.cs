using DataAccessLayer;

namespace BussinessLayer.Utils
{
    public class AccountUtils : IAccountUtils
    {
        private readonly IUsersManager _usersManager;
        public AccountUtils(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        public string Login(string login, string password)
        {
            var user = _usersManager.GetUser(login);
            string id = null;

            if (user?.Password == password)
            {
                id = user.Id.ToString();
            }

            return id;
        }
    }
}
