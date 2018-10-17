using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreHangfire.Services.Users
{
    public interface IUsersService
    {
        List<string> GetNames();
    }
}
