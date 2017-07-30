using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MovieStore.Models
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }

    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

    public class MovieModel
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
    }

    public class Cast
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }
}
