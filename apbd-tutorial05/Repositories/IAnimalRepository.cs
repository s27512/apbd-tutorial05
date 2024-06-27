using apbd_tutorial05.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial05.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    IEnumerable<Animal> GetAnimalsSorted(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}