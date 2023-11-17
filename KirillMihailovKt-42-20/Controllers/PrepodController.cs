using KirillMihailovKt_42_20.Database;
using KirillMihailovKt_42_20.Filters.PrepodFilters;
using KirillMihailovKt_42_20.Interfaces.PrepodInterfaces;
using KirillMihailovKt_42_20.Models;
using Microsoft.AspNetCore.Mvc;

namespace KirillMihailovKt_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrepodController : ControllerBase
    {
        private readonly ILogger<PrepodController> _logger;
        private readonly IPrepodService _prepodService;
        private readonly PrepodDbContext _dbContext;

        public PrepodController(ILogger<PrepodController> logger, IPrepodService prepodService, PrepodDbContext dbContext)
        {
            _logger = logger;
            _prepodService = prepodService;
            _dbContext = dbContext;

        }

        [HttpGet]
        [Route("GetPrepodAsync")]
        public async Task<List<Prepod>>GetPrepodAsync()
        {
            var prepod = await _prepodService.GetPrepodAsync();

            return prepod;
        }

        [HttpPost]
        [Route("GetPrepodByKafedra")]
        public async Task<IActionResult> GetPrepodByKafedraAsync(PrepodKafedraFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodByKafedraAsync(filter, cancellationToken);

            return Ok(prepod);
        }

        [HttpPost]
        [Route("GetPrepodByAcademicDegreeAsync")]
        public async Task<IActionResult> GetPrepodByAcademicDegreeAsync(PrepodAcademicDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var prepod = await _prepodService.GetPrepodByAcademicDegreeAsync(filter, cancellationToken);

            return Ok(prepod);
        }
    }

}
