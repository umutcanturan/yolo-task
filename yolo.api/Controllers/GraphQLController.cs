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

        /// <summary>
        /// Fetches the market prices according to assets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _assetService.FetchMarketPrices());
        }
    }
}
