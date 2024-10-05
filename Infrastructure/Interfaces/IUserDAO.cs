using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserDAO
    {
        public Task<User> Login(string email, string password);
        public Task SignIn(User user);
        public Task UpdateUser(User original, User atualizada);
        public Task DeleteUser(int id);
        public Task<User> GetUserById(int id);
    }
}