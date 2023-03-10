using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Dtos
{
    public class PhotoCreatingDto
    {
        public string Url {get;set;}
        public IFormFile File {get;set;}
        public string Description {get;set;}
        public DateTime DateAdded  {get;set;} = DateTime.Now;
        public string PublicId {get;set;}
    }
}