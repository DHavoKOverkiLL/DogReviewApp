using DogReviewApp.Models;

namespace DogReviewApp.Interfaces
{
    public interface IDogRepository
    {
        ICollection<Dog> GetDogs();
        Dog GetDog(int id);
        Dog GetDog(string name);
        bool DogExists(int dogId);
        decimal GetDogRating(int dogId);
        bool CreateDog(int ownderId, int categoryId, Dog dog);
        bool UpdateDog(int ownerId, int categoryId, Dog dog);
        bool DeleteDog(Dog dog);
        bool Save();
    }
}
