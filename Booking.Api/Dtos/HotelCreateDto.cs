namespace Booking.Api.Dtos
{
    public record HotelCreateDto(
        string Name,
        string Address,
        string Country,
        string City,
        int Stars
        );
}
