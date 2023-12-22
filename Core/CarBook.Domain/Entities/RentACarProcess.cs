using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarId { get; set; }
        [ForeignKey("PickUpLocation")]
        public int PickUpLocationId { get; set; }
        [ForeignKey("DropOffLocation")]
        public int DropOffLocationId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName ="Date")]
        public DateTime PickUpDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DropOffDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan PickUpTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan DropOffTime { get; set; }
        public Customer Customer { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public Car Car { get; set; }
        public string PickUpDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
