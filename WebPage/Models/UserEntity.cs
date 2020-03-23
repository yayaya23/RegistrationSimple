using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPage.Models
{
    [Table("Tbl_User")]
    public class UserEntity
    {
        [Key]
        public Int64 UserId { get; set; }
        [MaxLength(100), Required]
        public string Email { get; set; }
        [MaxLength(15), Required]
        public string MobileNumber { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
    }
}