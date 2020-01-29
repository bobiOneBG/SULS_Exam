
namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;

    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name=name,
                Points=points
            };

            db.Problems.Add(problem);
            db.SaveChanges();
        }
    }
}
