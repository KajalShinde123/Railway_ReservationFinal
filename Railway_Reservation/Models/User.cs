using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Railway_Reservation.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int User_Id { get; set; }
        public string FirstName { get; set;}

        public string LastName { get; set;}
        public string Gender { get; set;}
        public string Phone { get; set;}
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]

        public string Email { get; set;}
        [Required(ErrorMessage ="Password is required...")]
       
        public string Password { get; set;}
        
        public string Role { get; set;}
    }
}