using _13638_WEBAPI.Data;
using _13638_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _13638_WEBAPI.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly GeneralDBContext _context;

        public StudentRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() => await _context.Students.Include(t => t.Grade).ToArrayAsync();

        public async Task<Student> GetByIDAsync(int id)
        {
            return await _context.Students.Include(t => t.Grade).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddAsync(Student entity)
        {
            entity.Grade = await _context.Grades.FindAsync(entity.GradeID.Value);

            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity != null)
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
