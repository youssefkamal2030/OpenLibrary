﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        
        public string? Name { get; set; }
       
        public string Type { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}