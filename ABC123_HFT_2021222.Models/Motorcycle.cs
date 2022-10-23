using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    public class Motorcycle
    {
        [Key]
        [ForeignKey(nameof(Parameters))]
        public string MotoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int? Price { get; set; }

        [NotMapped]
        public virtual Colours Colours { get; set; }

        [NotMapped]
        public virtual Parameters Parameters { get; set; }

        [ForeignKey(nameof(Colours))]
        public int ColourId { get; set; }
        public DateTime Vintage { get; set; }
    }
}
