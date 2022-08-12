using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        int SaveChanges();
    }
}
