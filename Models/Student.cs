using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DyITELEC1C.Models
{   public enum Course
    {
        BSIT, BSCS, BSIS
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Course is Required")]
        [Display(Name = "Course")]
        public Course Course { get; set; }
        [Required(ErrorMessage = "Admission Date is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }
        [EmailAddress(ErrorMessage = "Input The Correct Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone")]
        [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the " +
            "Format 00-000-0000")]
        public string? Phone { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[]? StudentProfilePhoto { get; set; }
    }
}