using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class CompareArbitratorViewModel
    {
        [Key]
        public int Id { get; set; }
        public Arbitrator ArbitratorOne { get; set; }
        public Arbitrator ArbitratorTwo { get; set; }
    }
}
