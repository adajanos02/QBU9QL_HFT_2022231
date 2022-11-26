using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2022231.Models
{
    public class Motorcycle
    {
        public Motorcycle(int motoId, string model, int engineCapacity, int horsePower, int brandId)
        {
            MotoId = motoId;
            Model = model;
            EngineCapacity = engineCapacity;
            HorsePower = horsePower;
            BrandId = brandId;
            
        }
        public virtual ICollection<Riders> Riders { get; set; }
        public Motorcycle()
        {
            Riders = new HashSet<Riders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MotoId { get; set; }

        [Required]
        [StringLength(10)]
        public string Model { get; set; }

        public int EngineCapacity { get; set; }
        
        public int HorsePower { get; set; }
        [NotMapped]
        public virtual Brands Brands { get; set; }

        [ForeignKey(nameof(Brands))]
        public int BrandId { get; set; } 
        
    }
}
