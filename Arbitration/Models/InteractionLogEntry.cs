using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class InteractionLogEntry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PartyInvolved")]
        public int PartyInvolvedId { get; set; }
        public PartyInvolved PartyInvovled { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
