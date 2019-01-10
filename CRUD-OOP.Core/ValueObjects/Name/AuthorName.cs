using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_OOP.Core.ValueObjects.Name
{
    public class AuthorName : ValueObject<AuthorName>, IName
    {
        public AuthorName(string firstName, string middleName, string lastName)
        {
            GuardValidateName(firstName: firstName, middleName: middleName, lastName: lastName);

            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }

        public string GetFullName()
        {
            if (MiddleName == null)
            {
                return $"{FirstName} {LastName}";
            }
            return $"{FirstName} {MiddleName} {LastName}";
        }

        private void GuardValidateName(string firstName, string middleName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName)) throw new ArgumentException("First Name cannot be null or empty.");
            if (String.IsNullOrEmpty(lastName)) throw new ArgumentException("Last Name cannot be null or empty.");
            if (middleName == string.Empty) throw new ArgumentException("Middle Name cannot be empty.");

            // First Name
            if (!Check_OnlyLetters(firstName)) throw new ArgumentException("Only letters allowed in First Name.");
            if (!Check_OnlyFirstIsUpper(firstName)) throw new ArgumentException("First Name should start from Capital letter.");

            // Last Name
            if (!Check_OnlyLetters(lastName)) throw new ArgumentException("Only letters allowed in Last Name.");
            if (!Check_OnlyFirstIsUpper(lastName)) throw new ArgumentException("Last Name should start from Capital letter.");

            // Middle Name
            if (middleName!= null)
            {
                if (!Check_OnlyFirstIsUpper(middleName)) throw new ArgumentException("Middle Name Should start from Capital letter.");
                if (!Check_OnlyLetters(middleName)) throw new ArgumentException("Only letters allowed in Middle Name.");
            }
 

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
