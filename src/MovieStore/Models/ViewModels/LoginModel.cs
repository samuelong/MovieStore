using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required] //Ensures that values are provided
        public string Name { get; set; }

        [Required]
        [UIHint("password")] //Text will be hashed (for confidentiality purposes)
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
