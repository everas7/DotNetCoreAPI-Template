using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Items;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> List()
    {
      return await _mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> Details(int id)
    {
      return await _mediator.Send(new Details.Query{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Create(Create.Command command)
    {
      return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
    {
      command.Id = id;
      return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete (int id)
    {
      return await _mediator.Send(new Delete.Command{Id = id});
    }
  }
}
