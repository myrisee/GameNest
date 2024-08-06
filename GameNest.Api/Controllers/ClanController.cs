using AutoMapper;
using GameNest.Application.CQRS.Commands;
using GameNest.Application.CQRS.Requests;
using GameNest.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameNest.WebApi.Controllers
{
    /*public class ClanController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ClanModel> CreateClan([FromBody] CreateClanCommand createClanCommand)
        {
            var result = await mediator.Send(createClanCommand);
            return mapper.Map<ClanModel>(result);
        }
    }*/
}
