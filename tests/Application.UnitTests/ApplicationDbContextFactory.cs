using Clean_Architecture_Task.Application.Common.Interfaces;
using Clean_Architecture_Task.Domain.Entities;
using Clean_Architecture_Task.Infrastructure.Persistence;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;

namespace Clean_Architecture_Task.Application.UnitTests.Common
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new ApplicationDbContext(
                options, operationalStoreOptions,
                currentUserServiceMock.Object, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        {
            context.TodoLists.AddRange(
                new TodoList { Id = 1, Title = "Shopping" }
            );

            context.TodoItems.AddRange(
                new TodoItem { Id = 1, ListId = 1, Title = "Bread", Done = true },
                new TodoItem { Id = 2, ListId = 1, Title = "Butter", Done = true },
                new TodoItem { Id = 3, ListId = 1, Title = "Milk" },
                new TodoItem { Id = 4, ListId = 1, Title = "Sugar" },
                new TodoItem { Id = 5, ListId = 1, Title = "Coffee" }
            );

             context.Categories.AddRange(
                new Category { Id = 1, Name = "Men Clothes" , Disabled = false } ,
                new Category { Id = 2, Name = "Women Clothes" , Disabled = false} ,
                new Category { Id = 3, Name = "Childrens Clothes" , Disabled = true}
            );

             context.Products.AddRange(
                new Product { Id = 1, Name = "Men_TShirt" , Disabled = false, CategoryId  = 1 , BarCode =  "Men_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  { Id = 2, Name = "Men_Jacket" , Disabled = false , CategoryId  = 1 , BarCode =  "Men_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  { Id = 3, Name = "Men_Cap" , Disabled = true , CategoryId  = 1 , BarCode =  "Men_000003" , Description = "Description ..." , SellingPrice = 105},
                new Product { Id = 4, Name = "Women_TShirt" , Disabled = false, CategoryId  = 1 , BarCode =  "Women_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  { Id = 5, Name = "Women_Jacket" , Disabled = false , CategoryId  = 1 , BarCode =  "Women_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  { Id = 6, Name = "Women_Cap" , Disabled = true , CategoryId  = 1 , BarCode =  "Women_000003" , Description = "Description ..." , SellingPrice = 105},
                new Product { Id = 7, Name = "Child_TShirt" , Disabled = false, CategoryId  = 1 , BarCode =  "Child_000001" , Description = "Description ..." , SellingPrice = 100 } ,
                new Product  { Id = 8, Name = "Child_Jacket" , Disabled = false , CategoryId  = 1 , BarCode =  "Child_000002" , Description = "Description ..." , SellingPrice = 130} ,
                new Product  { Id = 9, Name = "Child_Cap" , Disabled = true , CategoryId  = 1 , BarCode =  "Child_000003" , Description = "Description ..." , SellingPrice = 105}
            );
            context.SaveChanges();
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}