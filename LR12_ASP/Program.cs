using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LR12_ASP
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AppDbContext())
            {
                dbContext.Database.EnsureCreated();

                dbContext.Users.AddRange(
                    new User { FirstName = "Павло", LastName = "Зачиняєв", Age = 21 },
                    new User { FirstName = "Петро", LastName = "Петров", Age = 22 },
                    new User { FirstName = "Марія", LastName = "Петренко", Age = 32 }
                );
                dbContext.SaveChanges();

                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Ім'я: {user.FirstName}, Прізвище: {user.LastName}, Вік: {user.Age}");
                }
            }
        }
    }
}
