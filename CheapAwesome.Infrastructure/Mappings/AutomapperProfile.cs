using AutoMapper;
using CheapAwesome.Core.DTOs;
using CheapAwesome.Core.Entities;

namespace CheapAwesome.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Availability, AvailabilityDto>();
            CreateMap<AvailabilityDto, Availability>();
            CreateMap<Rate, RateDto>();
        }
    }
}
