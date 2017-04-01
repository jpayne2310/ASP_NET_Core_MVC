using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class InspectionCode
    {
        public Guid InspectionCodeId { get; set; }
        public string InspectionCodeName { get; set; }
        public string InspectionCodeDesc { get; set; }
    }
}
