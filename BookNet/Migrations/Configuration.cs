namespace BookNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookNet.Models.BookStoreModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookNet.Models.BookStoreModel context)
        {
            context.Authors.RemoveRange(context.Authors.ToList());
            context.Books.RemoveRange(context.Books.ToList());
            context.Customers.RemoveRange(context.Customers.ToList());
            context.SaveChanges();
            
            context.Authors.AddOrUpdate(
                new Models.Author
                {
                    ID = 0,
                    FirstName = "DONNA",
                    LastName = "LEON",
                    Age = 74,
                    Image = "Donna_Leon.jpg",
                    Specialty = Models.Genre.ScienceFiction
                },
                new Models.Author
                {
                    ID = 1,
                    FirstName = "NICHOLAS",
                    LastName = "SPARKS",
                    Age = 50,
                    Image = "Sparks_Nicholas.jpg",
                    Specialty = Models.Genre.ScienceFiction
                },
                new Models.Author
                {
                    ID = 2,
                    FirstName = "JEFFREY",
                    LastName = "ARCHER",
                    Age = 76,
                    Image = "Jeffrey_Archer.jpg",
                    Specialty = Models.Genre.History
                },
                new Models.Author
                {
                    ID = 3,
                    FirstName = "VICTORIA",
                    LastName = "HISLOP",
                    Age = 57,
                    Image = "HISLOP_VICTORIA.jpg",
                    Specialty = Models.Genre.Comedy
                });
  
            context.Books.AddOrUpdate(
                new Models.Book
                {
                    ID = 0,
                    AuthorID = 0,
                    Title = "BEASTLY THINGS",
                    Description = "When a body is found floating in a canal, strangely disfigured and with multiple stab wounds, Commissario Brunetti is called to investigate and is convinced he recognises the man from somewhere.",
                    Genre = Models.Genre.Action,
                    Image = "BEASTLY_THINGS.jpg",
                    Price = 62
                },
                 new Models.Book
                 {
                     ID = 1,
                     AuthorID = 0,
                     Title = "GOLDEN EGG",
                     Description = "Unkonwn",
                     Genre = Models.Genre.ScienceFiction,
                     Image = "unknown.jpg",
                     Price = 108
                 },
                  new Models.Book
                  {
                      ID = 2,
                      AuthorID = 0,
                      Title = "JEWELS OF PARADISE",
                      Description = "From the bestselling author of the Brunetti crime series comes The Jewels of Paradise, a gripping tale of intrigue, music, history and greed and Donna Leon's first stand-alone novel",
                      Genre = Models.Genre.Comedy,
                      Image = "JEWELS_OF_PARADISE.jpg",
                      Price = 55
                  },
                   new Models.Book
                  {
                      ID = 3,
                      AuthorID = 2,
                      Title = "SINS OF THE FATHER",
                      Description = "The master storyteller continues the Clifton saga with this, the second volume. New York, 1939. Tom Bradshaw is arrested for first degree murder. He stands accused of killing his brother.",
                      Genre = Models.Genre.ScienceFiction,
                      Image = "Sins_of_father.jpg",
                      Price = 55
                  });
            context.Customers.AddOrUpdate(
                 new Models.Customer
                 {
                     FirstName = "chen",
                     LastName = "goren",
                     BirthDate = new DateTime(1994, 11, 15),
                     City = "qiryat ono",
                     CreationDate = DateTime.Today,
                     Email = "chen@goren.com",
                     PhoneNumber = "052-5145452",
                     Street = "havazelet 8",
                     ID = 202551515
                 },
               new Models.Customer
               {
                   FirstName = "bar",
                   LastName = "mey",
                   BirthDate = new DateTime(1985, 12, 15),
                   City = "qiryat ono",
                   CreationDate = DateTime.Today,
                   Email = "bar@mey.com",
                   PhoneNumber = "054-5145616",
                   Street = "shlomo hamelech 25",
                   ID = 313589515
               });
        }
    }
}
