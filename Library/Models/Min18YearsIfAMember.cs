using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old");
        }
    }
}