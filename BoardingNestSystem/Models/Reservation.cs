using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BoardingNestSystem.Models
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }
        public Guid BoardingHouseID { get; set; }
        public string ClientsName { get; set; }
        public string ClientsNumber { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime DateCheckOut { get; set; }
        public bool IsFinished { get; set; }
        public string Status { get; set; }

        [ValidateNever]
        public BoardingHouse BoardingHouse { get; set; }
    }
}
