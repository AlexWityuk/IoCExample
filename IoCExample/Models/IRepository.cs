using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCExample.Models
{
    public interface IRepository
    {
        void Save();
        IEnumerable<Book> List();
        Book Get(int? id);
        void Create(Book book);
        void Edit(Book book);
        void Delete(int id);
    }
}
