namespace SULS.Services
{
    using SULS.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

public class SubmissionService:ISubmissionService
    {
        private readonly SULSContext db;

        public SubmissionService(SULSContext db)
        {
            this.db = db;
        }

        public int GetProblemSubmissionsCount(string problemId)
        {
            var count = db.Submissions.Where(s => s.Problem.Id == problemId).Count();

            return count;
        }
    }
}
