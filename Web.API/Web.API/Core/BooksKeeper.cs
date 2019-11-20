using System.Collections.Generic;
using System.Linq;
using Web.API.Models;

namespace Web.API.Core
{
    public class BooksKeeper
    {
        private static volatile BooksKeeper _instance;
        private static readonly object InstanceLock = new object();

        private readonly List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "Стивен Кинг",
                Title = "Сияние"
            },
            new Book
            {
                Id = 2,
                Author = "Александр Пушкин",
                Title = "Пиковая дама"
            },
            new Book
            {
                Id = 3,
                Author = "Джоан Роулинг",
                Title = "Гарри Поттер и Философский камень"
            },
        };

        private BooksKeeper() { }

        public static BooksKeeper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new BooksKeeper();
                        }
                    }
                }

                return _instance;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = _books.First(x => x.Id == id);

            _books.Remove(book);
        }

        public Book GetBook(int id)
        {
            return _books.First(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }
    }
}
