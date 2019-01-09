using CRUD_OOP.Core.ValueObjects;
using CRUD_OOP.Core.ValueObjects.Name;
using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.Objects
{
    public class Book : Entity<Guid>
    {
        public int? IdInDb { get; private set; }
        public IName BookName { get; private set; }
        public Author Author { get; private set; }
        public DateTimeOffset PublishedDate { get; private set; }
        public BookPagesValue Pages { get; private set; }

        private Book(Guid id, int? idInDb, BookName bookName, Author author, DateTimeOffset publishedDate, BookPagesValue pages) : base(id: id)
        {
            this.IdInDb = idInDb;
            this.BookName = bookName;
            this.Author = author;
            this.PublishedDate = publishedDate;
            this.Pages = pages;
        }

        public static Book Create(int? idInDb, BookName bookName, Author author, DateTimeOffset publishedDate, BookPagesValue pages)
        {
            return new Book(
                id: Guid.NewGuid(),
                idInDb: idInDb,
                bookName: bookName,
                author: author,
                publishedDate: publishedDate,
                pages: pages);
        }
    }
}
