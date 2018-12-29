using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using candy_market2;

namespace candy_market2
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandyController : ControllerBase
    {
        public CandyStorage _storage;

        public CandyController()
        {
            _storage = new CandyStorage();
        }

        [HttpGet]
        public IActionResult GetAllCandy() 
        {
            return Ok(_storage.ReturnCandyInventory());
        }
    }
}
