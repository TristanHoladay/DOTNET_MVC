using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Custom_Attributes
{
    public class SchoolAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        private int _maxAge;

        public SchoolAgeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthdate = (DateTime)value;
            int age = DateTime.Now.Year - birthdate.Year;
            if (age >= _minAge || age <= _maxAge)
            {
                return ValidationResult.Success;
            }
            

            return ValidationResult.Success;
        }

        private object GetErrorMessage()
        {
            return $"Can't be younger than {_minAge} or older than {_maxAge}";
        }
    }
}
