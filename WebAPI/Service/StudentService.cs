using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Add(Student student)
        {
            if (student.Password is null)
                throw new ArgumentException("The Password field is required");

            if (_studentRepository.VerifyIfEmailAlreadyExists(student))
                throw new ArgumentException("Email already exists");

            if (_studentRepository.VerifyIfCpfAlreadyExists(student))
                throw new ArgumentException("CPF already exists");

            _studentRepository.FilterSubjects(student);

            student.Id = Guid.NewGuid();

            _studentRepository.Add(student);

            return student;
        }

        public void Delete(Guid id)
        {
            _studentRepository.Delete(id);
        }

        public Student Edit(Student student)
        {
            if (_studentRepository.VerifyIfEmailAlreadyExists(student))
                throw new ArgumentException("Email already exists");

            if (_studentRepository.VerifyIfCpfAlreadyExists(student))
                throw new ArgumentException("CPF already exists");

            _studentRepository.FilterSubjects(student);

            _studentRepository.Edit(student);

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(Guid id)
        {
            if (_studentRepository.VerifyIfStudentAlreadyExists(id))
                throw new ArgumentException("Id does not exists");

            return _studentRepository.GetById(id);
        }
    }
}