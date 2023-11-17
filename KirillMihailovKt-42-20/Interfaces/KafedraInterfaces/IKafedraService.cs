using KirillMihailovKt_42_20.Database;
using KirillMihailovKt_42_20.Filters.PrepodFilters;
using KirillMihailovKt_42_20.Filters.KafedraFilter;
using KirillMihailovKt_42_20.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace KirillMihailovKt_42_20.Interfaces.KafedraInterface
{
    public interface IKafedraService
    {
        public Task<List<Kafedra>> GetKafedraAsync();
        public Task<Kafedra[]> GetKafedraByDateFoundationAsync(KafedraDateFoundationFilter filter, CancellationToken cancellationToken);
        public Task<Kafedra[]> GetKafedraByPrepodCountAsync(KafedraPrepodCountFilter filter, CancellationToken cancellationToken);
    }
    public class KafedraService : IKafedraService
    {
        private readonly PrepodDbContext _dbContext;

        public KafedraService(PrepodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Kafedra>> GetKafedraAsync()
        {
            var kafedra = await _dbContext.Kafedra.ToListAsync();

            return kafedra;
        }
        public Task<Kafedra[]> GetKafedraByDateFoundationAsync(KafedraDateFoundationFilter filter, CancellationToken cancellationToken = default)
        {
            var kafedra = _dbContext.Set<Kafedra>().Where(e => e.DateFoundation == filter.DateFoundation).ToArrayAsync(cancellationToken);

            return kafedra;
        }
        public Task<Kafedra[]> GetKafedraByPrepodCountAsync(KafedraPrepodCountFilter filter, CancellationToken cancellationToken = default)
        {
            var kafedra = _dbContext.Set<Kafedra>().Where(e => e.PrepodCount >= filter.PrepodCount).ToArrayAsync(cancellationToken);

            return kafedra;
        }
    }
}
