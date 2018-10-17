using ASPNetCoreHangfire.Services.Users;
using System;

namespace ASPNetCoreHangfire.Jobs
{
    public class ExampleJob
    {
        private readonly IUsersService _usersService;

        private Random rand = new Random();

        public ExampleJob(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void Run()
        {
            var names = _usersService.GetNames();
            var pickedName = names[rand.Next(names.Count)];

            System.Diagnostics.Debug.WriteLine($"The job is running now and my picked name is {pickedName}");
        }
    }
}
