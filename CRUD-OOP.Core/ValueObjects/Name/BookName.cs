using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.ValueObjects.Name
{
    public class BookName : ValueObject<BookName>, IName
    {
        public BookName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException("BookName name cannot be null or empty.");

            this.Name = name;
        }

        public string Name { get; private set; }

        public string GetFullName()
        {
            return Name;
        }
    }

}
