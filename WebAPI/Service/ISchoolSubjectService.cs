using WebAPI.Models;

namespace WebAPI.Service
{
    public interface ISchoolSubjectService
    {
        Task<SchoolSubject> GetById(int id);
        Task<IEnumerable<SchoolSubject>> GetAll();
        Task<SchoolSubject> Add(SchoolSubject subject);
        Task<SchoolSubject> Edit(SchoolSubject subject);
        Task Delete(int id);
        void LogError(Exception ex, string message);
    }
}