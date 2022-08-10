using System;
using System.ComponentModel.DataAnnotations;

namespace DogAPI.Models.Dto
{
    public class DogsDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]

        public string Name { get; set; }

        public string Size { get; set; }

        public string AverageWeight { get; set;}

        public string ImageUrl { get; set; }
    }
}

