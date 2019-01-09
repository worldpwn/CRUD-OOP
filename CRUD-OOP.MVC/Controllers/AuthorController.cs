using System;
using CRUD_OOP.Core.Objects;
using CRUD_OOP.Core.ValueObjects.Name;
using CRUD_OOP.Data.Models;
using CRUD_OOP.Data.Repository;
using CRUD_OOP.MVC.ViewModels;
using CRUD_OOP.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_OOP.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly Repository<AuthorModel> _repository;
        public AuthorController(Repository<AuthorModel> repository)
        {
            _repository = repository;
        }

        // GET: Author
        public ActionResult Index()
        {


            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel viewModel)
        {
            try
            {
                OneWordName firstName = new OneWordName(viewModel.FirstName, keyForModelState: nameof(viewModel.FirstName));

                OneWordName middleName = string.IsNullOrEmpty(viewModel.MiddleName) ? null : new OneWordName(viewModel.MiddleName, keyForModelState: nameof(viewModel.MiddleName));

                OneWordName lastName = new OneWordName(viewModel.LastName, keyForModelState: nameof(viewModel.LastName));

                var name = new AuthorName(
                    firstName: firstName,
                    middleName: middleName,
                    lastName: lastName);

                Author author = Author.Create(null, name);

                author.SaveOrUpdateInDB(_repository);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e) when (e is ModelValidationException asModelValidation)
            {               
                ModelState.AddModelError(asModelValidation.Key, e.Message);
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}