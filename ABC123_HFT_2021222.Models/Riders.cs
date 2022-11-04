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
        public Riders(int riderId, string name, int year, char gender, int motoId)
        {
            RiderId = riderId;
            Name = name;
            Year = year;
            Gender = gender;
            
            MotoId = motoId;
        }
        public Riders()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RiderId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public char Gender { get; set; }
        [NotMapped]
        public virtual Motorcycle Motorcycle { get; set; }
        [ForeignKey(nameof(Motorcycle))]
        public int MotoId { get; set; }

    }
}
