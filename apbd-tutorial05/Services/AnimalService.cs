using apbd_tutorial05.Models;
using apbd_tutorial05.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace apbd_tutorial05.Services;

public class AnimalService: IAnimalService
{
    private IAnimalRepository _animalRepository;
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimalsSorted(string orderBy)
    {
        if (orderBy.IsNullOrEmpty())
        {
            return _animalRepository.GetAnimalsSorted("name");
        }
        if (orderBy.Equals("name",StringComparison.OrdinalIgnoreCase) || orderBy.Equals("description",StringComparison.OrdinalIgnoreCase) || orderBy.Equals("category",StringComparison.OrdinalIgnoreCase) ||
            orderBy.Equals("area",StringComparison.OrdinalIgnoreCase))
        {
            return _animalRepository.GetAnimalsSorted(orderBy);
        }

        return Enumerable.Empty<Animal>();

    }

    public int CreateAnimal(Animal animal)
    {
        return _animalRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return _animalRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalRepository.DeleteAnimal(id);
    }
}