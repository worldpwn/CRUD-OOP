using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.SharedKernel.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string key, string message) : base(message)
        {
            this.Key = key;
        }

        public string Key { get; private set; }
    }
}
