namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

public class HomeService: IHomeService
    {
        private readonly SULSContext db;

        public HomeService(SULSContext db)
        {
            this.db = db;
        }

        public IQueryable<Problem> GetAllProblems()
        {
            IQueryable<Problem> problems = db.Problems;

            return problems;
        }
    }
}
