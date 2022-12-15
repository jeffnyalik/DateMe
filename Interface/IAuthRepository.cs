using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Models;

namespace DatingAPI.Interface
{
    public interface IAuthRepository
    {
       User Create(User user);
       User GetByEmail(string email);
       Task<bool>UserExists(string username);
       Task<bool>EmailExists(string email);
    }
}