using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                    _Password = value;
                else
                    _Password = BCrypt.Net.BCrypt.HashPassword(value);
            }
        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string AddedIn { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime? addedInEdited
        {
            get { return DateTime.Parse(AddedIn, new CultureInfo("pt-BR")); }
        }
        [Required]
        public string BirthDate { get; set;}
        public DateTime? dateOfBirth
        {
            get { return DateTime.Parse(BirthDate, new CultureInfo("pt-BR")); }
        }
        [Required]
        public string educationLevel { get; set; }
        [Required]
        public string Grade { get; set; }
        public ICollection<SchoolSubject> Subjects { get; set; }
    }
}
