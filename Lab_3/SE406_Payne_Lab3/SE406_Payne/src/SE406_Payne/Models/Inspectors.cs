using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class Inspectors
    {
        public Guid InspectorId { get; set; }
        public string InspectorFirst { get; set; }
        public string InspectorLast { get; set; }
        public string InspectorOrg { get; set; }
        public DateTime InspectorCertEffective { get; set; }
        public DateTime InspectorCertExpires { get; set; }
    }
}
