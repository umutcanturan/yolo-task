using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yolo.service.interfaces;

namespace yolo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IAssetService _assetService;
        public GraphQLController(IAssetService assetService) 
        { 
            _assetService= assetService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _assetService.GetAssets();
            return Ok(list);
        }
    }
}
