using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface ISchoolSubjectRepository
    {
        Task<SchoolSubject> GetById(int id);
        Task<IEnumerable<SchoolSubject>> GetAll();
        Task Add(SchoolSubject subject);
        Task Edit(SchoolSubject subject);
        Task Delete(int id);
        bool VerifyIfSubjectAlreadyExists(int id);
    }
}