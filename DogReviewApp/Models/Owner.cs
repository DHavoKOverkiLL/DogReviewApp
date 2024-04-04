using System.Security.Cryptography.X509Certificates;

namespace DogReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Club{ get; set; }
        public Country Country { get; set; }
        public ICollection<DogOwner> DogOwners { get; set; }
    }
}