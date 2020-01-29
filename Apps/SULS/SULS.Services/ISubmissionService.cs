namespace SULS.Services
{
    public interface ISubmissionService
    {
        int GetProblemSubmissionsCount(string problemId);
        string GetProblemName(string problemId);
        void CreateSubmission(string problemId, string code, string userId);
    }
}