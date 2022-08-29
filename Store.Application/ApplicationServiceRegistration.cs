using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Store.Application.Features.Users.Commands.Register;

namespace Store.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IValidator<RegisterCommand>, RegisterCommandValidator>();
        return services;
    }
}
