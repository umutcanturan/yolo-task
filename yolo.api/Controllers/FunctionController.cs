﻿using MediatR;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _functionService.FunctionA();
            return Ok("Completed");
        }
    }
}
