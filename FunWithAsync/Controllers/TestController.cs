using FunWithAsync.Models;
using FunWithAsync.Utils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FunWithAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Performs a synchronous delay for specific number of seconds.
        /// </summary>
        [HttpGet("v1/sync")]
        public ThreadsInfo GetSync([Required] int seconds)
        {
            Helpers.delaySync(seconds);
            return Helpers.getThreadsInfo();
        }

        /// <summary>
        /// Performs an asynchronous delay for specific number of seconds.
        /// </summary>
        [HttpGet("v1/async")]
        public async Task<ThreadsInfo> GetAsync([Required] int seconds)
        {
            await Helpers.delayAsync(seconds);
            return Helpers.getThreadsInfo();
        }
    }
}