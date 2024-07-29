using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ContactsManager.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace ContactsManager.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> // Changed to IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Add any specific configuration for your models
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategories");

            // Seed data or configure relationships if necessary
        }
    }
}
