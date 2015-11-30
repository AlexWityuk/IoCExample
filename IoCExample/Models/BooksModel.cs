namespace IoCExample.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BooksModel : DbContext
    {
        // Your context has been configured to use a 'BooksModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IoCExample.Models.BooksModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BooksModel' 
        // connection string in the application configuration file.
        public BooksModel()
            : base("name=BooksModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Book> Books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public short Year { get; set; }
    }
}