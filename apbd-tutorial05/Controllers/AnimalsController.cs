using apbd_tutorial05.Models;
using apbd_tutorial05.Repositories;
using apbd_tutorial05.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace apbd_tutorial05.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController: ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet]
    public IActionResult GetAnimalsSorted(string orderBy = null)
    {
        if (!_animalService.GetAnimalsSorted(orderBy).Any())
        {
            return NotFound($"Attribute {orderBy} is not found!");    
        }

        return Ok(_animalService.GetAnimalsSorted(orderBy));

    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedRowCount = _animalService.UpdateAnimal(id, animal);
        if (affectedRowCount == 0)
        {
            return NotFound($"The animal with ID {id} is not found!");
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectRowCount = _animalService.DeleteAnimal(id);
        if (affectRowCount == 0)
        {
            return NotFound($"The animal with ID {id} is not found!");
        }
        return NoContent();
    }
}