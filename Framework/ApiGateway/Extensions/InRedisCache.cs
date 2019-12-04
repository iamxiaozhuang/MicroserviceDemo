using Ocelot.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Extensions
{
    public class InRedisCache<T> : IOcelotCache<T>
    {
        private readonly string redisKeyPrefix = "OcelotCache";
        /// <summary>
        /// 添加缓存信息
        /// </summary>
        /// <param name="key">缓存的key</param>
        /// <param name="value">缓存的实体</param>
        /// <param name="ttl">过期时间</param>
        /// <param name="region">缓存所属分类，可以指定分类缓存过期</param>
        public void Add(string key, T value, TimeSpan ttl, string region)
        {
            key = GetKey(region, key);
            if (ttl.TotalMilliseconds <= 0)
            {
                return;
            }
            RedisHelper.Set(key, value, (int)ttl.TotalSeconds);
        }


        public void AddAndDelete(string key, T value, TimeSpan ttl, string region)
        {
            Add(key, value, ttl, region);
        }

        /// <summary>
        /// 批量移除regin开头的所有缓存记录
        /// </summary>
        /// <param name="region">缓存分类</param>
        public void ClearRegion(string region)
        {
            //获取所有满足条件的key
            var data = RedisHelper.Keys(redisKeyPrefix + "-" + region + "-*");
            //批量删除
            RedisHelper.Del(data);
        }

        /// <summary>
        /// 获取执行的缓存信息
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="region">缓存分类</param>
        /// <returns></returns>
        public T Get(string key, string region)
        {
            key = GetKey(region, key);
            var result = RedisHelper.Get<T>(key);
            if (result != null)
            {
                return result;
            }
            return default(T);
        }

        /// <summary>
        /// 获取格式化后的key
        /// </summary>
        /// <param name="region">分类标识</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        private string GetKey(string region, string key)
        {
            return redisKeyPrefix + "-" + region + "-" + key;
        }
    }
}
