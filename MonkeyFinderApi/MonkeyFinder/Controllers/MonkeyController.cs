using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonkeyFinder.Core.Entities;
using MonkeyFinder.Services.Dtos;
using MonkeyFinder.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyFinder.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MonkeyController : ControllerBase
    {
        private readonly IMonkeyService _monkeyService;
        private readonly ILogger<MonkeyController> _logger;

        public MonkeyController(IMonkeyService monkeyService, ILogger<MonkeyController> logger)
        {
            _monkeyService = monkeyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> GetMonkeysAsync()
        {
            var result = await _monkeyService.GetMonkeysAsync();
            _logger.LogInformation("Monekys were retrieved with success. Monkeys count : {count}", result.Count());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> SearchMonkeyById(int id)
        {
            var result = await _monkeyService.SearchMonkeyByIdAsync(id);
            _logger.LogInformation("Monekys were retrieved with success. Monkeys count : {count}", result.Count());


            return Ok(result);
        }

        [HttpPost("{monkey}")]
        public async Task AddMonkey(Monkey monkey)
        {
            await _monkeyService.AddMonkeysAsync(monkey);
            _logger.LogInformation("Monkey has been added successfully.");
        }

        [HttpPut("{monkey}")]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> UpdateMonkeysAsync(MonkeyFinder.Core.Entities.Monkey monkey)
        {
            var result = await _monkeyService.UpdateMonkeysAsync(monkey);
            _logger.LogInformation("Monkey has been updated successfully.");

            return Ok(result);
        }
        
        [HttpDelete("{monkey}")]
        public async Task<ActionResult<IReadOnlyList<MonkeyDto>>> DeleteMonkeysAsync(MonkeyFinder.Core.Entities.Monkey monkey)
        {
            var result = await _monkeyService.DeleteMonkeysAsync(monkey);
            _logger.LogInformation("Monkey has been deleted successfully.");

            return Ok(result);
        }

    }
}
