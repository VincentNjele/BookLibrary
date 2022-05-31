using BookWEBAPI.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DALL.Interfaces
{
    public interface IBookService
    {
        List<Books> GetAll();
        Books? Get(int id);

        void Delete(int id);
        void Update(int id, Books books);

        Books Add(Books books);
    }
}
