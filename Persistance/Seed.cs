using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistance
{
  public class Seed
  {
    public static void SeedData(DataContext context)
    {
      if (!context.Items.Any())
      {
        var items = new List<Item>{
          new Item
          {
            Description = "Item 1",                
            Date = DateTime.Now.AddMonths(-2),
          },
          new Item
          {
            Description = "Item 2",                
            Date = DateTime.Now.AddMonths(-1),
          },
          new Item
          {
            Description = "Item 3",                
            Date = DateTime.Now.AddMonths(1),
          }
        };
        context.Items.AddRange(items);
        context.SaveChanges();
      }
    }
  }
}