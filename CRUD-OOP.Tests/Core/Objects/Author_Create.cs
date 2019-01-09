using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects.Name;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.Objects
{
    public class Author_Create
    {
        [Fact]
        public void SetCorrectValue_Should_BeSet()
        {
            int idIndDb = 389;
            AuthorName name = new AuthorName(
                firstName: new OneWordName("Ak"),
                middleName: new OneWordName("Middlename"), 
                lastName: new OneWordName("Last"));

            Author author = Author.Create(idInDB: idIndDb, name: name);
            Assert.Equal(idIndDb, author.IdInDB);
            Assert.Equal(name, author.Name);
        }

    }
}
