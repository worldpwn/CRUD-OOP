using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects;
using CRUD_OOP.Core.ValueObjects.Name;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.Objects
{
    public class Book_Create
    {
        [Theory]
        [InlineData(2, "War and Peace", "L", "Tolstoy", 1000)]
        [InlineData(2, "Some Name", "Viktor", "Churbin", 1000)]
        [InlineData(2, "Rose", "Wow","Authro", 1000)]
        public void SetCorrectDataWithIdInDB_Should_CreateObjectWitCorrectData(
            int? idInDb, 
            string bookName, 
            string authorFirstName,
            string authorLastName,
            int pages)
        {
            DateTimeOffset publishedDate = DateTimeOffset.UtcNow;

            Author author = Author.Create(null, new AuthorName(firstName: authorFirstName, middleName: null, lastName: authorLastName));

            Book book = Book.Create(
                idInDb: idInDb,
                bookName: new BookName(bookName),
                author: author,
                publishedDate: publishedDate,
                pages: new BookPagesValue(numberOfPages: pages));

            Assert.Equal(idInDb, book.IdInDb);
            Assert.Equal(new BookName(bookName), book.BookName);
            Assert.Equal(author, book.Author);
            Assert.Equal(publishedDate, book.PublishedDate);
            Assert.Equal(new BookPagesValue(numberOfPages: pages), book.Pages);
        }

    }
}
