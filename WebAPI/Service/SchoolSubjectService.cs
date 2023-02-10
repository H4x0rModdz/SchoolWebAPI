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

        public async Task<SchoolSubject> Add(SchoolSubject subject)
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

        public async Task<IEnumerable<SchoolSubject>> GetAll() => await _schoolSubjectRepository.GetAll();

        public async Task<SchoolSubject> GetById(int id)
        {
            if (_schoolSubjectRepository.VerifyIfSubjectAlreadyExists(id))
                throw new ArgumentException("Id does not exists");

            return await _schoolSubjectRepository.GetById(id);
        }

        Task ISchoolSubjectService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<SchoolSubject> ISchoolSubjectService.Edit(SchoolSubject subject)
        {
            throw new NotImplementedException();
        }

        Task<SchoolSubject> ISchoolSubjectService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}