using Microsoft.AspNetCore.Mvc;
using Test_RedisApi.Data;
using Test_RedisApi.Models;

namespace Test_RedisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private IPlatformRepo _repo;

        public PlatformsController(IPlatformRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            var platform = _repo.GetPlatformById(id);
            if (platform != null)
            {
                return Ok(platform);
            }
            return NotFound();
        }
    }
}
