using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private static List<Item> items = new List<Item>();

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetItems()
    {
      return Ok(items);
    }

    [HttpPost]
    public ActionResult<Item> PostItem(Item item)
    {
      items.Add(item);
      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult PutItem(int id, Item item)
    {
      var existingItem = items.FirstOrDefault(i => i.Id == id);
      if (existingItem == null)
      {
        return NotFound();
      }

      existingItem.Name = item.Name;
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
      var item = items.FirstOrDefault(i => i.Id == id);
      if (item == null)
      {
        return NotFound();
      }

      items.Remove(item);
      return NoContent();
    }
  }
}
