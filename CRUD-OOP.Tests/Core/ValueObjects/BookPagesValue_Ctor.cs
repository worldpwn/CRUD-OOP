using CRUD_OOP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.ValueObjects
{
    public class BookPagesValue_Ctor
    {
        [Theory]
        [InlineData(1)]
        [InlineData(23)]
        [InlineData(999)]
        public void SetCorrectNumberOfPages_Should_BeSet(int numberOfPages)
        {
            BookPagesValue bookPagesValue = new BookPagesValue(numberOfPages: numberOfPages);

            Assert.Equal(numberOfPages, bookPagesValue.NumberOfPages);
        } 

        [Fact]
        public void SetNumberOfPagesToZero_Should_ThrowException()
        {
            void action() => new BookPagesValue(numberOfPages: 0);
            Assert.Throws<ArgumentException>((Action)action);
        }
    }
}
