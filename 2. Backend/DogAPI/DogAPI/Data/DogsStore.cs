using System;
using DogAPI.Models.Dto;

namespace DogAPI.Data
{
    public static class DogsStore
    {
        public static List<DogsDTO> dogList = new List<DogsDTO>
            {
                new DogsDTO{Id=1, Name="Pug", Size="Small", AverageWeight="8kgs"},
                new DogsDTO{Id=2, Name="Border Collie", Size="Medium" ,AverageWeight="20kgs"}
            };
    }
}