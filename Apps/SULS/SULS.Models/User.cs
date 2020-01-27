namespace SULS.Models
{
    using SIS.MvcFramework.Attributes.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [RequiredSis]
        [MaxLength(20)]
        public string Username { get; set; }

        [RequiredSis]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}