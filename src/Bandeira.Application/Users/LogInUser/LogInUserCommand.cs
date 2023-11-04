using Bandeira.Application.Abstractions.Messaging;

namespace Bandeira.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;
