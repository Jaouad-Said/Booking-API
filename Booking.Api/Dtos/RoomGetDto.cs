namespace Booking.Api.Dtos
{
    public record RoomGetDto(
        int Id,
        int Number,
        bool NeedsRepair
        );
}
