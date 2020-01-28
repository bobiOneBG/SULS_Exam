namespace SULS.Services
{
    using SULS.Models;

    public interface IUsersService
    {
        User GetUserOrNull(string username, string password);

        User CreateUser(string username, string password, string email);
    }
}