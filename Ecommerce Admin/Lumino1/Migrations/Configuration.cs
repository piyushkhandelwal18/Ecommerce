namespace CommonComponent.Migrations
{
    using DataLayer.DatabaseOperations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseConnector>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseConnector context)
        {
            context.Categories.AddOrUpdate(i => i.CategoryName,
                new Models.Category
                {
                    CategoryName = "Computer",
                    Description = "Computer",
                   
                    DisplayOrder = 1,
                   Published = true

                },
 
                new Models.Category
                {
                    CategoryName = "Electronics",
                     Description = "Electronics",
                   
                    DisplayOrder = 2,
                    Published = false
                }
                );
            context.Products.AddOrUpdate(i => i.ProductName,
                new Models.Product
                {
                    ProductName ="Apple macbook",
                    ProductPrize = 20000,
                    ProductImage = 1
                },
                new Models.Product
                {
                    ProductName = "Own Computer",
                    ProductPrize = 12000,
                    ProductImage = 2
                }
                
                );
            context.Users.AddOrUpdate(i => i.UserEmailId,
                new  Models.User
                {
                    UserFirstName ="Sonali",
                    UserLastName = "Warhade",
                    UserEmailId = "sonali@gmail.com",
                   
                    
                },
                new Models.User
                {
                    UserFirstName = "Rutuja",
                    UserLastName = "Mate",
                    UserEmailId = "rutuja@gmail.com",
                  
                }

                );

        }
    }
}
