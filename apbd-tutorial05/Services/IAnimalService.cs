using apbd_tutorial05.Models;

namespace apbd_tutorial05.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimalsSorted(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);

}