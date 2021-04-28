using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class Evidence
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TheoryEvent")]
        public int TheoryEventId { get; set; }
        public TheoryEvent TheoryEvent { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public string EvidenceExhibitNumber { get; set; }

    }
}
