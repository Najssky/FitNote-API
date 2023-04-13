using FitNote_API.Data.Models;
using System;
using System.Linq;

namespace FitNote_API.Data.Database
{
    public class DatabaseSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            SeedUser(context);
        }

        public static void SeedUser(AppDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new User()
                {
                    Email = "admin@fitnote.pl",
                    Password = "AQAAAAEAACcQAAAAEI + PjxFUCPXyZnkOatVFZASGSFQNc6sjHScYEQIW9aF5m8sqw2 + J1wDXYtBMmyEaJA ==",
                    Name = "Admin",
                    Lastname = "Admin",
                    Token = Guid.Empty,
                    Phone_number = "123456789",
                    Role = "Admin",

                });
                context.SaveChangesAsync().Wait();
            }
        }

       
    }
}
