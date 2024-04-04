using AutoMapper;
using DogReviewApp.Data;
using DogReviewApp.Interfaces;
using DogReviewApp.Models;
using System.Diagnostics.Metrics;

namespace DogReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OwnerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public ICollection<Dog> GetDogByOwner(int ownerId)
        {
            return _context.DogOwner.Where(p => p.Owner.Id == ownerId).Select(p => p.Dog).ToList(); ;
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfADog(int dogId)
        {
            return _context.DogOwner.Where(p => p.Dog.Id == dogId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return true;
        }
    }
}
