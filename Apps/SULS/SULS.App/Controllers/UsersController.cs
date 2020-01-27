namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;

    public class UsersController:Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(string s)
        {
            return null;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(string i)
        {
            return null;
        }
    }
}