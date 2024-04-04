using AutoMapper;
using DogReviewApp.Dto;
using DogReviewApp.Interfaces;
using DogReviewApp.Models;
using DogReviewApp.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DogReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IReviewRepository _reviewRepository;

        public DogController(IDogRepository dogRepository,
            IMapper mapper,
            IOwnerRepository ownerRepository,
            IReviewRepository reviewRepository
            )
        {
            _dogRepository = dogRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Dog>))]
        public IActionResult GetDogs()
        {
            var dogs = _mapper.Map<List<DogDto>>(_dogRepository.GetDogs());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(dogs);
        }

        [HttpGet("{dogId}")]
        [ProducesResponseType(200, Type = typeof(Dog))]
        [ProducesResponseType(400)]
        public IActionResult GetDog(int dogId)
        {
            if (!_dogRepository.DogExists(dogId))
                return NotFound();

            var dog = _mapper.Map<DogDto>(_dogRepository.GetDog(dogId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(dog);
        }
        [HttpGet("{dogId}/rating")]
        [ProducesResponseType(200, Type = typeof(Dog))]
        [ProducesResponseType(400)]
        public IActionResult GetDogRating(int dogId)
        {
            if (!_dogRepository.DogExists(dogId))
                return NotFound();
            var rating = _dogRepository.GetDogRating(dogId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(rating);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDog([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] DogDto dogCreate)
        {
            if (dogCreate == null)
                return BadRequest(ModelState);

            var dogs = _dogRepository.GetDogs()
                .Where(c => c.Name.Trim().ToUpper() == dogCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (dogs != null)
            {
                ModelState.AddModelError("", "Owner already exists!");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dogMap = _mapper.Map<Dog>(dogCreate);


            if (!_dogRepository.CreateDog(ownerId, catId, dogMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully created!");
        }
        [HttpPut("{dogId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDog(int dogId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] DogDto updatedDog)
        {
            if (updatedDog == null)
                return BadRequest(ModelState);
            if (dogId != updatedDog.Id)
                return BadRequest(ModelState);
            if (!_dogRepository.DogExists(dogId))
                return NotFound(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var dogMap = _mapper.Map<Dog>(updatedDog);
            if (!_dogRepository.UpdateDog(ownerId, catId, dogMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category!");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{dogId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletDog(int dogId)
        {
            if (!_dogRepository.DogExists(dogId))
                return NotFound(ModelState);

            var reviewsToDelete = _reviewRepository.GetReviewsOfADog(dogId);
            var dogToDelete = _dogRepository.GetDog(dogId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("","Something went wrong when deleting Reviews!");
            }

            if (!_dogRepository.DeleteDog(dogToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting dog!");
            }
            return NoContent();
        }
    }
}