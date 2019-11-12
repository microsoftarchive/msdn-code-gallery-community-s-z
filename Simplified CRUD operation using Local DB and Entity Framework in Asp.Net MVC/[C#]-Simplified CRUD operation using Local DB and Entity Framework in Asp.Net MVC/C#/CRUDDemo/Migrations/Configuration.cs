namespace CRUDDemo.Migrations
{
    using CRUDDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDDemo.Models.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CRUDDemo.Models.BookDBContext";
        }

        protected override void Seed(CRUDDemo.Models.BookDBContext context)
        {
            context.BookLst.AddOrUpdate(p => p.Id, new BookModel
            {
                Id = 0,
                AuthorName = "Suryakant",
                BookName = "CRUD DEMO",
                PublishDate = new DateTime(2014, 09, 12)
            }, new BookModel
            {
                Id = 1,
                AuthorName = "John",
                BookName = "Digital Life",
                PublishDate = new DateTime(2013, 10, 23)
            });

        }
    }
}
