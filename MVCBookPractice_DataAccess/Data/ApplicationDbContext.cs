using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCBookPractice_Model.Models;

namespace MVCBookPractice_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GHOST\\SQLEXPRESS;Database=BookPractice;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pawn of Prophecy", ISBN = "123B4HC", Price = 15.99m },
                new Book { Id = 2, Title = "A Court of Thorns and Roses", ISBN = "7734JT1", Price = 35.99m }
            );

            var bookList = new Book[]
            {
                new Book { Id = 3, Title = "Bonded by Thorns", ISBN = "713GJK12", Price = 4.99m },
                new Book { Id = 4, Title = "Remarried Empress", ISBN = "123IYM", Price = 1.99m },
                new Book { Id = 5, Title = "Wilde Fae: Lord of Nightmare", ISBN = "947HD99", Price = 13.99m },
                new Book { Id = 6, Title = "His Darkest Craving", ISBN = "341HNB4", Price = 4.99m }
            };

            modelBuilder.Entity<Book>().HasData(bookList);
        }
    }
}
