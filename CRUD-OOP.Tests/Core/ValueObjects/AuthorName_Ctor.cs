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
                firstName: firstName,
                middleName: middleName,
                lastName: lastName);

            Assert.Equal(firstName, authorName.FirstName);
            Assert.Equal(middleName, authorName.MiddleName);
            Assert.Equal(lastName, authorName.LastName);
        }

        [Fact]
        public void MiddleNameIsNull_Should_BeOk()
        {
            string firstName = "Don";
            string lastName = "Lastname";

            AuthorName authorName = new AuthorName(
                firstName: firstName,
                middleName: null,
                lastName: lastName);

            Assert.Equal(firstName, authorName.FirstName);
            Assert.Null(authorName.MiddleName);
            Assert.Equal(lastName, authorName.LastName);
        }

        [Fact]
        public void FirstNameIsNull_Should_throwArgumentExceptopn()
       {
            void action ()=> new AuthorName(
                firstName: null,
                middleName: "Asd",
                lastName: "Tsd");

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void FirstNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: string.Empty,
                middleName: "Asd",
                lastName: "Tsd");

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void MiddleNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: "A",
                middleName: string.Empty,
                lastName: "Tsd");

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void LastNameIsEmpty_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: "A",
                middleName: null,
                lastName: string.Empty);

            Assert.Throws<ArgumentException>((Action)action);
        }

        [Fact]
        public void LastNameIsNull_Should_throwArgumentExceptopn()
        {
            void action() => new AuthorName(
                firstName: "A",
                middleName: null,
                lastName: null);

            Assert.Throws<ArgumentException>((Action)action);
        }
    }
}
