using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IStudentRepository
    {
        Student GetById(Guid id);

        IEnumerable<Student> GetAll();

        void Add(Student student);

        void Edit(Student student);

        void Delete(Guid id);

        bool VerifyIfEmailAlreadyExists(Student student);

        bool VerifyIfCpfAlreadyExists(Student student);

        bool VerifyIfStudentAlreadyExists(Guid id);
    }
}
