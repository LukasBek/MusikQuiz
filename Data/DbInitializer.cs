using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusikQuiz.Models;

namespace MusikQuiz.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;
            }

            var testUser = new User[]
            {
                new User
                {
                    Id = "1", UserName = "QuizMaster123", Password = "123",
                    TimeCreated = DateTime.Now
                },
                new User
                {
                    Id = "2", UserName = "LukasNBek", Password = "321",
                    TimeCreated = DateTime.Now
                },
                new User
                {
                    Id = "3", UserName = "HenrikMesterQuizer", Password = "123",
                    TimeCreated = DateTime.Now
                }
            };

            foreach (User user in testUser)
            {
                context.User.Add(user);
            }

            context.SaveChanges();
        }

    }
}
