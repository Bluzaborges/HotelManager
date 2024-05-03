using System.Reflection;
using HotelManager.Abstraction.Identity.Abstractions;
using HotelManager.Abstraction.Identity;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Abstraction.Mediator.Implementations;
using HotelManager.Application.Services;
using HotelManager.Application.Services.Abstractions;
using HotelManager.Data.Repositories;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Services.Abstractions;
using HotelManager.Domain.Services;
using HotelManager.Query.Data.Contexts;
using HotelManager.Query.Data.QueryContext;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HotelManager.Application")));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HotelManager.Query.Application")));
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

            // QueryContext
            services.AddScoped<IQueryContext, HotelManagerQueryContext>();

            // Authentication
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthUserData, AuthUserData>();

            // DbContext
            services.AddScoped<BookingDbContext>();
            services.AddScoped<HotelManagerQueryDbContext>();
        }
    }
}