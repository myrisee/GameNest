using AutoMapper;
using GameNest.Application.CQRS.Commands;
using GameNest.Application.CQRS.Queries;
using GameNest.Application.CQRS.Requests;
using GameNest.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(IMediator mediator, IMapper mapper)
        : ControllerBase
    {
        [HttpPost]
        public async Task<PlayerModel> CreatePlayer([FromBody] CreatePlayerCommand command)
        {
            var result = await mediator.Send(command);
            return mapper.Map<PlayerModel>(result);
        }

        [HttpGet("guid")]
        public async Task<PlayerModel> GetPlayerByGuid([FromQuery] GetPlayerByGuidRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<PlayerModel>(result);
        }

        [HttpGet("username")]
        public async Task<PlayerModel> GetPlayerByUsername([FromQuery] GetPlayerByUsernameRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<PlayerModel>(result);
        }

        [HttpGet("all")]
        public async Task<List<PlayerModel>> GetAllPlayers([FromQuery] GetAllPlayersRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<List<PlayerModel>>(result);
        }
    }
}
