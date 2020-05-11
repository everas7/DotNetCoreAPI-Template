using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Items
{
  public class Create
  {
    public class Command : IRequest
    {
      public string Description { get; set; }
      public DateTime Date { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request,
        CancellationToken cancellationToken)
      {
        var item = new Item
        {
          Description = request.Description,
          Date = request.Date,
        };
        _context.Items.Add(item);
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("There was a problem saving the item");
      }
    }
  }
}