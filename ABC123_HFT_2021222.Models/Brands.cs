using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public int NumbOfSold { get; set; }
    }
}
