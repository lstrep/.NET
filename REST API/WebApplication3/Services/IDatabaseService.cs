using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface IDatabaseService
    {

        IEnumerable<Animal> GetAnimals(string orderBy);
        void AddAnimal(Animal animal);
        void UpdateAnimal(int index, Animal animal);
        void DeleteAnimal(int index);
        bool ValidateValue(string value);
    }
}
