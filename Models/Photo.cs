using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Models
{
    public class Photo
    {
        public int Id {get;set;}
        public string Url {get;set;}
        public string Description {get;set;}
        public DateTime DateAdded  {get;set;} = DateTime.Now;
        public bool IsMain {get;set;}
        public User User {get;set;}
        public int? UserId {get;set;}
        
    }
}