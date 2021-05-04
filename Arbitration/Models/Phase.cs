using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ConsumerClaimant")]
        public int ConsumerClaimantId { get; set; }
        public ConsumerClaimant ConsumerClaimant { get; set; }

        public bool NotificationOfFiling { get; set; }
        public bool NoticeOfArbitratorSelection { get; set; }
        public bool ArbitratorsDisclosures { get; set; }
        public bool SignedOathDocument { get; set; }
        public bool AppointmentOfArbitrator { get; set; }
        public bool Schedule { get; set; }
        public bool SchedulingOrder { get; set; }
        public bool CompletionOfHearing { get; set; }
    }
}
