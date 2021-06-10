using CheapAwesome.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheapAwesome.Core.Interfaces
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<Availability>> GetAvailability(string url, int timeout);
    }
}
