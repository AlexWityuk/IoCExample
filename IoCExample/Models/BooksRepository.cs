using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IoCExample.Models
{
    public class BooksRepository: IRepository, IDisposable
    {
        private BooksModel db;

        public BooksModel Db
        {
            get { return db; }
            set { db = value; }
        }

        public BooksRepository(BooksModel db)
        {
            this.db = db;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            this.Save();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            this.Save();
        }

        public void Edit(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            this.Save();
        }

        public Book Get(int? id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> List()
        {
            return db.Books.ToList();
        }

        public void Save()
        {
            
            db.SaveChanges();
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}