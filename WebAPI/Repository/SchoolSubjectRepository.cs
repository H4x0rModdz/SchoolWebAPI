using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class SchoolSubjectRepository : ISchoolSubjectRepository
    {
        private readonly IAppDbContext _context;
        public SchoolSubjectRepository(IAppDbContext context)
        {
            _context = context;
        }

        public void Add(SchoolSubject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subject = GetById(id);

            if (subject == null)
                throw new ArgumentException("School Subject Not Found");

            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }

        public void Edit(SchoolSubject subject)
        {
            var subjectFound = GetById(subject.Id);
            subjectFound.Name = subject.Name;

            _context.Subjects.Update(subjectFound);
            _context.SaveChanges();
        }

        public IEnumerable<SchoolSubject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public SchoolSubject GetById(int id)
        {
            return _context.Subjects.Find(id);
        }

        public bool VerifyIfSubjectAlreadyExists(int id)
        {
            var verifyIdInDb = _context.Subjects.Where(s => s.Id == id).ToList();

            if (verifyIdInDb.Count > 1)
                return true;

            return false;
        }
    }
}
