using Test_RedisApi.Models;

namespace Test_RedisApi.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform> GetAllPlatforms();
    }
}
