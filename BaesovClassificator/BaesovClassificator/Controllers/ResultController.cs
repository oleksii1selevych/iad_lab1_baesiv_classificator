using BaesovClassificator.Contracts.Logging;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaesovClassificator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IServiceManager services;
        private readonly ILoggerManager logger;

        public ResultController(IServiceManager services, ILoggerManager logger)
        {
            this.services = services;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCorrectAnswersPercentages()
        {
            try
            {
                IEnumerable<CorrectResultPercentageDto> dtos =  await services.ResultService.GetCorrectResultsPercentagesAsync();
                logger.LogInfo("Result percentages were retrieved from database");
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                logger.LogError(String.Format("Some error happened while executing the incoming request {0}", ex.Message));
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGuessResultAsync([FromBody] bool result)
        {
            try
            {
                await services.ResultService.AddResult(result);
                logger.LogInfo("You have added guessing result");
                return Ok("Guess result was successfully added");

            } catch (Exception ex)
            {
                logger.LogError(String.Format("Some error happened while executing the incoming request {0}", ex.Message));
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
