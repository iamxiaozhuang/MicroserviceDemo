using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCommon.Caches
{
    public interface ISystemDataCache
    {
        Task UpdateResourceData();
        Task<List<ResourceData>> GetResourceData();
    }

    public class SystemDataCache : ISystemDataCache
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICallSystemServiceApi callSystemServiceApi;
        public SystemDataCache(IHttpContextAccessor _httpContextAccessor, ICallSystemServiceApi _callSystemServiceApi)
        {
            httpContextAccessor = _httpContextAccessor;
            callSystemServiceApi = _callSystemServiceApi;
        }
        public async Task UpdateResourceData()
        {
            List<ResourceData> data = await callSystemServiceApi.GetResources();
            await RedisHelper.SetAsync(ResourceDataRedisKey, data, 36000);
        }
        public async Task<List<ResourceData>> GetResourceData()
        {
            List<ResourceData> data = await RedisHelper.GetAsync<List<ResourceData>>(ResourceDataRedisKey);
            if (data == null)
            {
                data = await callSystemServiceApi.GetResources();
                await RedisHelper.SetAsync(ResourceDataRedisKey, data);
            }
            return data;
        }

        private string ResourceDataRedisKey
        {
            get { return "ResourceData"; }
        }
    }
}
