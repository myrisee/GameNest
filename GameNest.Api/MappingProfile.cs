using AutoMapper;
using GameNest.Domain.Entities;
using GameNest.Shared.ViewModels;
using GameNest.Domain.Entities;
using GameNest.Shared.ViewModels;

namespace GameNest.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Loadout, LoadoutModel>().ReverseMap();
            CreateMap<ItemInstance, ItemInstanceModel>().ReverseMap();
            CreateMap<Player, PlayerModel>().ReverseMap();
            CreateMap<Item, ItemModel>().ReverseMap();
            CreateMap<Clan, ClanModel>().ReverseMap();
        }
    }
}
