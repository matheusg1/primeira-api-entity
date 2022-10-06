using ApiMatheusGomes.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMatheusGomes.Repositories
{
    public class BookRepository : IBookRepository
    {
        Task<Book> IBookRepository.Create(Book book)
        {
            throw new System.NotImplementedException();
        }

        Task IBookRepository.Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Book>> IBookRepository.Get()
        {
            throw new System.NotImplementedException();
        }

        Task<Book> IBookRepository.Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task IBookRepository.Update(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
