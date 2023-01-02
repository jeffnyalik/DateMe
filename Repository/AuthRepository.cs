using System;
using System.Collections.Generic;
using DatingAPI.Interface;
using DatingAPI.Data.DataContext;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DateApiContext context;
        public AuthRepository(DateApiContext context)
        {
            this.context = context;
        }

        public User Create(User user)
        {
            context.Users.Add(user);
            user.Id  = context.SaveChanges();
            return user;
        }

        public async Task<bool> EmailExists(string email)
        {
            if(await context.Users.AnyAsync(x =>x.Email == email))
            {
                return true;
            }
            return false;
        }

        public User GetByEmail(string email)
        {
            return context.Users.Include(p =>p.Photos).FirstOrDefault(x =>x.Email == email);
        }

        public async Task<bool> UserExists(string username)
        {
            if(await context.Users.Include(p =>p.Photos).AnyAsync(x =>x.UserName == username))
            {
                return true;
            }
            return false;
        }
    }
}