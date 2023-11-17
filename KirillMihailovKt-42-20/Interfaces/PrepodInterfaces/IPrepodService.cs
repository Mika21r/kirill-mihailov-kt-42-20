using KirillMihailovKt_42_20.Database;
using KirillMihailovKt_42_20.Filters.PrepodFilters;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace KirillMihailovKt_42_20.Interfaces.PrepodInterfaces
{
    public interface IPrepodService
    {
        public Task<List<Prepod>> GetPrepodAsync();
        public Task<Prepod[]> GetPrepodByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken);
        public Task<Prepod[]> GetPrepodByAcademicDegreeAsync(PrepodAcademicDegreeFilter filter, CancellationToken cancellationToken);
    }

    public class PrepodService : IPrepodService
    {
        private readonly PrepodDbContext _dbContext;
        public PrepodService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Prepod>> GetPrepodAsync()
        {
            var prepod = _dbContext.Prepod.ToListAsync();
            return prepod;
        }
        public Task<Prepod[]> GetPrepodByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.Kafedra.KafedraName == filter.KafedraName).ToArrayAsync(cancellationToken);
            
            return prepod;
        }
        public Task<Prepod[]> GetPrepodByAcademicDegreeAsync(PrepodAcademicDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = _dbContext.Set<Prepod>().Where(w => w.AcademicDegree.AcademicDegreeName == filter.AcademicDegreeName).ToArrayAsync(cancellationToken);

            return prepod;
        }
    }
}
