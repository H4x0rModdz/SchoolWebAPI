using Microsoft.EntityFrameworkCore;
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

        public async Task Add(SchoolSubject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var subject = await GetById(id);

            if (subject == null)
                throw new ArgumentException("School Subject Not Found");

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(SchoolSubject subject)
        {
            var subjectFound = await GetById(subject.Id);
            subjectFound.Name = subject.Name;

            _context.Subjects.Update(subjectFound);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SchoolSubject>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<SchoolSubject> GetById(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public bool VerifyIfSubjectAlreadyExists(int id)
        {
            return _context.Subjects.Any(s => s.Id == id);
        }
    }
}