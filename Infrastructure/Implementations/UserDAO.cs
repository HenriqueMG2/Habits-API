using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class UserDAO(Context _Context) : IUserDAO
    {
        private readonly Context DbContext = _Context;
        public async Task DeleteUser(int id)
        {
                var user = await GetUserById(id);

                DbContext.Remove(user);
                await DbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var query = await (from USR in DbContext.Users
                                   where USR.UserId == id
                                   select USR
                                  )
                                  .FirstOrDefaultAsync();

                return query;
            }
            catch(DbUpdateException)
            {
                throw new Exception("Usuário ou senha incorretos!.");
            }
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                var query = await (from USR in DbContext.Users
                                   where USR.Email == email && USR.Password == password
                                   select USR
                                  )
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync();

                return query;
            }
            catch(DbUpdateException)
            {
                throw new Exception("Usuário ou senha incorretos!.");
            }
        }

        public async Task SignIn(User user)
        {
            try
            {
                DbContext.Add(user);
                await DbContext.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new Exception("Erro ao cadastrar o usuário.");
            }
        }

        public async Task UpdateUser(User original, User atualizada)
        {
            throw new NotImplementedException();
        }
    }
}