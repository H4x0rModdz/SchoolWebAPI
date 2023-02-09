using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface ISchoolSubjectRepository
    {
        SchoolSubject GetById(int id);
        Task<IEnumerable<SchoolSubject>> GetAll();
        void Add(SchoolSubject subject);
        void Edit(SchoolSubject subject);
        void Delete(int id);
        bool VerifyIfSubjectAlreadyExists(int id);
    }
}