using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using yolo.common.models;
using yolo.service.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yolo.api.Controllers
{
    [Route("api/[controller]")]
    public class InvertController : Controller
    {
        private readonly IStringService _stringService;
        private readonly AppData _appData;
        public InvertController(IStringService stringService, IOptions<AppData> options)
        {
            _stringService = stringService;
            _appData = options.Value;
        }

        /// <summary>
        /// returns the reverse of item parameter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpGet("item")]
        public IActionResult Get(string item)
        {
            return Ok(_stringService.Reverse(item));
        }

        /// <summary>
        /// Returns default text from appsettings.json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("test 3");
            return Ok(_stringService.Reverse(_appData.ReverseStr));
        }
    }
}

