using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DyITELEC1C.Models
{   public enum Rank
    {
        Instructor, AssistProf, Prof
    }
    
    public enum IsTenured
    {
        Probationary, Permanent
    }
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Input The Correct Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date Hired is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set;}
        [Required(ErrorMessage = "Rank is Required")]
        [Display(Name = "Rank")]
        public Rank Rank { get; set;}
        [Required(ErrorMessage = "Tenure is Required")]
        [Display(Name = "Is Tenured")]
        public IsTenured IsTenured { get; set;}

        [Phone]
        [Display(Name = "Phone")]
        [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the " +
            "Format 00-000-0000")]
        public string? Phone { get; set; }

        [NotMapped]
        public IFormFile? UploadedPhoto { get; set; }

        [Display(Name = "Profile Picture")]
        public string? imagePath {  get; set; }
    }
}
