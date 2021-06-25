using System.Collections.Generic;
using CoreServiceApi.Models;

namespace CoreServiceApi.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        User GetLoginUser(string username, string password);
        bool SaveChanges();
    }
}