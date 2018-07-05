using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DITest.Model.Models
{
    public class AppUser
    {
        [MaxLength(128)]
        [Key]
        public string Id { set; get; }

        [MaxLength(256)]
        public string FullName { set; get; }

        [Required]
        [MaxLength(50)]
        public string UserName { set; get; }

        public bool? Gender { set; get; }

        [MaxLength(100)]
        public string Email { set; get; }

        public bool EmailConfirm { set; get; }
        public string PasswordHash { set; get; }
        public string Phone { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }
        public bool? Status { set; get; }

        public virtual IEnumerable<Order> Orders { set; get; }
    }
}