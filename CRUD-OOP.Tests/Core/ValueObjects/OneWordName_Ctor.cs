using CRUD_OOP.Core.ValueObjects.Name;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.ValueObjects
{
    public class OneWordName_Ctor
    {
        [Theory]
        [InlineData("D")]
        [InlineData("Rosh")]
        [InlineData("Amazonicus")]
        public void CorrectName_Should_BeSet(string name)
        {
            OneWordName oneWordName = new OneWordName(name);

            Assert.Equal(name, oneWordName.Value);
        }

       [Fact]
       public void EmptyName_Should_ThrowException()
       {
            void action() => new OneWordName(string.Empty);
            Assert.Throws<ArgumentException>((Action)action);
       }

        [Fact]
        public void NullName_Should_ThrowException()
        {
            void action() => new OneWordName(null);
            Assert.Throws<ArgumentException>((Action)action);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("Ab$5")]
        [InlineData("Roma?")]
        [InlineData("__BB")]
        [InlineData("   ")]
        [InlineData("--")]
        [InlineData("++")]
        [InlineData("MorkAdAba")]
        public void NameConsistNonLetters_Should_ThrowException(string name)
        {
            void action() => new OneWordName(name);
            Assert.Throws<ArgumentException>((Action)action);
        }

    }
}
