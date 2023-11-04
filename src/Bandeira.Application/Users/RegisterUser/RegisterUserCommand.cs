using Bandeira.Application.Abstractions.Messaging;

namespace Bandeira.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;
