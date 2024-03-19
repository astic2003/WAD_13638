using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _13638_WEBAPI.Models
{
    public class Student
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "MiddleName is required")]
        public string? MiddleName { get; set; }

        // Nullable foreign key
        public int? GradeID { get; set; }

        // Navigation property
        [ForeignKey("GradeID")]
        public Grade? Grade { get; set; }
    }
}
