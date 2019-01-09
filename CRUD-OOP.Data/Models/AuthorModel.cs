using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Data.Models
{
    public class AuthorModel : Model
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
