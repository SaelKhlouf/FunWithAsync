using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("v1/sync")]
        public string GetSync()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            return "hello sync";
        }

        [HttpGet("v1/async")]
        public async Task<string> GetAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return "hello async";
        }


    }
}