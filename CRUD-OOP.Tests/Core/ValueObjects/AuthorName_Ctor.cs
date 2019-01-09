using CRUD_OOP.Core.ValueObjects.Name;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.ValueObjects
{
    public class AuthorName_Ctor
    {
        [Theory]
        [InlineData("B", "Horsman", "Tzarev")]
        [InlineData("Peter", "Lala", "S")]
        public void SetCorrectName_Should_BeSet(string firstName, string middleName, string lastName)
        {
            AuthorName authorName = new AuthorName(
                firstName: new OneWordName(firstName),
                middleName: new OneWordName(middleName),
                lastName: new OneWordName(lastName));

            Assert.Equal(firstName, authorName.FirstName.Value);
            Assert.Equal(middleName, authorName.MiddleName.Value);
            Assert.Equal(lastName, authorName.LastName.Value);
        }

        [Fact]
        public void MiddleNameIsNull_Should_BeOk()
        {
            string firstName = "Don";
            string lastName = "Lastname";

            AuthorName authorName = new AuthorName(
                firstName: new OneWordName(firstName),
                middleName: null,
                lastName: new OneWordName(lastName));

            Assert.Equal(firstName, authorName.FirstName.Value);
            Assert.Null(authorName.MiddleName);
            Assert.Equal(lastName, authorName.LastName.Value);
        }

        [Fact]
        public void FirstNameIsNull_Should_throwArgumentExceptopn()
       {
            void action ()=> new AuthorName(
                firstName: null,
                middleName: new OneWordName("Asd"),
                lastName: new OneWordName("Tsd"));

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void FirstNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: new OneWordName(string.Empty),
                middleName: new OneWordName("Asd"),
                lastName: new OneWordName("Tsd"));

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void MiddleNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: new OneWordName("A"),
                middleName: new OneWordName(string.Empty),
                lastName: new OneWordName("Tsd"));

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void LastNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: new OneWordName("A"),
                middleName: null,
                lastName: new OneWordName(string.Empty));

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void LastNameIsNull_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: new OneWordName("A"),
                middleName: null,
                lastName: null);

            Assert.Throws<ArgumentException>((Action)action);
        }
    }
}
