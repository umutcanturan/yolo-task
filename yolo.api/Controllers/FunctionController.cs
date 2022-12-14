using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yolo.service.interfaces;

namespace yolo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        /// <summary>
        /// if useEvent is true, then async and event based logic triggered, 
        /// otherwise, mediatr pattern will be triggered.
        /// </summary>
        /// <param name="useEvent">Indicates the selected logic</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(bool useEvent = false)
        {
            await _functionService.FunctionA(useEvent);
            return Ok("Completed");
        }
    }
}
