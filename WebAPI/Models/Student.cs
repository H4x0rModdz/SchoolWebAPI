using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;
using BCrypt.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        private string _password;

        [Required(ErrorMessage = "The Password field is required")]
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
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
        public string BirthDate { get; set; }

        public DateTime? dateOfBirth
        {
            get { return DateTime.Parse(BirthDate, new CultureInfo("pt-BR")); }
        }

        [Required(ErrorMessage = "The Education Level field is required")]
        public string educationLevel { get; set; }

        [Required(ErrorMessage = "The Grade field is required")]
        public string Grade { get; set; }

        [JsonProperty(Required = Required.Default)]
        public ICollection<SchoolSubject> Subjects { get; set; }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}