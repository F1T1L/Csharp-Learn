using StackExchange.Redis;
using System.Text.Json;
using Test_RedisApi.Models;

namespace Test_RedisApi.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;

        }
        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new ArgumentException(nameof(plat));
            }
            var db = _redis.GetDatabase();
            var serialPlat = JsonSerializer.Serialize(plat);
            db.StringSet(plat.Id, serialPlat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redis.GetDatabase();
            var plat = db.StringGet(id);
            if (!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<Platform>(plat); 
            }
            return null;
        }
    }
}
