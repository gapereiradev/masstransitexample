﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Customer.Dtos
{
    public class UpdateBirthDateDto
    {
        [Required(ErrorMessage = "Must provide a valid customer id.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Must provide a valid birthdate.")]
        public DateTime NewBirthDate { get; set; }
    }
}