using WebAPI.Models;

namespace WebAPI.Service
{
    public interface IStudentService
    {
        Student GetById(Guid id);
        IEnumerable<Student> GetAll();
        Student Add(Student student);
        Student Edit(Student student);
        void Delete(Guid id);
    }
}