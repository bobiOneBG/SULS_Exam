namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System;
    using System.Linq;

    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext db;

        public SubmissionService(SULSContext db)
        {
            this.db = db;
        }

        public void CreateSubmission(string problemId, string code, string userId)
        {
            Random random = new Random();

            var problem = db.Problems.SingleOrDefault(p => p.Id == problemId);

            var user = db.Users.SingleOrDefault(u => u.Id == userId);

            var submission = new Submission
            {
                AchievedResult = random.Next(0, problem.Points),
                Problem = problem,
                Code = code,
                CreatedOn = DateTime.UtcNow,
                User = user
            };

            db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public string GetProblemName(string problemId)
        {
            var name = db.Problems.FirstOrDefault(p => p.Id == problemId).Name;

            return name;
        }

        public int GetProblemSubmissionsCount(string problemId)
        {
            var count = db.Submissions.Where(s => s.Problem.Id == problemId).Count();

            return count;
        }
    }
}