using System.Reflection;
using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Domain.Abstractions;
using Bandeira.Infrastructure;

namespace Bandeira.ArchitectureTests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => typeof(IBaseCommand).Assembly;

    protected static Assembly DomainAssembly => typeof(IEntity).Assembly;

    protected static Assembly InfrastructureAssembly => typeof(ApplicationDbContext).Assembly;
}
