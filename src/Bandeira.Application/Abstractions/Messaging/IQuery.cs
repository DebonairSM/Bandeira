using Bandeira.Domain.Abstractions;
using MediatR;

namespace Bandeira.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
