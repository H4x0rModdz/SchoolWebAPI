using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        public double Test_Score { get; set; }
        //public ICollection<Student> Students { get; set; }
    }
}