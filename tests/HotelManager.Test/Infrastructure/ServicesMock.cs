using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Abstraction.Mediator.Implementations;
using HotelManager.Application.Services.Abstractions;
using HotelManager.Application.Services;
using HotelManager.Data.Repositories;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Services.Abstractions;
using HotelManager.Domain.Services;
using HotelManager.Query.Application.AutoMapper;
using HotelManager.Query.Data.Contexts;
using HotelManager.Query.Data.QueryContext;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Test.Infrastructure
{
    public static class ServicesMock
    {
        public static IMediatorHandler GetMediator(BookingDbContext context, ScenarioContext scenarioContext, ServiceCollection services)
        {
            if (scenarioContext.TryGetValue($"Command{nameof(ServiceProvider)}", out ServiceProvider provider))
            {
                return provider.GetService<IMediatorHandler>() ?? throw new Exception("Serviço não encontrado.");
            }

            var newProvider = GetCommandServiceCollection(context, scenarioContext, services);

            return newProvider.GetService<IMediatorHandler>() ?? throw new Exception("Serviço não encontrado.");
        }

        public static IMediatorHandler GetMediator(HotelManagerQueryDbContext context, ScenarioContext scenarioContext, ServiceCollection services)
        {
            if (scenarioContext.TryGetValue($"Query{nameof(ServiceProvider)}", out ServiceProvider provider))
            {
                return provider.GetService<IMediatorHandler>() ?? throw new Exception("Serviço não encontrado.");
            }

            var newProvider = GetQueryServiceCollection(context, scenarioContext, services);

            return newProvider.GetService<IMediatorHandler>() ?? throw new Exception("Serviço não encontrado.");
        }

        private static ServiceProvider GetCommandServiceCollection(BookingDbContext context, ScenarioContext scenarioContext, ServiceCollection services)
        {
            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HotelManager.Application")));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Reservation
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationAppService, ReservationAppService>();

            // User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Room
            services.AddScoped<IRoomRepository, RoomRepository>();

            // RoomValue
            services.AddScoped<IRoomValueRepository, RoomValueRepository>();

            // Context
            services.AddScoped<IQueryContext, HotelManagerQueryContext>();

            // DbContext
            services.AddScoped(c => context);

            // Provider
            var provider = services.BuildServiceProvider();

            scenarioContext.Add($"Command{nameof(ServiceProvider)}", provider);

            return provider;
        }

        private static ServiceProvider GetQueryServiceCollection(HotelManagerQueryDbContext context, ScenarioContext scenarioContext, ServiceCollection services)
        {
            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HotelManager.Query.Application")));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Automapper
            services.AddAutoMapper(typeof(ModelToViewModelMappingProfile));

            // Context
            services.AddScoped<IQueryContext, HotelManagerQueryContext>();

            // DbContext
            services.AddScoped(c => context);

            // Provider
            var provider = services.BuildServiceProvider();

            scenarioContext.Add($"Query{nameof(ServiceProvider)}", provider);

            return provider;
        }
    }
}