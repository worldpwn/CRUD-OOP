using CRUD_OOP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.Objects
{
    public class Book : Entity<Guid>
    {
        public int? IdInDb { get; private set; }
        public string BookName { get; private set; }
        public string Author { get; private set; }
        public DateTimeOffset PublishedDate { get; private set; }
        public BookPagesValue Pages { get; private set; }
        public string ISBN { get; private set; }

        private Book(Guid id, int? idInDb, string bookName, string author, DateTimeOffset publishedDate, BookPagesValue pages, string ISBN) : base(id: id)
        {
            this.IdInDb = idInDb;
            this.BookName = bookName;
            this.Author = author;
            this.PublishedDate = publishedDate;
            this.Pages = pages;
            this.ISBN = ISBN;
        }

        public static Book Create(int? idInDb, string bookName, string author, DateTimeOffset publishedDate, BookPagesValue pages, string ISBN)
        {
            return new Book(
                id: Guid.NewGuid(),
                idInDb: idInDb,
                bookName: bookName,
                author: author,
                publishedDate: publishedDate,
                pages: pages,
                ISBN: ISBN);
        }
    }
}
