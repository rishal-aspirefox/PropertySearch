using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertySearch.Core.Entities;

namespace PropertySearch.Infrastructure.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region country Seeding
            var seedDate = new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local);
            var country1 = new Country { Id = Guid.Parse("f1d1a7b6-68a6-4d89-8cc9-b0b6e83a8767"), Name = "United States", Code = "USA" };
            var country2 = new Country { Id = Guid.Parse("fab9a17c-4d8f-468b-9d90-a9afba263d98"), Name = "Canada", Code = "CAN" };
            var country3 = new Country { Id = Guid.Parse("3966addb-172c-43f0-afb7-7a53ca03bb59"), Name = "India", Code = "IND" };
            var country4 = new Country { Id = Guid.Parse("ce6af6ca-30f7-4df5-9abf-5b9c5b2e4195"), Name = "United Kingdom", Code = "UK" };
            var country5 = new Country { Id = Guid.Parse("5ddb4208-6a29-49e6-8011-5a2224cec5de"), Name = "Australia", Code = "AUS" };

            modelBuilder.Entity<Country>().HasData(country1, country2, country3, country4, country5);
            #endregion

            #region States Seeding
            var state1 = new State { Id = Guid.Parse("4b805e95-4827-46c5-a2bd-4702871b3be5"), Name = "California", Code = "CA", CountryId = country1.Id };
            var state2 = new State { Id = Guid.Parse("89fd420c-c260-42f8-99bf-f15f9c0c8967"), Name = "Ontario", Code = "ON", CountryId = country2.Id };
            var state3 = new State { Id = Guid.Parse("ffcb5e16-71b2-4976-b859-4f7a58c177bf"), Name = "Maharashtra", Code = "MH", CountryId = country3.Id };
            var state4 = new State { Id = Guid.Parse("c5a345e8-c0fa-4a51-81fa-7ec0334e378c"), Name = "London", Code = "LDN", CountryId = country4.Id };
            var state5 = new State { Id = Guid.Parse("ec300f25-fddd-4d70-85b2-d55d297e48d7"), Name = "New South Wales", Code = "NSW", CountryId = country5.Id };

            modelBuilder.Entity<State>().HasData(state1, state2, state3, state4, state5);
            #endregion

            #region Properties Seeding
            var properties = new List<Property>
            {
                new Property
                {
                    Id = Guid.Parse("746ef692-61b6-4780-a02f-a36c1c96f4c5"),
                    Type = "Apartment", Price = 250000,
                    Description = "Modern 2BHK apartment near downtown Los Angeles.",
                    Address = "123 Main St", City = "Los Angeles", PostalCode = "90001",
                    StateId = state1.Id, CountryId = country1.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("1b3af3ce-cf6d-4af0-b352-5c79b13a893c"),
                    Type = "Apartment", Price = 150000,
                    Description = "Affordable studio in downtown LA.",
                    Address = "67 Sunset Blvd", City = "Los Angeles", PostalCode = "90028",
                    StateId = state1.Id, CountryId = country1.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("94827cea-127a-480d-9781-111e27d17256"),
                    Type = "Condo", Price = 450000,
                    Description = "Luxury condo with lake view in Toronto.",
                    Address = "45 Bay St", City = "Toronto", PostalCode = "M5J2X2",
                    StateId = state2.Id, CountryId = country2.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("ce993b27-6852-4f24-87ae-4163a81bf8ea"),
                    Type = "House", Price = 2000000,
                    Description = "Farmhouse in Ontario countryside.",
                    Address = "56 Greenfield Rd", City = "Ottawa", PostalCode = "K1A0B1",
                    StateId = state2.Id, CountryId = country2.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("c97eca96-eb6f-4859-b69c-7c7f5028d24c"),
                    Type = "Villa", Price = 15000000,
                    Description = "Spacious villa in Mumbai with private pool.",
                    Address = "78 Marine Drive", City = "Mumbai", PostalCode = "400020",
                    StateId = state3.Id, CountryId = country3.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("05fb82f6-fe00-4605-9546-81c03bba0a9c"),
                    Type = "Condo", Price = 30000000,
                    Description = "Ultra-luxury condo in South Mumbai.",
                    Address = "99 Altamount Rd", City = "Mumbai", PostalCode = "400026",
                    StateId = state3.Id, CountryId = country3.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("02fcd393-4074-4cee-b92c-ff873e9cf88e"),
                    Type = "House", Price = 800000,
                    Description = "Family house in central London.",
                    Address = "22 Baker St", City = "London", PostalCode = "NW16XE",
                    StateId = state4.Id, CountryId = country4.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("520c4026-1436-4b9c-a996-f0776b2b3131"),
                    Type = "Apartment", Price = 950000,
                    Description = "Modern apartment near Canary Wharf.",
                    Address = "15 Tower St", City = "London", PostalCode = "E145HQ",
                    StateId = state4.Id, CountryId = country4.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("44040603-ed61-4b7e-a4cb-e2625a126d21"),
                    Type = "House", Price = 1200000,
                    Description = "Large house in Sydney suburb.",
                    Address = "12 George St", City = "Sydney", PostalCode = "2000",
                    StateId = state5.Id, CountryId = country5.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Property
                {
                    Id = Guid.Parse("0039260c-1391-43fb-994d-acd845399ddc"),
                    Type = "Land", Price = 600000,
                    Description = "Spacious plot of land in the scenic Blue Mountains, ideal for building or investment.",
                    Address = "5 Hill Rd", City = "Blue Mountains", PostalCode = "2780",
                    StateId = state5.Id, CountryId = country5.Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                }
            };

            modelBuilder.Entity<Property>().HasData(properties);
            #endregion

            #region Spaces Seeding
            var spaces = new List<Space>
            {
                new Space
                {
                    Id = Guid.Parse("1f8e9140-6436-48c1-8877-4b791f5389aa"),
                    Type = "Bedroom",
                    Size = 200,
                    Description = "Master bedroom with attached bathroom.",
                    PropertyId = properties[0].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("d7f6c0d4-bf2c-4e4f-9e1f-3a0524523b30"),
                    Type = "Living Room",
                    Size = 350,
                    Description = "Spacious living area with balcony.",
                    PropertyId = properties[0].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("f812ebe2-0320-4e74-83e4-a4553d80e499"),
                    Type = "Kitchen",
                    Size = 180,
                    Description = "Modular kitchen with modern fittings.",
                    PropertyId = properties[1].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("5d546e7d-ab65-413a-b4f3-71cdfff51f80"),
                    Type = "Garage",
                    Size = 500,
                    Description = "2-car parking garage.",
                    PropertyId = properties[1].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("4a1eccc5-d9ad-42a7-842c-57d4d2be7c1f"),
                    Type = "Garden",
                    Size = 800,
                    Description = "Private landscaped garden.",
                    PropertyId = properties[2].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("f16c0f05-c758-416e-8d30-bd764dc2389b"),
                    Type = "Living Room",
                    Size = 350,
                    Description = "Spacious living room with natural light and modern furniture.",
                    PropertyId = properties[2].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("bdb47a89-5aa8-4eda-baba-7515b97231b2"),
                    Type = "Bedroom",
                    Size = 180,
                    Description = "Cozy bedroom with built-in wardrobe and large window.",
                    PropertyId = properties[3].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("5a1d9fb0-6d93-4d91-a0c0-d630e91a9d49"),
                    Type = "Bedroom",
                    Size = 200,
                    Description = "Master bedroom with ensuite bathroom and balcony view.",
                    PropertyId = properties[3].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("6497a348-d03d-4ccc-b7a2-115a588ed337"),
                    Type = "Kitchen",
                    Size = 150,
                    Description = "Modern kitchen with island and high-end appliances.",
                    PropertyId = properties[4].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("8e07e7ef-9ff2-4de5-af69-dc976cefd76e"),
                    Type = "Garage",
                    Size = 220,
                    Description = "Two-car garage with storage space and automatic door.",
                    PropertyId = properties[4].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("3eaa205a-a8a2-4436-a716-73617039498c"),
                    Type = "Living Room",
                    Size = 400,
                    Description = "Open-plan living room with modern decor and entertainment area.",
                    PropertyId = properties[5].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("b4bb1cff-d02f-4981-943e-af1fa11dc1e1"),
                    Type = "Garden",
                    Size = 500,
                    Description = "Well-maintained garden with outdoor seating and plants.",
                    PropertyId = properties[5].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("376f54b3-e5cf-46e9-a202-f3c2961b2c75"),
                    Type = "Garage",
                    Size = 300,
                    Description = "Spacious garage suitable for two vehicles and storage.",
                    PropertyId = properties[6].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("f9319ede-ddcd-4abe-9f5f-97291254906c"),
                    Type = "Bedroom",
                    Size = 160,
                    Description = "Guest bedroom with comfortable bed and study desk.",
                    PropertyId = properties[6].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                },
                new Space
                {
                    Id = Guid.Parse("9813899c-035b-4451-b947-90d39739c3e8"),
                    Type = "Living Room",
                    Size = 450,
                    Description = "Elegant living room with fireplace and entertainment setup.",
                    PropertyId = properties[7].Id,
                    CreatedAt = seedDate,
                    UpdatedAt = null
                }
            };

            modelBuilder.Entity<Space>().HasData(spaces);
            #endregion
        }

        #region User Seeding
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            var adminUserId = "d7a4b61a-7f33-4d2c-9fc2-0d94a7e7c6f7";
            var adminRoleId = "6c7a4b20-5f33-4a1c-8e5d-3a2f0c123456";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = adminUserId,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGkjwkbi0S+xI4L6k66/svhooc3wb8nGhv1l0HcG25qG+KrtNz3qeZ9dXbgvUvAGhg==",
                SecurityStamp = "8b9a6f12-3f62-4a4a-9425-4dbe49e2c63d",
                ConcurrencyStamp = "7c3d4527-77be-48ae-a7bb-993b8f779c68"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
        #endregion

    }
}
