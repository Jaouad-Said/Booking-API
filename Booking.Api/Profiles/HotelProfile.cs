using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Models;

namespace Booking.Api.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<Hotel, HotelGetDto>();

            CreateMap<HotelUpdateDto, Hotel>();
        }
    }
}
