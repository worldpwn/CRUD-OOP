using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Data.Models
{
    public class BookModel : Model
    {
        public string Name { get; set; }
        public int AuthorId { get;set; }
        public DateTimeOffset DateTime { get; set; }
        public int Pages { get; set; }
    }
}
