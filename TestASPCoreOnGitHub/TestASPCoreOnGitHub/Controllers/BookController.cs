using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestASPCoreOnGitHub.Models;
using TestASPCoreOnGitHub.Repository;

namespace TestASPCoreOnGitHub.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public List<BookModel> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }


        public BookModel GetBook(int id)
        {
            return bookRepository.GetBookByID(id);
        }

        public List<BookModel> SearchOnBook(string bookName , string authorName)
        {

            return bookRepository.SearchBook(bookName, authorName);
        }
    }
}
