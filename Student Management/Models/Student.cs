using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class Student
    {
        [Key]
        public int Studentid { get; set; }
        [Required]
        public string? StudentName { get; set; }

        public int StudentAge { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
