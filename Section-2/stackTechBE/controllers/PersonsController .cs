using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Models;

namespace SimpleCrudApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonsController : ControllerBase
  {
    private static List<Person> _Persons = new List<Person>
    {
        new Person { Id = 1, Name = "Person 1", Nic = "1112233348V" },
        new Person { Id = 2, Name = "Person 2", Nic = "1112233349V" }
    };

    // GET: api/Persons
    [HttpGet]
    public ActionResult<IEnumerable<Person>> GetAll()
    {
      return Ok(_Persons);
    }

    // GET: api/Persons/{id}
    [HttpGet("{id}")]
    public ActionResult<Person> GetById(int id)
    {
      var Person = _Persons.FirstOrDefault(p => p.Id == id);
      if (Person == null)
      {
        return NotFound();
      }
      return Ok(Person);
    }

    // POST: api/Persons
    [HttpPost]
    public ActionResult<Person> Create(Person Person)
    {
      Person.Id = _Persons.Any() ? _Persons.Max(p => p.Id) + 1 : 1;
      _Persons.Add(Person);
      return CreatedAtAction(nameof(GetById), new { id = Person.Id }, Person);
    }

    // PUT: api/Persons/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Person Person)
    {
      var existingProduct = _Persons.FirstOrDefault(p => p.Id == id);
      if (existingProduct == null)
      {
        return NotFound();
      }

      existingProduct.Name = Person.Name;
      existingProduct.Nic = Person.Nic;

      return NoContent();
    }

    // DELETE: api/Persons/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var Person = _Persons.FirstOrDefault(p => p.Id == id);
      if (Person == null)
      {
        return NotFound();
      }

      _Persons.Remove(Person);
      return NoContent();
    }
  }
}
