using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = MyUtils.GetFiltered(new[] { new Book("HP", "Rowling", 400),
                new Book("Evgeniy Onegin", "Pushkin", 300),
                new Book("Lord of the rings", "Tolkien", 600) },
                b => b.PageCount > 300);
            foreach (var b in books)
                Console.WriteLine(b.Title);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int pageCount)
        {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }
    }

    public class Library : IEnumerable<Book>
    {
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; set; } = (b) => true;

        public Library(IEnumerable<Book> books)
        {
            Books = books;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new MyEnumerator(Books, Filter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MyEnumerator : IEnumerator<Book>
    {
        List<Book> books;
        Predicate<Book> filter;
        int position = -1;

        public MyEnumerator(IEnumerable<Book> books, Predicate<Book> filter)
        {
            this.books = books.ToList();
            this.filter = filter;
        }

        public bool MoveNext()
        {
            do
            {
                position++;
            }
            while (position < books.Count && !filter(Current));


            return position < books.Count;
        }

        public Book Current
        {
            get
            {
                if (position == -1 || position >= books.Count)
                    throw new InvalidOperationException();
                else
                    return books[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }
    }

    public class MyUtils
    {
        public static List<Book> GetFiltered(IEnumerable<Book> books, Predicate<Book> filter)
        {
            return new Library(books) { Filter = filter }.ToList();
        }
    }
}
