using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }
        public double Test_Score { get; set; }
    }
}