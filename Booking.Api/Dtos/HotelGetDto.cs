namespace Booking.Api.Dtos
{
    public record HotelGetDto(
        int Id,
        string Name,
        string Address,
        string Country,
        string City,
        int Stars
        );
}
