using FitNote_API.Core.Interfaces;
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
            SeedExercises(context);
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
        public static void SeedExercises(AppDbContext context)
        {
            if (context.Exercises.Count() == 0)
            {
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name="Bench press"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Barbell push press"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Goblet squat"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Dumbbell single arm row"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Shoulder lateral raise"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Barbell bicep curls"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Deadlift"
                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Squat"

                });
                context.Exercises.Add(new Exercise()
                {
                    Exercise_name = "Bar dip"

                });
                context.SaveChangesAsync().Wait();
            }
        }



    }
}
