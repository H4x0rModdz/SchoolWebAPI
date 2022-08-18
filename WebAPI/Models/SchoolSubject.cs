using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Test_Score { get; set; }
        [JsonIgnore]
        public Student Student { get; set; } // 1 student

    }
}
