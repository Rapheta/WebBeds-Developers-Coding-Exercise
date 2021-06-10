using CheapAwesome.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheapAwesome.Core.Interfaces
{
    public interface IAvailabilityRepository
    {
        Task<IEnumerable<Availability>> GetAvailability(string url, int timeout);
    }
}
