using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace idscan.Models
{
    public class ContactContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   
           
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User() { Id = 1, Login ="mino", Password = "123"});
        //    modelBuilder.Entity<Contact>().HasData(
        //        new Contact() { Id = 1, Name = "Артур", Password = "123" });
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User {Id=1, Login = "mino", Password = "123"},
                    new User {Id=2,Login = "ivan", Password = "123"},
                });
                modelBuilder.Entity<Contact>().HasData(new Contact[]
                {
                        new Contact(){Id=1, Name = "Artur",Phone = "89513456356", UserId = 1},
                        new Contact(){Id=2, Name = "Yurii",Phone = "89564784765", UserId = 2}
                });
        }
    }
}
