using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    public class Parameters
    {
        [Key]
        public string MotoId { get; set; }
        public int Engine_Capacity { get; set; }
        public int Horsepower { get; set; }
        public int Stroke { get; set; }
    }
}
