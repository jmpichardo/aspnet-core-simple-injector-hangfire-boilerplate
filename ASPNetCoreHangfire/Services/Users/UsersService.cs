using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreHangfire.Services.Users
{
    public class UsersService : IUsersService
    {
        public List<string> GetNames()
        {
            return new List<string>()
            {
                "Juan",
                "Shane",
                "Nick",
                "Damilola",
                "Karim",
                "Carl",
                "Huseyin",
            };
        }
    }
}
