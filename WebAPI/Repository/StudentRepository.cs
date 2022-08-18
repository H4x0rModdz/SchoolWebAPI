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

            studentFound.FirstName = student.FirstName;
            studentFound.LastName = student.LastName;
            studentFound.Password = student.Password;
            studentFound.Email = student.Email;
            studentFound.CPF = student.CPF;
            studentFound.Address = student.Address;
            studentFound.PhoneNumber = student.PhoneNumber;
            studentFound.AddedIn = student.AddedIn;
            studentFound.BirthDate = student.BirthDate;
            studentFound.educationLevel = student.educationLevel;
            studentFound.Grade = student.Grade;

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
            var students = _context.Students.Where(u => u.CPF == student.CPF).ToList();

            if (students.Count == 0)
                return false;

            var isMyStudentCPF = students.Where(u => u.Id == student.Id).FirstOrDefault() != null;

            if (isMyStudentCPF)
                return false;

            return true;
        }

        public bool VerifyIfEmailAlreadyExists(Student student)
        {
            var students = _context.Students.Where(s => s.Email == student.Email).ToList();

            if (students.Count == 0)
                return false;

            var isMyStudentEmail = students.Where(u => u.Id == student.Id).FirstOrDefault() != null;

            if (isMyStudentEmail)
                return false;

            return true;
        }

        public bool VerifyIfStudentAlreadyExists(Guid id)
        {
            var verifyIdInDb = _context.Students.Where(s => s.Id == id).ToList();

            if (verifyIdInDb.Count > 1)
                return true;

            return false;
        }
    }
}
