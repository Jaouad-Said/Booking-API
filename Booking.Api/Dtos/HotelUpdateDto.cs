namespace Booking.Api.Dtos
{
    public record HotelUpdateDto(
        string Name,
        string Address,
        string Country,
        string City,
        int Stars
        );
}
