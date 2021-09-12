using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiDominicanaApi.Models;
using MiDominicanaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IFuelsService _fuelsService;

        public FuelsController(IFuelsService fuelsService)
        {
            _fuelsService = fuelsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _fuelsService.GetFuels();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        
    }
}
