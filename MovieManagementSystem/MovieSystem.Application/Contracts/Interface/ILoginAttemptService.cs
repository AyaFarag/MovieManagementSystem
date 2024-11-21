using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface ILoginAttemptService
    {
        Task<bool> IsThrottledAsync(string key);
    }
}
