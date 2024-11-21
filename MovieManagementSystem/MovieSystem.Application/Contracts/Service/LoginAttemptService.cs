using Microsoft.Extensions.Caching.Distributed;
using MovieSystem.Application.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Service
{
    public class LoginAttemptService : ILoginAttemptService
    {
        private readonly IDistributedCache _cache;
        private readonly int _maxAttempts = 5;
        private readonly TimeSpan _timeWindow = TimeSpan.FromMinutes(15);
       
        public LoginAttemptService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<bool> IsThrottledAsync(string key)
        {
            var failedAttempts = await _cache.GetStringAsync(key);
            if (failedAttempts == null)
            {
                await _cache.SetStringAsync(key, "1", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = _timeWindow
                });
                return false;
            }

            int attempts = int.Parse(failedAttempts);
            if (attempts >= _maxAttempts)
            {
                return true;  // Too many attempts
            }

            await _cache.SetStringAsync(key, (attempts + 1).ToString(), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _timeWindow
            });

            return false;
        }
    }
}
