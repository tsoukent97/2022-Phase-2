using Microsoft.AspNetCore.Mvc;
using DogAPI.Models.Dto;
using DogAPI.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace DogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogAPIController : ControllerBase
    {

        public DogAPIController()
        {
            
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult <IEnumerable<DogsDTO>> GetDogs()
        {
            return Ok(DogsStore.dogList);
        }


        // GET api/values/5
        [HttpGet("{id:int}", Name = "GetDog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult <DogsDTO> GetDog(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var dog = DogsStore.dogList.FirstOrDefault(u => u.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            return Ok(dog);
        }


        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<DogsDTO> CreateDog([FromBody]DogsDTO dogsDTO)
        {
            if (DogsStore.dogList.FirstOrDefault(u=>u.Name.ToLower() == dogsDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "Dog already exists!");
                return BadRequest(ModelState);
            }
            if (dogsDTO == null)
            {
                return BadRequest(dogsDTO);
            }
            if (dogsDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            dogsDTO.Id = DogsStore.dogList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            DogsStore.dogList.Add(dogsDTO);

            return CreatedAtRoute("GetDog", new { id = dogsDTO.Id }, dogsDTO);
        }


        // PUT api/values/5
        [HttpPut("{id:int}", Name = "UpdateDog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateDog(int id, [FromBody] DogsDTO dogsDTO)
        {
            if (dogsDTO == null || id != dogsDTO.Id)
            {
                return BadRequest();
            }
            var dog = DogsStore.dogList.FirstOrDefault(u => u.Id == id);
            dog.Name = dogsDTO.Name;
            dog.Size = dogsDTO.Size;
            dog.AverageWeight = dogsDTO.AverageWeight;

            return NoContent();
        }


        // DELETE api/values/5
        [HttpDelete("{id:int}", Name = "DeleteDog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult DeleteDog(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var dog = DogsStore.dogList.FirstOrDefault(u => u.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            DogsStore.dogList.Remove(dog);
            return NoContent();
        }

        //PATCH api/values/5
        [HttpPatch("{id:int}", Name = "UpdatePartialDog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialDog(int id, JsonPatchDocument<DogsDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var dog = DogsStore.dogList.FirstOrDefault(u => u.Id == id);
            if (dog == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(dog, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}

