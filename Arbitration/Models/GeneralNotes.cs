using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class GeneralNotes
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CaseTheory")]
        public int CaseTheoryId { get; set; }
        public CaseTheory CaseTheory { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
