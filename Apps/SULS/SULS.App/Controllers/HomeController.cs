
namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using System;

    public class HomeController:Controller
    {
        [HttpGet(Url ="/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        private IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return null;
            }

            return this.View();
        }
    }
}