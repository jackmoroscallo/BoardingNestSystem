using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BoardingNestSystem.Models
{
    public class BoardingHouse
    {
        [Key]
        public Guid BoardingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
        public string OwnerNumber { get; set; }
        public decimal Price { get; set; }
        public Guid BedID { get; set; }
        public bool HasActiveReservation { get; set; }

        [ValidateNever]
        public Bed Bed { get; set; }

        [ValidateNever]
        public ICollection<Reservation> Reservations { get; set;}
    }
}
