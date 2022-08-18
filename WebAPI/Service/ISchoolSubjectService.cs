using WebAPI.Models;

namespace WebAPI.Service
{
    public interface ISchoolSubjectService
    {
        SchoolSubject GetById(int id);
        IEnumerable<SchoolSubject> GetAll();
        SchoolSubject Add(SchoolSubject subject);
        SchoolSubject Edit(SchoolSubject subject);
        void Delete(int id);
    }
}
