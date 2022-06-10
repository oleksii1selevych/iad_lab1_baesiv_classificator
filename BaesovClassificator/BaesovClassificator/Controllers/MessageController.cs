using BaesovClassificator.Contracts.Logging;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BaesovClassificator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly IServiceManager services;
        private readonly ILoggerManager logger;

        public MessageController(IServiceManager services, ILoggerManager logger) 
        {
            this.services = services;
            this.logger = logger;
        }

        [HttpPost("training")]
        public async Task<IActionResult> AddTrainingMessage([FromBody] MessageDto messageDto)
        {
            try
            {
                if(messageDto == null)
                {
                    logger.LogError("Message Dto in AddTrainingMessage action equals null");
                    return BadRequest("Message data transfer object is null");
                }

                await services.MessageService.AddMessageAsync(messageDto);
                return Ok("Your message was successfully added");

            } catch (Exception ex)
            {
                logger.LogError(String.Format("Some error happened while executing the incoming request {0}", ex.Message));
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("guess")]
        public async Task<IActionResult> GuessClassification([FromBody] MessageDto messageDto)
        {
            try
            {
                if (messageDto == null)
                {
                    logger.LogError("Message Dto in GuessClassification action equals null");
                    return BadRequest("Message data transfer object is null");
                }

                await services.MessageService.SetMessageClassification(messageDto);
                return Ok(messageDto);

            } catch (Exception ex)
            {
                logger.LogError(String.Format("Some error happened while executing the incoming request {0}", ex.Message));
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
