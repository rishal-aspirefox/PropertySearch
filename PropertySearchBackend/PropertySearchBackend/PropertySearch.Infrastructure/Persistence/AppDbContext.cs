using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertySearch.Core.Entities;
using PropertySearch.Infrastructure.Persistence.Seed;

namespace PropertySearch.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Property>().HasIndex(p => p.Price);

            builder.Entity<Property>().HasIndex(p => p.Type);

            builder.Entity<Space>().HasIndex(s => s.Type); 

            builder.Entity<Space>().HasIndex(s => s.Size);

            builder.SeedUser();

            builder.SeedData();

            builder.Entity<Property>()
                 .HasOne(p => p.State)
                 .WithMany(s => s.Properties)
                 .HasForeignKey(p => p.StateId)
                 .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<Property>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
