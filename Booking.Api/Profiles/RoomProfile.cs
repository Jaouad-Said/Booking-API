using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Models;

namespace Booking.Api.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomGetDto>();
            CreateMap<RoomCreateDto, Room>();
        }
    }
}
