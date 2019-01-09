using CRUD_OOP.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.ValueObjects.Name
{
    public class OneWordName
    {
        public OneWordName(string name, string keyForModelState = null)
        {
            try
            {
                GuardValidateName(name);
            }
            catch(Exception e) when (e is ArgumentException)
            {
                throw new ModelValidationException(keyForModelState, e.Message);
            }

       
            this.Value = name;
        }

        public string Value { get; private set; }

        private void GuardValidateName(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty.");
            if (!Check_OnlyLetters(name)) throw new ArgumentException("Only letters allowed in names.");
            if (!Check_OnlyFirstIsUpper(name)) throw new ArgumentException("Shoud start from Capital letter and others are small.");

        }

        private bool Check_OnlyLetters(string name)
        {
            foreach (var character in name)
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Check_OnlyFirstIsUpper(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0)
                {
                    if (!char.IsUpper(name[i]))
                    {
                        return false;
                    }

                }
                else
                {
                    if (!char.IsLower(name[i]))
                    {
                        return false;
                    }

                }
            }
            foreach (var character in name)
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
