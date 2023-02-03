using System.Globalization;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IAppDbContext _context;

        public StudentRepository(IAppDbContext context)
        {
            _context = context;
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var student = GetById(id);

            if (student == null)
                throw new ArgumentException("Student Not Found");

            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void Edit(Student student)
        {
            var studentFound = GetById(student.Id);

            studentFound.Address = student.Address;
            studentFound.AddedIn = student.AddedIn;
            studentFound.BirthDate = student.BirthDate;
            studentFound.CPF = student.CPF;
            studentFound.educationLevel = student.educationLevel;
            studentFound.Email = student.Email;
            studentFound.LastName = student.LastName;
            studentFound.Login = student.Login;
            studentFound.Password = student.Password;
            studentFound.PhoneNumber = student.PhoneNumber;
            studentFound.Subjects = student.Subjects;

            _context.Students.Update(studentFound);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(Guid id)
        {
            return _context.Students.Find(id);
        }

        public bool VerifyIfCpfAlreadyExists(Student student)
        {
            return _context.Students.Any(s => s.CPF == student.CPF && s.Id != student.Id);
        }

        public bool VerifyIfEmailAlreadyExists(Student student)
        {
            return _context.Students.Any(s => s.Email == student.Email && s.Id != student.Id);
        }

        public bool VerifyIfStudentAlreadyExists(Guid id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
        public void FilterSubjects(Student student)
        {
            if (student.Subjects != null)
            {
                student.Subjects = student.Subjects
                    .Where(subject => !string.IsNullOrEmpty(subject.Name) && subject.Id != 0)
                    .ToList();
            }
        }
    }
}