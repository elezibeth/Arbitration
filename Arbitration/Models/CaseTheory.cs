using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class CaseTheory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ConsumerClaimant")]
        public int ConsumerClaimantId { get; set; }
        public ConsumerClaimant ConsumerClaimant { get; set; }

        public string LawBroken { get; set; }
        public string HowLawBroken { get; set; }
        public string Perpetrator { get; set; }
        public string Location { get; set; }
        public string ProofOfIntent { get; set; }
        public bool InInitiation { get; set; }
        public bool InArbitratorInvitation { get; set; }
        public bool InArbitratiorAppointment { get; set; }
        public bool InPreliminaryHearing { get; set; }
        public bool InAward { get; set; }
    }
}
