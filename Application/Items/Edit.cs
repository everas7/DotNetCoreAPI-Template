using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace Application.Items
{
  public class Edit
  {
    public class Command : IRequest
    {
      public int Id { get; set; }
      public string Description { get; set; }
      public DateTime? Date { get; set; }
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
        var item = await _context.Items.FindAsync(request.Id);
        if (item == null)
          throw new Exception("Could not find item");

        item.Description = request.Description ?? item.Description;
        item.Date = request.Date ?? item.Date;

        var success = await _context.SaveChangesAsync() > 0;
    
        if (success) return Unit.Value;
    
        throw new Exception("There was a problem saving changes");
      }
    }
  }
}