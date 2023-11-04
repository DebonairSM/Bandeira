using Bandeira.Application.Abstractions.Clock;

namespace Bandeira.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
