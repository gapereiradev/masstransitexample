﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Customer.Dtos
{
    public class NewCustomerDto
    {
        [Required(ErrorMessage = "Customer name is mandatory"), MinLength(2), MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer birthdate is mandatory")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Customer type is mandatory")]
        public string Type { get; set; }
    }
}