using KirillMihailovKt_42_20.Filters.KafedraFilter;
using KirillMihailovKt_42_20.Filters.PrepodFilters;
using KirillMihailovKt_42_20.Interfaces.KafedraInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KirillMihailovKt_42_20.Models;

namespace KirillMihailovKt_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KafedraController : ControllerBase
    {
        private readonly ILogger<KafedraController> _logger;
        private readonly IKafedraService _kafedraService;

        public KafedraController(ILogger<KafedraController> logger, IKafedraService kafedraService)
        {
            _logger = logger;
            _kafedraService = kafedraService;
        }

        [HttpGet]
        [Route("GetKafedraAsync")]
        public async Task<List<Kafedra>> GetKafedrasAsync()
        {
            var kafedra = await _kafedraService.GetKafedraAsync();

            return kafedra;
        }

        [HttpPost]
        [Route("GetKafedraByDateFoundationAsync")]
        public async Task<IActionResult> GetKafedraByDateFoundationAsync(KafedraDateFoundationFilter filter, CancellationToken cancellationToken = default)
        {
            var kafedra = await _kafedraService.GetKafedraByDateFoundationAsync(filter, cancellationToken);

            return Ok(kafedra);
        }

        [HttpPost]
        [Route("GetKafedraByPrepodCountAsync")]
        public async Task<IActionResult> GetKafedraByPrepodCountAsync(KafedraPrepodCountFilter filter, CancellationToken cancellationToken = default)
        {
            var kafedra = await _kafedraService.GetKafedraByPrepodCountAsync(filter, cancellationToken);

            return Ok(kafedra);
        }
    }
}
