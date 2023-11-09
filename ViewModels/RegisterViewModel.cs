using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace DyITELEC1C.ViewModels
{
    public class RegisterViewModel
    {
            [Display(Name ="User Name")]
            [Required(ErrorMessage ="Please Enter your UserName")]
            public string? UserName { get; set; }
            [Display(Name = "Password")]
            [Required(ErrorMessage = "Please Enter your Password")]
            public string? Password { get; set; }
            [Display(Name = "Password")]
            [Required(ErrorMessage = "Must Confirm Password")]
            public string? ConfirmPassword { get; set; }
            [Required(ErrorMessage = "Please enter Email")]
            [EmailAddress(ErrorMessage = "Input The Correct Email Format")]
            [Display(Name = "Email")]
            public string? Email { get; set; }
            [Required(ErrorMessage = "First Name is Required")]
            [Display(Name = "First Name")]
            public string? FirstName { get; set; }
            [Required(ErrorMessage = "Last Name is Required")]
            [Display(Name = "Last Name")]
            public string? LastName { get; set; }
            [Display(Name = "Phone")]
            [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the " +
            "Format 00-000-0000")]
            public string? Phone { get; set; }   
    }
}
