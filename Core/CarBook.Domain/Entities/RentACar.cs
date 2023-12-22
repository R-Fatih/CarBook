﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACar
    {
        public int RentACarId { get; set; }
        public int LocationId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
        public Location Location { get; set; }
        public Car Car { get; set; }
    }
}
