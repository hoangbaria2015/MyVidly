using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerDto =validationContext.ObjectInstance as CustomerDto;
            if (customerDto != null)
            {
                if (customerDto.MembershipTypeId == MembershipType.Unknown || customerDto.MembershipTypeId == MembershipType.PayAsYouGo)
                    return ValidationResult.Success;
                if (customerDto.Birthdate == null)
                    return new ValidationResult("Birthday is required!");
                var age = DateTime.Today.Year - customerDto.Birthdate.Value.Year;
                return (age > 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old to go on a membership");
            }
            else
            {
                var customer = validationContext.ObjectInstance as Customer;
                if (customer != null)
                {
                    if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                        return ValidationResult.Success;
                    if (customer.Birthdate == null)
                        return new ValidationResult("Birthday is required!");
                    var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                    return (age > 18)
                        ? ValidationResult.Success
                        : new ValidationResult("Customer should be at least 18 years old to go on a membership");
                }
            }
            return new ValidationResult("Something has got wrong!!");
        }
    }
}