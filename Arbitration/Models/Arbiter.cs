using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class Arbiter
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CaseTheory")]
        public int CaseTheoryId { get; set; }
        public CaseTheory CaseTheory { get; set; }

        public int Points { get; set; }
        public string VocationalIndustry { get; set; }
        public int AwardsToCompanies { get; set; }
        public int AwardsToClaimants { get; set; }
        public bool LegalExperience { get; set; }
        public bool IsSelected { get; set; }
        public bool RelationshipsWithParties { get; set; }
        public bool HasStockInCompany { get; set; }
        public string DescriptionOfCOI { get; set; }
    }
}
