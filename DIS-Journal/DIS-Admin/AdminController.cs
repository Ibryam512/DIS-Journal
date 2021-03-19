using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Admin
{
    public class AdminController
    {
        public AdminDbContext context = new AdminDbContext();

        public List<User> GetAllUsers() => context.Users.ToList();

        public User GetUser(int id) => context.Users.Single(x => x.Id == id); 

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public bool Login(string email, string password)
        {
            var users = context.Users.Where(e => (e.Email == email || e.Username == email) && e.Password == password && e.Role == "admin").ToArray();
            if (users.Length != 0)
            {
                User user = users[0];
                Admin.Id = user.Id;
                Admin.Username = user.Username;
                Admin.Email = user.Email;
                Admin.Password = user.Password;
                Admin.Birth = user.Birth;
                Admin.Role = user.Role;
                return true;
            }
            return false;
        }
      
    }
}
