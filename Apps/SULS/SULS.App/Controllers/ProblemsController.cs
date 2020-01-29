namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Problems;
    using SULS.Services;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return Redirect("/Problems/Create");
            }

            problemsService.CreateProblem(model.Name, model.Points);

            return this.Redirect("/");
        }
    }
}
