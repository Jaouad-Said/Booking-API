using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Abstractions.Repositories;
using Booking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper, IRoomRepository roomRepository)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelCreateDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            //var hotel = new Hotel()
            //{
            //    Name = hotelDto.Name,
            //    Address = hotelDto.Address,
            //    Country = hotelDto.Country,
            //    City = hotelDto.City,
            //    Stars = hotelDto.Stars
            //};

            await _hotelRepository.CreateHotelAsync(hotel);

            var mappedHotel = _mapper.Map<HotelGetDto>(hotel);

            return CreatedAtAction(nameof(GetHotelById), new { mappedHotel.Id }, mappedHotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelUpdateDto updatedHotel)
        {
            //var old = await _dbContext.Hotels.FindAsync(id);
            //if (old == null)
            //{
            //    return NotFound();
            //}

            //old.Name = hotel.Name;
            //old.Address = hotel.Address;
            //old.Country = hotel.Country;
            //old.City = hotel.City;
            //old.Stars = hotel.Stars;

            var hotel = _mapper.Map<Hotel>(updatedHotel);

            hotel.Id = id;

            await _hotelRepository.UpdateHotelAsync(id, hotel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var existing = await _hotelRepository.GetHotelByIdAsync(id);

            if (existing == null)
            {
                return NotFound();
            }

            await _hotelRepository.DeleteHotelAsync(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var mappedHotel = _mapper.Map<HotelGetDto>(hotel);

            return Ok(mappedHotel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var mappedHotel = _mapper.Map<List<HotelGetDto>>(hotels);

            return Ok(mappedHotel);
        }

        [HttpGet("{idHotel}/rooms")]
        public async Task<IActionResult> GetAllHotelRooms(int idHotel)
        {
            var rooms = await _roomRepository.GetAllHoteRoomslAsync(idHotel);

            var mappedRooms = _mapper.Map<List<RoomGetDto>>(rooms);

            return Ok(mappedRooms);
        }

        [HttpGet("{idHotel}/rooms/{idRoom}")]
        public async Task<IActionResult> GetHotelRoomById(int idHotel, int idRoom)
        {
            var room = await _roomRepository.GetHotelRoomByIdAsync(idHotel, idRoom);

            if (room == null)
                return NotFound("Room Not Found");

            var mappedRoom = _mapper.Map<RoomGetDto>(room);

            return Ok(mappedRoom);
        }

        [HttpPost("{idHotel}/rooms/")]
        public async Task<IActionResult> CreateHotelRoom(int idHotel, RoomCreateDto newRoom)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(idHotel);
            if (hotel == null)
                return NotFound("Hotel not found");

            var room = _mapper.Map<Room>(newRoom);
            await _roomRepository.CreateHotelRoomAsync(idHotel, room);

            var mappedRoom = _mapper.Map<RoomGetDto>(room);

            return CreatedAtAction(nameof(GetHotelRoomById), new { idHotel, idRoom = mappedRoom.Id }, mappedRoom);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateHotelRoom(int idHotel, RoomUpdateDto newRoom)
        //{

        //}
    }
}
