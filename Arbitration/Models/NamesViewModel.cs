using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class NamesViewModel
    {
        [Key]
        public int Id { get; set; }

        public string ArbitratorName { get; set; }
        public string SecondArbitratorName { get; set; }
    }
}
