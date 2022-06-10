using BaesovClassificator.Contracts.Logging;
using BaesovClassificator.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaesovClassificator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IServiceManager services;
        private readonly ILoggerManager logger;


        public ClassificationController(IServiceManager services, ILoggerManager logger)
        {
            this.services = services;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllClassificationsAsnc()
        {
            try
            {
                var classifications = await services.ClassificationService.GetAllClassificationsAsync();
                return Ok(classifications);

            } catch (Exception ex)
            {
                logger.LogError(String.Format("Some error happened while executing the incoming request {0}", ex.Message));
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
