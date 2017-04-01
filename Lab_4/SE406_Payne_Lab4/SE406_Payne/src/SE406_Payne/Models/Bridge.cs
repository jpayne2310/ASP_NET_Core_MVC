using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Payne.Models
{
    public class Bridge
    {
        public Guid Bridgeid { get; set; }
        public Guid MaterialDesignId { get; set; }
        public Guid ConstructionDesignId { get; set; }
        public Guid FunctionalClassId { get; set; }
        public Guid StatusId { get; set; }
        public Guid CountyId { get; set; }
        public string NbiNumber { get; set; }
        public decimal? Rating { get; set; }
        public string RouteNumber { get; set; }
        public string City { get; set; }
        public string IntersectingFeature { get; set; }
        public string CarriedFeature { get; set; }
        public string Location { get; set; }
        public int Built { get; set; }
        public int? Reconstructed { get; set; }
        public decimal TotalLength { get; set; }
    }
}
