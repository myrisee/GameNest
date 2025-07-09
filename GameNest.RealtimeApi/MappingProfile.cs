using AutoMapper;
using GameNest.Application.CQRS.Requests;
using GameNest.Application.CQRS.Requests.Auth;
using GameNest.Domain.Entities;
using GameNest.Shared.MessagePacks;
using GameNest.Shared.ViewModels;

namespace GameNest.RealtimeApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Loadout, LoadoutModel>().ReverseMap();
            CreateMap<ItemInstance, ItemInstanceModel>().ReverseMap();
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Item, ItemModel>().ReverseMap();
            CreateMap<Clan, ClanModel>().ReverseMap();
            CreateMap<RegisterMessage, RegisterRequest>().ReverseMap();
            CreateMap<LoginMessage, LoginRequest>().ReverseMap();
        }
    }
}