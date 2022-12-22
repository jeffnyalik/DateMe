using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Data.DataContext;
using DatingAPI.Models;
using Newtonsoft.Json;

namespace DatingAPI.Data.Seeder
{
    public class UserSeeder
    {
        public static void SeedUsers(DateApiContext context)
        {
            if(!context.Users.Any())
            {
                var UserData = System.IO.File.ReadAllText("users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(UserData);
                foreach(var user in users)
                {
                    user.UserName = user.UserName.ToLower();
                    user.Email = user.Email;
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    context.Users.Add(user);
                }
                context.SaveChanges();
            }
        }
    }
}