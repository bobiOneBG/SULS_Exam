namespace SULS.Services
{
    using SULS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IHomeService
    {
        IQueryable<Problem> GetAllProblems();
    }
}