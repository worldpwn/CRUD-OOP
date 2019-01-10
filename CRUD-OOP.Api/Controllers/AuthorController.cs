using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects.Name;
using CRUD_OOP.Data.Models;
using CRUD_OOP.Data.Repository;
using CRUD_OOP.SharedKernel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_OOP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly Repository<AuthorModel> _repository;
        public AuthorController(Repository<AuthorModel> repository)
        {
            _repository = repository;
        }

        // GET: api/Authro
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Authro/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authro
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Authro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorViewModel viewModel)
        {
            string firstName = viewModel.FirstName;

            string middleName = viewModel.MiddleName;

            string lastName = viewModel.LastName;

            var name = new AuthorName(
                firstName: firstName,
                middleName: middleName,
                lastName: lastName);

            Author author = Author.Create(null, name);

            author.SaveOrUpdateInDB(_repository);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
