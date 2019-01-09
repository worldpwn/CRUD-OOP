using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.ValueObjects
{
    public class BookPagesValue: ValueObject<BookPagesValue>
    {
        public BookPagesValue(int numberOfPages)
        {
            if (numberOfPages == 0) throw new ArgumentException("BookPagesValue cannot be zero.");
            this.NumberOfPages = numberOfPages;
        }

        public int NumberOfPages { get; private set; }
    }
}
