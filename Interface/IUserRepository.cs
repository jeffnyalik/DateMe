using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Models;

namespace DatingAPI.Interface
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool>SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<Photo>GetPhoto(int id);
        Task<Photo>GetMainPhotoForUser(int UserId);
    }
}