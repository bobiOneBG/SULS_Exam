namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Submissions;
    using SULS.Services;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(ProblemIdModel model)
        {
            string name = this.submissionService.GetProblemName(model.Id);

            CreateSubmissionsModel problemData = new CreateSubmissionsModel
            {
                Name = name,
                ProblemId = model.Id
            };

            return this.View(problemData);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PostSubmissionModel model)
        {
            if (!this.ModelState.IsValid)
            {
                ProblemIdModel navigationModel = new ProblemIdModel { Id = model.ProblemId };
                return this.Create(navigationModel);
            }

            this.submissionService.CreateSubmission(model.ProblemId, model.Code, this.User.Id);
            return this.Redirect("/");
        }
    }
}