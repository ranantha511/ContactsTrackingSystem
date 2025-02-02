
using ContactTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics.Metrics;
using System;

namespace ContactTrackingSystem.Data
{
    public class CTSDbContext:DbContext
    {
        //constructor

        public CTSDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().ToTable("Contacts");

            //Seed to Countries
            string ContactsJson = System.IO.File.ReadAllText("Contacts.json");
            List<Contact> contacts = System.Text.Json.JsonSerializer.Deserialize<List<Contact>>(ContactsJson);

            foreach(Contact contact in contacts)
                modelBuilder.Entity<Contact>().HasData(contact);

            //Seed to UserLoginTable
            string UserLoginsJson = System.IO.File.ReadAllText("Users.json");
            List<UserLogin> userLogins = System.Text.Json.JsonSerializer.Deserialize<List<UserLogin>>(UserLoginsJson);

            foreach (UserLogin user in userLogins)
                modelBuilder.Entity<UserLogin>().HasData(user); // "Username":"AdminUser@gmail.com","Password":"Test!234!!"
        }

    }

}
