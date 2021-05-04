using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Arbitration.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ConsumerClaimant")]
        public int ConsumerClaimantId { get; set; }
        public ConsumerClaimant ConsumerClaimant { get; set; }

        public string Item { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime AlarmDate { get; set; }



    }
}
