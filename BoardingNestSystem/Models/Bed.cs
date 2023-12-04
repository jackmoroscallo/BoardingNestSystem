using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BoardingNestSystem.Models
{
    public class Bed
    {
        [Key]
        public Guid BedID { get; set; }
        public string BedNum { get; set; }

        [ValidateNever]
        ICollection<BoardingHouse> BoardingHouses { get; set; }
    }
}
