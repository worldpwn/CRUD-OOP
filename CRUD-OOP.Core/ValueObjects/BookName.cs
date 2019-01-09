using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.ValueObjects
{
    public class BookName : ValueObject<BookName>
    {
        public BookName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException("BookName name cannot be null or empty.");

            this.Name = name;
        }
        public string Name { get; private set; }
    }

}
