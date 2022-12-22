using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Helpers
{
    public static class Extension
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime TheDateTime)
        {
            var age = DateTime.Today.Year - TheDateTime.Year;
            if(TheDateTime.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}