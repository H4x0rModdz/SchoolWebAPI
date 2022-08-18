using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public class SchoolSubjectService : ISchoolSubjectService
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository;

        public SchoolSubjectService(ISchoolSubjectRepository schoolSubjectRepository)
        {
            _schoolSubjectRepository = schoolSubjectRepository;
        }

        public SchoolSubject Add(SchoolSubject subject)
        {
            if (subject.Name is null)
                throw new ArgumentException("The Name field is required");

            _schoolSubjectRepository.Add(subject);

            return subject;
        }

        public void Delete(int id)
        {
            _schoolSubjectRepository.Delete(id);
        }

        public SchoolSubject Edit(SchoolSubject subject)
        {
            _schoolSubjectRepository.Edit(subject);

            return subject;
        }

        public IEnumerable<SchoolSubject> GetAll() => _schoolSubjectRepository.GetAll();

        public SchoolSubject GetById(int id)
        {
            if (_schoolSubjectRepository.VerifyIfSubjectAlreadyExists(id))
                throw new ArgumentException("Id does not exists");

            return _schoolSubjectRepository.GetById(id);
        }
    }
}
