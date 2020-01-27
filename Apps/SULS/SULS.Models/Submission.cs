namespace SULS.Models
{
    using SIS.MvcFramework.Attributes.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        [RequiredSis]
        [MaxLength(800)]
        public string Code { get; set; }

        [RequiredSis]
        [Range(0, 300)]
        public int AchievedResult { get; set; }

        [RequiredSis]
        public DateTime CreatedOn { get; set; }

        public Problem Problem { get; set; }

        public User User { get; set; }
    }
}