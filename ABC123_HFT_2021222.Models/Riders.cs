using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    public class Riders
    {
        [Key]
        public int RiderId { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        [NotMapped]
        public virtual Motorcycle Motorcycle { get; set; }
        [ForeignKey(nameof(Motorcycle))]
        public int MotoId { get; set; }

    }
}
