using CRUD_OOP.Core.Objects;
using CRUD_OOP.Data.Models;
using CRUD_OOP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.Objects
{
    public class Author_GetFromDb
    {
        private Repository<AuthorModel> _repository;
        public Author_GetFromDb()
        {
            _repository = new Repository<AuthorModel>();
        }

        [Fact]
        public void ModelInDB_Should_CreateCorrectObject()
        {
            int id = 33;

            var model = new AuthorModel()
            {
                Id = id,
                FirstName = "Jhon",
                MiddleName = "Smuel",
                LastName = "Azab"
            };

            _repository.Add(model);

            Author author = Author.GetFromDb(id, _repository);

            Assert.Equal(model.Id, author.IdInDB);
            Assert.Equal(model.FirstName, author.Name.FirstName);
            Assert.Equal(model.MiddleName, author.Name.MiddleName);
            Assert.Equal(model.LastName, author.Name.LastName);
        }
    }
}
