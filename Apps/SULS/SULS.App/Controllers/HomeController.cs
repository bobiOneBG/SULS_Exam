namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Home;
    using SULS.Services;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly ISubmissionService submissionService;

        public HomeController(IHomeService homeService, ISubmissionService submissionService)
        {
            this.homeService = homeService;
            this.submissionService = submissionService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var problems = homeService
                    .GetAllProblems()
                    .Select(x => new HomeLoggedInViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Count = submissionService.GetProblemSubmissionsCount(x.Id)
                    });

                return this.View(problems, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}