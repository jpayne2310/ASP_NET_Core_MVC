using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SE406_Payne.Models
{
    public class InspectionViewModel
    {
        public List<Inspection> InspectionList { get; set; }
        public Inspection NewInspection { get; set; }
        public List<SelectListItem> Bridges { get; set; }
        public List<SelectListItem> Inspectors { get; set; }
        public List<SelectListItem> DeckInspections { get; set; }
        public List<SelectListItem> SuperInspections { get; set; }
        public List<SelectListItem> SubInspections { get; set; }

    }
}
