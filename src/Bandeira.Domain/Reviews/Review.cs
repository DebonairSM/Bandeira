using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Persons;
using Bandeira.Domain.Reviews.Events;
using Bandeira.Domain.Users;

namespace Bandeira.Domain.Reviews;

public sealed class Review : Entity<ReviewId>
{
    private Review(
        ReviewId id,
        PersonId personId,
        UserId userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
        : base(id)
    {
        PersonId = personId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    private Review()
    {
    }

    public PersonId PersonId { get; private set; }

    public BookingId BookingId { get; private set; }

    public UserId UserId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != CardStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }

        var review = new Review(
            ReviewId.New(),
            booking.PersonId,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            createdOnUtc);

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}
