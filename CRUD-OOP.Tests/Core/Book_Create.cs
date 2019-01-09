using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core
{
    public class Book_Create
    {
        [Theory]
        [InlineData(2, "War and Peace", "L.Tolstoy", 1000, "121212")]
        [InlineData(2, "Some Name", "Vvv Pupkin", 1000, "121212")]
        [InlineData(2, "Rose", "Flober", 1000, "121212")]
        public void SetCorrectDataWithIdInDB_Should_CreateObjectWitCorrectData(
            int? idInDb, 
            string bookName, 
            string author, 
            int pages, 
            string ISBN)
        {
            DateTimeOffset publishedDate = DateTimeOffset.UtcNow;
            Book book = Book.Create(
                idInDb: idInDb,
                bookName: bookName,
                author: author,
                publishedDate: publishedDate,
                pages: new BookPagesValue(numberOfPages: pages),
                ISBN: ISBN);

            Assert.Equal(book.IdInDb, idInDb);
            Assert.Equal(book.BookName, bookName);
            Assert.Equal(book.Author, author);
            Assert.Equal(book.PublishedDate, publishedDate);
            Assert.Equal(book.Pages, new BookPagesValue(numberOfPages: pages));
            Assert.Equal(book.ISBN, ISBN);
        }

    }
}
