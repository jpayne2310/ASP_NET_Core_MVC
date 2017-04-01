using System;
using System.ComponentModel.DataAnnotations;

namespace SE406_Payne.Models
{
    public class Inspection
    {
        [Required(ErrorMessage = "Inspection ID is required")]
        public Guid InspectionId { get; set; }

        [Required(ErrorMessage = "Bridge ID is required")]
        public Guid BridgeId { get; set; }

        [Required(ErrorMessage = "Inspector ID is required")]
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Inspection Date is required")]
        public DateTime InspectionDate { get; set; }

        [Required(ErrorMessage = "Deck Inspection Code ID is a required Field")]
        public Guid DeckInspectionCodeId { get; set; }

        [Required(ErrorMessage = "SuperstructureInspectionCodeId is required")]
        public Guid SuperstructureInspectionCodeId { get; set; }

        [Required(ErrorMessage = "Superstructure Inspection Code ID is required")]
        public Guid SubstructureInspectionCodeId { get; set; }

        public string InspectionNotes { get; set; }
    }
}
