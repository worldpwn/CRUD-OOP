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
                firstName: "Gustave",
                middleName: null,
                lastName: "Flaubert");

            Assert.Equal(fullName, authorName.GetFullName());
        }

        [Fact]
        public void FirstMiddleAndLastName_Should_ReturnFirstMidlleAndLastMameSeparatedBySpaces()
        {
            string fullName = "Francis Scott Fitzgerald";

            IName authorName = new AuthorName(
                firstName: "Francis",
                middleName: "Scott",
                lastName: "Fitzgerald");

            Assert.Equal(fullName, authorName.GetFullName());
        }

    }
}
