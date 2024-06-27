using System.Data.SqlClient;
using apbd_tutorial05.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace apbd_tutorial05.Repositories;

public class AnimalRepository: IAnimalRepository
{
    private readonly IConfiguration _configuration;
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var connection =
            new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal";
        
        connection.Open();

        var dataReader = command.ExecuteReader();
        var animals = new List<Animal>();

        while (dataReader.Read())
        {
            Animal animal = new Animal();
            animal.IdAnimal = (int)dataReader["IdAnimal"];
            animal.Area = dataReader["Area"].ToString();
            animal.Category = dataReader["Category"].ToString();
            animal.Name = dataReader["Name"].ToString();
            animal.Description = dataReader["Description"].ToString();
            animals.Add(animal);
        }

        return animals;
    }
    
    public IEnumerable<Animal> GetAnimalsSorted(string orderBy)
    {
        using var connection =
            new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ";
        
        connection.Open();

        var dataReader = command.ExecuteReader();
        var animals = new List<Animal>();

        while (dataReader.Read())
        {
            Animal animal = new Animal();
            animal.IdAnimal = (int)dataReader["IdAnimal"];
            animal.Area = dataReader["Area"].ToString();
            animal.Category = dataReader["Category"].ToString();
            animal.Name = dataReader["Name"].ToString();
            animal.Description = dataReader["Description"].ToString();
            animals.Add(animal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal(name,description,category,area) VALUES (@name,@description,@category,@area)";
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);

        var affectRowCount = command.ExecuteNonQuery();
        return affectRowCount;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal SET " +
                              "name=@name, description=@description, category=@category, area=@area " +
                              "WHERE IdAnimal=@IdAnimal";
        command.Parameters.AddWithValue("@IdAnimal", id);
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);

        var affectedRowCount = command.ExecuteNonQuery();
        return affectedRowCount;
    }

    public int DeleteAnimal(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        command.Parameters.AddWithValue("@IdAnimal", id);

        var affectedRowCount = command.ExecuteNonQuery();
        return affectedRowCount;

    }
}