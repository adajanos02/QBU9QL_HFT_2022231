﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace QBU9QL_HFT_2022231.Models
{
    public class Moto
    {
        public Moto(int motoId, string model, int engineCapacity, int horsePower, int brandId)
        {
            MotoId = motoId;
            Model = model;
            EngineCapacity = engineCapacity;
            HorsePower = horsePower;
            BrandId = brandId;
            
        }
        [JsonIgnore]
        public virtual ICollection<Rider> Riders { get; set; }
        public Moto()
        {
            Riders = new HashSet<Rider>();
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
       
        public virtual Brand Brands { get; set; }

        [ForeignKey(nameof(Brands))]
        public int BrandId { get; set; }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    else
        //    {
        //        return (obj as Motorcycle).MotoId == this.MotoId &&
        //            (obj as Motorcycle).Model == this.Model &&
        //            (obj as Motorcycle).EngineCapacity == this.EngineCapacity &&
        //            (obj as Motorcycle).HorsePower == this.HorsePower &&
        //            (obj as Motorcycle).BrandId == this.BrandId;
        //    }
        //}
        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(this.MotoId, this.Model, this.EngineCapacity, this.HorsePower, this.BrandId);
        //}

    }
}
