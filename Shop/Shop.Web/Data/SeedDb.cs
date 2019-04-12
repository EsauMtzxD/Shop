using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {

        private readonly DataDbContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataDbContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("mtzab6@gmial.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Esau",
                    LastName = "Mtz.",
                    MotherLastName = "Moreno",
                    Email = "mtzab6@gmial.com",
                    UserName = "mtzab6@gmial.com",
                    PhoneNumber = "8183664531"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvalible = true,
                Stock = this.random.Next(100),
                User = user,
            });
        }


    }
}
