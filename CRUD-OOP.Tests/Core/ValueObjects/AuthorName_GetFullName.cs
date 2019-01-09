using CRUD_OOP.Core.ValueObjects.Name;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.ValueObjects
{
    public class AuthorName_GetFullName
    {
        [Fact]
        public void NameWithFirstAndLastName_Should_ReturnFirstAndLastMameSeparatedBySpace()
        {
            string fullName = "Gustave Flaubert";

            IName authorName = new AuthorName(
                firstName: new OneWordName("Gustave"),
                middleName: null,
                lastName: new OneWordName("Flaubert"));

            Assert.Equal(fullName, authorName.GetFullName());
        }

        [Fact]
        public void FirstMiddleAndLastName_Should_ReturnFirstMidlleAndLastMameSeparatedBySpaces()
        {
            string fullName = "Francis Scott Fitzgerald";

            IName authorName = new AuthorName(
                firstName: new OneWordName("Francis"),
                middleName: new OneWordName("Scott"),
                lastName: new OneWordName("Fitzgerald"));

            Assert.Equal(fullName, authorName.GetFullName());
        }

    }
}
