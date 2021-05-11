using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Test.Backend.Domain.Models;

namespace Test.Backend.Domain.Extentions
{
    public static class ValidatorsExtension
    {
        public static IEnumerable<string> Validate(this Customer customer)
        {
            var erros = new List<string>();

            if (customer.Name.Length < 3)
            {
                erros.Add("Customer name can't length under 3 characters.");
            }

            if (!customer.Name.FullNameIsValid())
            {
                erros.Add("Customer need it full name.");
            }

            if (customer.Age < 18)
            {
                erros.Add("Customer can't age under 18.");
            }

            return erros;
        }

        public static bool FullNameIsValid(this string name)
        {
            name = name.OnlyLettersAndSpace();

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            
            var validator = name.Split(' ');
            if (validator.Length < 2)
            {
                return false;
            }

            return true;
        }

    }
}
