using System;
using System.ComponentModel.DataAnnotations;

namespace DogAPI.Models
{
    public class Dogs
    {
       [Key]
    
       public int Id { get; set; }
       public string Name { get; set; }
       public string Weight { get; set; }
       public string AverageWeight { get; set; }
       public string ImageUrl { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}

