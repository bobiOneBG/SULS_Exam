
namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    public class UsersService : IUsersService
    {
        private readonly SULSContext db;

        public UsersService(SULSContext db)
        {
            this.db = db;
        }

        public User CreateUser(string username, string password, string email)
        {
            var user = new User
            {
                Username=username,
                Password=this.HashPassword(password),
                Email=email
            };

            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public User GetUserOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);

            var user = db.Users.SingleOrDefault(u => u.Username == username &&
                  u.Password == passwordHash);
            return user;
        }

        private string HashPassword(string password)
        {
            SHA256 sHA256 = SHA256.Create();

            var passwordHash = Encoding.UTF8
                .GetString(sHA256.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return passwordHash;
        }
    }
}
