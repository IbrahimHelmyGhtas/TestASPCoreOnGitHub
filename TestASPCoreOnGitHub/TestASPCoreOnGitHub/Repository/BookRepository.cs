using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPCoreOnGitHub.Models;

namespace TestASPCoreOnGitHub.Repository
{
    public class BookRepository
    {

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }


        public BookModel GetBookByID(int id)
        {
            return DataSource().Where(J => J.id == id).SingleOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(J => J.Title.Contains(title) || J.Author.Contains( authorName)).ToList();
        }



        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {

                new BookModel (){id=1,Title="MVCBook",Author="Ibrahim" },
                   new BookModel (){id=2,Title="C#",Author="Ahmed" },
                      new BookModel (){id=3,Title="Java",Author="Hamdy" },
                         new BookModel (){id=4,Title="HTML",Author="Ali" }

            };

        }


    }
}
