using AutoMapper;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Reservation, ReservationViewModel>();

            CreateMap<User, UserViewModel>();

            CreateMap<Room, RoomViewModel>()
                .ForMember(o => o.ReservationsCount, s => s.MapFrom(d => d.Reservations != null ?
                    d.Reservations.Where(res => res.EndDate >= DateTime.Now && res.Deleted == false).Count() : 0));

            CreateMap<RoomValue, RoomValueViewModel>()
                .ForMember(o => o.RoomsCount, s => s.MapFrom(d => d.Rooms != null ?
                    d.Rooms.Where(r => r.Deleted == false).Count() : 0));
        }
    }
}