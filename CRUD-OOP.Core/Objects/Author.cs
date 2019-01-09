using CRUD_OOP.Core.ValueObjects.Name;
using CRUD_OOP.Data.Models;
using CRUD_OOP.Data.Repository;
using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.Objects
{
    public class Author : Entity<Guid>
    {
        public int? IdInDB { get; private set; }
        public AuthorName Name { get; private set; }

        private Author(Guid id, int? idInDB, AuthorName name): base(id: id)
        {
            this.IdInDB = idInDB;
            this.Name = name;
        }

        public static Author Create(int? idInDB, AuthorName name)
        {
            return new Author(
                id: Guid.NewGuid(),
                idInDB: idInDB,
                name: name);
        }

        public static Author GetFromDb(int id, Repository<AuthorModel> repository)
        {
            var model = repository.Get(id);

            AuthorName authorName = new AuthorName(
                firstName: new OneWordName(model.FirstName),
                middleName: model.MiddleName == null ? null : new OneWordName(model.MiddleName),
                lastName: new OneWordName(model.LastName));

            return Create(
                idInDB: id,
                name: authorName);
        }

        public void SaveOrUpdateInDB(Repository<AuthorModel> repository)
        {
            if (this.IdInDB != null)
            {
                UpdateInDB(repository);
            }
            else
            {
                CreateInDB(repository);
            }
        }

        private void UpdateInDB(Repository<AuthorModel> repository)
        {
            var fromDBModel = repository.Get(this.IdInDB ?? default);

            fromDBModel.FirstName = this.Name.FirstName.Value;
            fromDBModel.LastName = this.Name.LastName.Value;
            fromDBModel.MiddleName = this.Name.MiddleName.Value;
        }

        private void CreateInDB(Repository<AuthorModel> repository)
        {
            this.IdInDB = repository.CreateId();
            AuthorModel authorModel = new AuthorModel()
            {
                Id = this.IdInDB ?? default,
                FirstName = this.Name.FirstName.Value,
                LastName = this.Name.LastName.Value,
                MiddleName = this.Name.MiddleName.Value,
            };

            repository.Add(authorModel);
        }

    }
}
