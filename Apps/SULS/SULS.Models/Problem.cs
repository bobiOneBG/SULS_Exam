namespace SULS.Models
{
    using SIS.MvcFramework.Attributes.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [RequiredSis]
        [MaxLength(20)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50,300, "Invalid points value")]
        public int Points { get; set; }
    }
}