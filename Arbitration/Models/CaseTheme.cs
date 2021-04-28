using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class CaseTheme
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CaseTheory")]
        public int CaseTheoryId { get; set; }
        public CaseTheory CaseTheory { get; set; }
        public string ArbiterChair { get; set; }
        public string CoreTruth { get; set; }
    }
}
