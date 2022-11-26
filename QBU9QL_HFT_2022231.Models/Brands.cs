using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2022231.Models

{
    public class Brands
    {
        public Brands(int brandId, string name, int establishmentYear, int numbOfSoldProd)
        {
            BrandId = brandId;
            Name = name;
            EstablishmentYear = establishmentYear;
            NumbOfSoldProd = numbOfSoldProd;
        }
        public virtual ICollection<Motorcycle> Motorcycles { get; set; }
        public Brands()
        {
            Motorcycles = new HashSet<Motorcycle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public int NumbOfSoldProd { get; set; }
    }
}
