using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class InspectionViewModel
    {
        public List<Inspection> InspectionList { get; set; }
        public Inspection NewInspection { get; set; }
    }
}
