using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects.Name;
using CRUD_OOP.Data.Models;
using CRUD_OOP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD_OOP.Tests.Core.Objects
{
    public class Author_SaveOrUpdateInDB
    {
        private Repository<AuthorModel> _repository;
        public Author_SaveOrUpdateInDB()
        {
            _repository = new Repository<AuthorModel>();
        }

        [Fact]
        public void AuthorAlreadyHaveIdInDB_Should_BeUpdated()
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


            AuthorName newName = new AuthorName(
                firstName: new OneWordName("Ak"),
                middleName: new OneWordName("Middlename"), 
                lastName: new OneWordName("Last"));

            Author author = Author.Create(idInDB: id, name: newName);

            author.SaveOrUpdateInDB(_repository);
            
            Assert.Equal(model.Id, author.IdInDB);
            Assert.Equal(newName.FirstName, author.Name.FirstName);
            Assert.Equal(newName.MiddleName, author.Name.MiddleName);
            Assert.Equal(newName.LastName, author.Name.LastName);

            var mdodelFromDb = _repository.Get(id);

            Assert.Equal(newName.FirstName.Value, mdodelFromDb.FirstName);
            Assert.Equal(newName.MiddleName.Value, mdodelFromDb.MiddleName);
            Assert.Equal(newName.LastName.Value, mdodelFromDb.LastName);
        }

        [Fact]
        public void AuthorDoesntExistInDB_Should_BeUpdated()
        {

            AuthorName name = new AuthorName(
                firstName: new OneWordName("Ak"),
                middleName: new OneWordName("Middlename"),
                lastName: new OneWordName("Last"));

            Author author = Author.Create(idInDB: null, name: name);

            author.SaveOrUpdateInDB(_repository);


            var mdodelFromDb = _repository.Get(author.IdInDB ?? default);

            Assert.Equal(name.FirstName.Value, mdodelFromDb.FirstName);
            Assert.Equal(name.MiddleName.Value, mdodelFromDb.MiddleName);
            Assert.Equal(name.LastName.Value, mdodelFromDb.LastName);
        }

    }
}
