using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Natification
    {
        public int NatificationID { get; set; }
        public string NatificationType { get; set; }
        public string NatificationTypeSembol { get; set; }
        public string NatificationTypeColor { get; set; }
        public string NatificationDetails { get; set; }
        public bool NatificationStatus { get; set; }
        public DateTime NatificationDate { get; set; }
    }
}
