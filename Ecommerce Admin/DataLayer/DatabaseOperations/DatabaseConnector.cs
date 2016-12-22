using CommonComponent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer.DatabaseOperations
{
    public class DatabaseConnector : DbContext
    {
        public DatabaseConnector() : base()
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public List<Category> GetCategory(string searchtext)
        {
            List<Category> categoryList = null;
            try
            {
                var categories = from c in Categories
                                 select c;
                if (!String.IsNullOrEmpty(searchtext))
                {
                    categories = categories.Where(s => s.CategoryName.Contains(searchtext));
                }
                if (categories != null)
                {
                    categoryList = categories.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return categoryList;
        }

        public int IsValidUser(User user)
        {
            int result = -1;
            try
            {
                if (user != null && user.UserEmailId != null && user.Password != null)
                {
                    var users = from c in Users
                                select c;

                    users = users.Where(s => (s.UserEmailId.Equals(user.UserEmailId) && s.Password.Equals(user.Password)));

                    if (users != null)
                    {
                        var userList = users.ToList();
                        if(userList.Count > 0)
                        {
                            result = userList[0].UserId;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
            return result;
        }

        public bool DeleteCategory(int id)
        {
            bool result = true;
            Category category = null;
            try
            {
                category = Categories.Find(id);
                Categories.Remove(category);
                SaveChanges();
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
       
        public List<Product> GetProduct(string searchtext)
        {
            List<Product> productList = null;
            try
            {
                var products = from p in Products
                               select p;
                if (!String.IsNullOrEmpty(searchtext))
                {
                    products = products.Where(s => s.ProductName.Contains(searchtext));
                }
                if (products != null)
                {
                    productList = products.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return productList;
        }

        public int Saveuser(User user)
        {

            int UserId = -1;
            try
            {
               Users.Add(user);
              UserId= SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return UserId;
        }

        public List<User> Getuser(string searchtext)
        {
            List<User> userList = null;
            try
            {
                var users = from u in Users
                            select u;
                if (!string.IsNullOrEmpty(searchtext))
                {
                    users = users.Where(s => s.UserEmailId.Contains(searchtext));
                }
                if (users != null)
                {
                    userList = users.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return userList;
        }

        public int EditProduct(Product product)
        {
            int Id = -1;
            try
            {
                Entry(product).State = EntityState.Modified;
                Id =SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Id;
        }

        public int EditUser(User user)
        {
            int Id = -1;
            try
            {
                Entry(user).State = EntityState.Modified;
                Id= SaveChanges();

            }
            catch (Exception ex)
            {
                
            }
            return Id;
        }

        public int SaveCategory(Category category)
        {
            int CategoryId = -1;
            try
            {
                Categories.Add(category);
                CategoryId = SaveChanges();
                
            }
            catch(Exception ex)
            {

            }
            return CategoryId;
            
        }

        public int SaveProduct(Product product)
        {
            int ProductId = -1;
            try
            {
                Products.Add(product);
                ProductId = SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
            return ProductId;
        }

        public int EditCategory(Category category)
        {
            int Id = -1;
            try
            {
                Entry(category).State = EntityState.Modified;
                Id =SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Id;
        }

       /* public Category CheckCategory(int? id)
        {
            throw new NotImplementedException();
        }*/

        public bool DeleteProduct(int id)
        {
            bool result = true;
            try
            {
                Product product = Products.Find(id);
                Products.Remove(product);
                SaveChanges();
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
            
        }

        public bool DeleteUser(int id)
        {

            bool result = true;
            try
            {
                User user = Users.Find(id);
                Users.Remove(user);
                SaveChanges();
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}