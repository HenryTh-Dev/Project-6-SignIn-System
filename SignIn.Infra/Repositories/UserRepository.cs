using Microsoft.EntityFrameworkCore;
using SignIn.Domain.Models;
using System.Linq;

namespace SignIn.Infra.Repositories
{
    public class UserRepository
    {
        public bool GetUserEmail(string email)
        {
            using var db = new Context.UserContext();
            var emailExists = db.User.AsNoTracking().Where(p => p.Email == email).ToList();
            if (emailExists.Count > 0)
            {
                return true;
            }
            return false;
        }
        public User GetUser(string email)
        {
            using var db = new Context.UserContext();
            var methodQuery = db.User.AsNoTracking().Where(p => p.Email == email).ToList();
            User user = methodQuery.Find(c => c.Id > 0);

            return user;
        }
        public bool UserRegistry(User user)
        {
            var db = new Context.UserContext();
            db.User.Add(user);
            db.SaveChanges();
            return true;
        }
        public bool ChangePassword(string password,User user)
        {
            using var db = new Context.UserContext();
            var userfind = db.User.Find(user.Id);
            userfind.Password = password;
            db.User.Update(userfind);
            db.SaveChanges();
            return true;
        }
        public bool RandomPasswordChangedMarkTrue(User user)
        {
            using var db = new Context.UserContext();
            var userfind = db.User.Find(user.Id);
            userfind.ChangedPass = true;
            db.User.Update(userfind);
            db.SaveChanges();
            return true;
        }
        public bool RandomPasswordChangedMarkFalse(User user)
        {
            using var db = new Context.UserContext();
            var userfind = db.User.Find(user.Id);
            userfind.ChangedPass = false;
            db.User.Update(userfind);
            db.SaveChanges();
            return true;
        }
    }
}
