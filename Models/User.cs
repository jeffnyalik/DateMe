using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Models
{
    public class User : BaseModel
    {
        public int Id {get; set;}
        public string UserName {get;set;}
        public int Age {get;set;}
        public string Email {get; set;}
        public string Password {get;set;}
        public string Gender {get;set;}
        public string KnownAs {get;set;}
        public DateTime LasActive {get;set;} = DateTime.Now;
        public DateTime DateOfBirth {get;set;} = DateTime.Now;
        public string LookingFor {get; set;}
        public string Introduction {get;set;}
        public string Interests {get;set;}
        public string City {get;set;}
        public string Country {get;set;}
        public ICollection<Photo> Photos {get;set;}
    }
}