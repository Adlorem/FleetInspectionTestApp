using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.Shared.Models
{
    public class InspectionModel
    {
        public int VehicleId { get; set; }
        public DateTime CheckDate { get; set; }
        public DateTime NextCheckDate { get; set; }
        public bool IsCheckPassed { get; set; }
    }
}
