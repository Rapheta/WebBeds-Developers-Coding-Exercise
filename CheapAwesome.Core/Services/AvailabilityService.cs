using CheapAwesome.Core.Entities;
using CheapAwesome.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheapAwesome.Core.Services
{
    public class AvailabilityService: IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<IEnumerable<Availability>> GetAvailability(string url, int timeout)
        {
            return await _availabilityRepository.GetAvailability(url, timeout);
        }
    }
}
