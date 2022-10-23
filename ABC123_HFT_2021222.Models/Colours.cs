using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    public class Colours
    {
        [Key]
        public int ColourId { get; set; }
        [Required]
        public string ColourName { get; set; }
        public string PaintWork { get; set; }
        public bool OriginalPaint { get; set; }
    }
}
