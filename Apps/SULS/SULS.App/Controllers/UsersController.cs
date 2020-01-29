namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Users;
    using SULS.Models;
    using SULS.Services;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Users/Login");
            }

            User user = usersService.GetUserOrNull(model.Username, model.Password);

            if (user == null)
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Users/Register");
            }

            User user = usersService.CreateUser(model.Username, model.Password, model.Email);

            if (model.Password!=model.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            this.Logout();

            return Redirect("/");
        }
    }
}