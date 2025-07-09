using AutoMapper;
using GameNest.Application.CQRS.Commands;
using GameNest.Application.CQRS.Queries;
using GameNest.Application.CQRS.Requests;
using GameNest.Shared.Services;
using GameNest.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        /*[HttpPost]
        public async Task<AccountModel> CreatePlayer([FromBody] CreatePlayerCommand command)
        {
            var result = await mediator.Send(command);
            return mapper.Map<AccountModel>(result);
        }*/

        [HttpGet("guid")]
        public async Task<AccountModel> GetPlayerByGuid([FromQuery] GetAccountByGuidRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<AccountModel>(result);
        }

        [HttpGet("username")]
        public async Task<AccountModel> GetPlayerByUsername([FromQuery] GetPlayerByUsernameRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<AccountModel>(result);
        }

        [HttpGet("all")]
        public async Task<List<AccountModel>> GetAllPlayers([FromQuery] GetAllPlayersRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<List<AccountModel>>(result);
        }
    }
}
