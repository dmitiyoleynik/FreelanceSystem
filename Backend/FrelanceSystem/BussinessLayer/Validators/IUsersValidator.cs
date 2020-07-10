namespace BussinessLayer.Validators
{
    public interface IUsersValidator
    {
        bool IsExists(string login, string pass);
    }
}
