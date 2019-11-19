using Ocelot.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Extensions
{
    public class RedisOcelotCache : IOcelotCache<CachedResponse>
    {
        void IOcelotCache<CachedResponse>.Add(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            if (value.StatusCode != System.Net.HttpStatusCode.OK) return;

            var redisKey = GetRedisKey(region, key);
            if (!RedisHelper.Exists(redisKey))
            {
                var data = new CacheObj()
                {
                    ExpireTime = DateTime.Now.Add(ttl),
                    Response = value
                };
                var redisTs = ttl.Add(ttl);
                RedisHelper.Set(redisKey, data, (int)redisTs.TotalSeconds);
            }
        }

        void IOcelotCache<CachedResponse>.AddAndDelete(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            if (value.StatusCode != System.Net.HttpStatusCode.OK) return;

            var redisKey = GetRedisKey(region, key);
            if (RedisHelper.Exists(redisKey))
            {
                RedisHelper.Del(redisKey);
            }

            var data = new CacheObj()
            {
                ExpireTime = DateTime.Now.Add(ttl),
                Response = value
            };

            var redisTs = ttl.Add(ttl);
            RedisHelper.Set(redisKey, data, (int)redisTs.TotalSeconds);
        }

        void IOcelotCache<CachedResponse>.ClearRegion(string region)
        {
           
        }

        CachedResponse IOcelotCache<CachedResponse>.Get(string key, string region)
        {
            var redisKey = GetRedisKey(region, key);

            if (!RedisHelper.Exists(redisKey)) return null;

            var cacheObj = RedisHelper.Get<CacheObj>(redisKey);

            if (cacheObj != null && cacheObj.ExpireTime >= DateTime.Now)
            {
                if (cacheObj.Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return cacheObj.Response;
                }
            }
            RedisHelper.Del(redisKey);
            return null;
        }

        string GetRedisKey(string region, string key)
        {
            //if (key.Contains("?"))
            //{
            //    key = key.Split("?").Last();
            //}
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                key = Convert.ToBase64String(hashValue);
            }
            return $"OcelotCache_{region}_{key}";
        }
    }

    public class CacheObj
    {
        public DateTime ExpireTime { get; set; }

        public CachedResponse Response { get; set; }
    }
}
