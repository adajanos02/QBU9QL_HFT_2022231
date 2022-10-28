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
        public string MotoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int EngineCapacity { get; set; }

        public int HorsePower { get; set; }

        public virtual Brands Brands { get; set; }

        [ForeignKey(nameof(Brands))]
        public int BrandId { get; set; }    
    }
}
