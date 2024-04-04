using DogReviewApp.Data;
using DogReviewApp.Interfaces;
using DogReviewApp.Models;

namespace DogReviewApp.Repository
{
    public class DogRepository : IDogRepository
    {
        private readonly DataContext _context;
            public DogRepository(DataContext context)
        {
            _context = context;
        }
        public Dog GetDog(int id)
        {
            return _context.Dog.Where(p => p.Id == id).FirstOrDefault();
        }
        public Dog GetDog(string name)
        {
            return _context.Dog.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetDogRating(int dogId)
        {
            var review = _context.Reviews.Where(p => p.Dog.Id == dogId);
            if (review.Count() <=0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Dog> GetDogs()
        {
            return _context.Dog.OrderBy(p => p.Id).ToList();
        }

        public bool DogExists(int dogId)
        {
            return  _context.Dog.Any(p => p.Id == dogId);
        }

        public bool CreateDog(int ownderId, int categoryId, Dog dog)
        {
            var dogOwnerEntity = _context.Owners.Where(a => a.Id == ownderId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var dogOwner = new DogOwner()
            {
                Owner = dogOwnerEntity,
                Dog = dog,
            };

            _context.Add(dogOwner);

            var dogCategory = new DogCategory()
            {
                Category = category,
                Dog = dog,
            };

            _context.Add(dogCategory);

            _context.Add(dog);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDog(int ownerId, int categoryId, Dog dog)
        {
            _context.Update(dog);
            return Save();
        }

        public bool DeleteDog(Dog dog)
        {
            _context.Remove(dog);
            return Save();
        }
    }
}
