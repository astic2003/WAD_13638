using _13638_WEBAPI.Data;
using _13638_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _13638_WEBAPI.Repositories
{
    public class GradeRepository : IRepository<Grade>
    {
        private readonly GeneralDBContext _context;

        public GradeRepository(GeneralDBContext context)
        {
            _context = context;
        }

        // Add or create new entity
        public async Task AddAsync(Grade categories)
        {
            await _context.Grades.AddAsync(categories);
            await _context.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Grades.FindAsync(id);
            if (entity != null)
            {
                _context.Grades.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Grade>> GetAllAsync() => await _context.Grades.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<Grade> GetByIDAsync(int id) => await _context.Grades.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(Grade categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
