using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The FirstName field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The LastName field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Login field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "The Password field is required")]
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
        [Required(ErrorMessage = "The Email field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The CPF field is required")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "The Address field is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The PhoneNumber field is required")]
        public string PhoneNumber { get; set; }
        public string AddedIn { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime? addedInEdited
        {
            get { return DateTime.Parse(AddedIn, new CultureInfo("pt-BR")); }
        }
        [Required(ErrorMessage = "The BirthDate field is required")]
        public string BirthDate { get; set;}
        public DateTime? dateOfBirth
        {
            get { return DateTime.Parse(BirthDate, new CultureInfo("pt-BR")); }
        }
        [Required(ErrorMessage = "The Education Level field is required")]
        public string educationLevel { get; set; }
        [Required(ErrorMessage = "The Grade field is required")]
        public string Grade { get; set; }
        public ICollection<SchoolSubject> Subjects { get; set; }
    }
}