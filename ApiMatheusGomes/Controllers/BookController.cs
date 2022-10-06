using ApiMatheusGomes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiMatheusGomes.Controllers
{
    public class BookController
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //[HttpGet]

    }
}
