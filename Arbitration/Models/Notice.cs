using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class Notice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ConsumerClaimant")]
        public int ConsumerClaimantId { get; set; }
        public ConsumerClaimant ConsumerClaimant { get; set; }

        public string Type { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
