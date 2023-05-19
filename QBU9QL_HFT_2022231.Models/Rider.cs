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
    public class Rider
    {
        public Rider(int riderId, string name, int year, char gender, int motoId)
        {
            RiderId = riderId;
            Name = name;
            Year = year;
            Gender = gender;
            
            MotoId = motoId;
        }
        public Rider()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RiderId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public char Gender { get; set; }
        [NotMapped]
        
        public virtual Moto Motorcycle { get; set; }
        [ForeignKey(nameof(Motorcycle))]
        public int MotoId { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    else
        //    {
        //        return (obj as Riders).RiderId == this.RiderId &&
        //            (obj as Riders).Name == this.Name &&
        //            (obj as Riders).Year == this.Year &&
        //            (obj as Riders).Gender == this.Gender &&
        //            (obj as Riders).MotoId == this.MotoId;
        //    }
        //}
        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(this.RiderId, this.Name, this.Year, this.Gender, this.MotoId);
        //}

    }
}
