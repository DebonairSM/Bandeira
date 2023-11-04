using Bandeira.Application.Abstractions.Messaging;

namespace Bandeira.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
