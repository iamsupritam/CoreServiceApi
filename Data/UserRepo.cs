using System.Collections.Generic;
using System.Linq;
using CoreServiceApi.Data;
using System;
using CoreServiceApi.Models;

namespace CoreServiceApi.data
{
    public class UserRepo : IUserRepo
    {
        private readonly CoreServiceApiContext _context;

        public UserRepo(CoreServiceApiContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            _context.Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetLoginUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(f => f.UserName == username && f.Password == password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            //throw new NotImplementedException();
        }
    }
}