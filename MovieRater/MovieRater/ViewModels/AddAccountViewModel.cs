using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewModels
{
    public class AddAccountViewModel
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "Gebruikers naam")]
        public string UserName { get; set; }
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefoonnummer")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
    }
}
