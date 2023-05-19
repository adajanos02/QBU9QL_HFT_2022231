using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2022231.Models

{
    public class Brand
    {
        public Brand(int brandId, string name, int establishmentYear, int numbOfSoldProd)
        {
            BrandId = brandId;
            Name = name;
            EstablishmentYear = establishmentYear;
            NumbOfSoldProd = numbOfSoldProd;
        }
        [JsonIgnore]
        public virtual ICollection<Moto> Motorcycles { get; set; }
        public Brand()
        {
            Motorcycles = new HashSet<Moto>();
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
