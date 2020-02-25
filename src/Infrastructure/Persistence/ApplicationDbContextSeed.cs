using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using Clean_Architecture_Task.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean_Architecture_Task.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            var defaultUser = new ApplicationUser { UserName = "ahmed@clean-architecture", Email = "ahmed@clean-architecture" };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "Clean_Architecture_Task!");
            }
            if (context.Categories.Count() == 0 && context.Products.Count() == 0)
            {
                var cat1_products = new List<Product>{
                        new Product {  Name = "Men_TShirt" , Disabled = false, BarCode =  "Men_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  {  Name = "Men_Jacket" , Disabled = false , BarCode =  "Men_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  {  Name = "Men_Cap" , Disabled = true ,  BarCode =  "Men_000003" , Description = "Description ..." , SellingPrice = 105} 
                };
                 var cat2_products = new List<Product>{ 
                     new Product {  Name = "Women_TShirt" , Disabled = false, BarCode =  "Women_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  {  Name = "Women_Jacket" , Disabled = false , BarCode =  "Women_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  {  Name = "Women_Cap" , Disabled = true ,  BarCode =  "Women_000003" , Description = "Description ..." , SellingPrice = 105} 
                };

                var cat3_products = new List<Product>{
                    new Product {  Name = "Child_TShirt" , Disabled = false, BarCode =  "Child_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  {  Name = "Child_Jacket" , Disabled = false , BarCode =  "Child_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  {  Name = "Child_Cap" , Disabled = true ,  BarCode =  "Child_000003" , Description = "Description ..." , SellingPrice = 105} 
                };


                context.Categories.AddRange(
                  new Category {
                      Name = "Men Clothes", 
                      Disabled = false ,
                      Products = cat1_products
                  },
                  new Category { 
                      Name = "Women Clothes", 
                      Disabled = false,
                      Products = cat1_products
                   },
                  new Category { 
                      Name = "Childrens Clothes", 
                      Disabled = true,
                      Products = cat1_products 
                   }
              );
                 context.SaveChanges();
            }
        }
    }
}
