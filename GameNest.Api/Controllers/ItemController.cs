using AutoMapper;
using GameNest.Application.CQRS.Commands;
using GameNest.Application.CQRS.Queries;
using GameNest.Application.CQRS.Requests;
using GameNest.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameNest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IMediator mediator,IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ItemModel> CreateItem([FromBody] CreateItemCommand command)
        {
            var result = await mediator.Send(command);
            return mapper.Map<ItemModel>(result);
        }

        [HttpGet("id")]
        public async Task<ItemModel> GetItemById([FromQuery] GetItemByIdRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<ItemModel>(result);
        }

        [HttpGet("name")]
        public async Task<ItemModel> GetItemByName([FromQuery] GetItemByNameRequest request)
        {
            var result = await mediator.Send(request);
            return mapper.Map<ItemModel>(result);
        }
    }
}
