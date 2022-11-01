using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PuniPuniBook.Domain;
using PuniPuniBook.Shared;

namespace PuniPuniBook.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception e)
            {

            }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "punipuni@gmail.com",
                    Email = "punipuni@gmail.com",
                    Name = "Bars",
                    PhoneNumber = "1112223333",
                    StreetAddress = "test 123123",
                    State = "CA",
                    PostalCode = "07422",
                    City = "Antalya"
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "punipuni@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }

            if (!_db.CoverTypes.Any())
            {
                _db.CoverTypes.AddRange(new CoverType { Name = "Soft" }, new CoverType { Name = "Hard" }, new CoverType { Name = "Paperback" });
            }

            if (!_db.Categories.Any())
            {
                _db.Categories.AddRange(new Category { Name = "Fiction" }, new Category { Name = "Non-Fiction" }, new Category { Name = "Biography" });
            }

            _db.SaveChanges();

            var firstCoverType = _db.CoverTypes.First();
            var firstCategory = _db.Categories.First();
            
            if (!_db.Products.Any())
            {
                _db.Products.AddRange(
                    new Product
                    {
                        Title = "Madonna In A Fur Coat",
                        Description = "An unforgettable hearth touching love story from 1943's.",
                        ISBN = "12313213",
                        Author = "Sabahattin Ali",
                        ListPrice = 10,
                        Price = 7,
                        Price50 = 6,
                        Price100 = 4.90,
                        ImageUrl = @"images\products\8a6d362c-9d7d-4af6-80d7-3c68241b7c75.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "Anna Karenina",
                        Description = "19th century Russian love story and betrayal.",
                        ISBN = "12313213",
                        Author = "Lev Tolstoy",
                        ListPrice = 12,
                        Price = 8,
                        Price50 = 7,
                        Price100 = 5,
                        ImageUrl = @"images\products\0d11c77c-b477-4f7e-9362-1e0ea12f899b.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "Metamorphosis",
                        Description = "One day, a young guy wakes up as a cockroach in the morning.",
                        ISBN = "12313213",
                        Author = "Franz Kafka",
                        ListPrice = 9.99,
                        Price = 7,
                        Price50 = 6,
                        Price100 = 4.90,
                        ImageUrl = @"images\products\bfffcea0-f5e1-4a47-9412-08e3e49cb1f9.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "No Longer Human",
                        Description = "After war Japan's society breakdown and the main character's mental breakdown.",
                        ISBN = "12313213",
                        Author = "Osamu Dazai",
                        ListPrice = 9.90,
                        Price = 7,
                        Price50 = 6,
                        Price100 = 4.99,
                        ImageUrl = @"images\products\b01f7424-23e9-4c80-b8cb-60bfe399aeb2.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "Madame Chrysanthème",
                        Description = "A love story of French navy soldier and Japanese women. Explaining Japan's society after war.",
                        ISBN = "12313213",
                        Author = "Pierre Loti",
                        ListPrice = 20,
                        Price = 10,
                        Price50 = 10,
                        Price100 = 7.99,
                        ImageUrl = @"images\products\b1394067-bba5-42e4-a2bf-4f679dc08d0c.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "Giants And Thieves",
                        Description = "Do we really care about small things in our life? This book will make you think about it.",
                        ISBN = "12313213",
                        Author = "Julian Phantom",
                        ListPrice = 5,
                        Price = 3,
                        Price50 = 2,
                        Price100 = 1.90,
                        ImageUrl = @"images\products\70980216-4f8b-48c7-81aa-0f96ce2ab902.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    },
                    new Product
                    {
                        Title = "Hunger Games",
                        Description = "Futuristic world where children are forced to fight each other to survive the hunger.",
                        ISBN = "12313213",
                        Author = "Suzanne Collins",
                        ListPrice = 15,
                        Price = 12,
                        Price50 = 10,
                        Price100 = 9.90,
                        ImageUrl = @"images\products\ab9382e7-f733-40b2-8e87-91888308b498.jpg",
                        CategoryId = firstCategory.Id,
                        CoverTypeId = firstCoverType.Id
                    });
            }

            _db.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
