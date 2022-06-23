using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.Shared.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public DateTime? FirstCheckDate { get; set; }
        public DateTime? CheckDate { get; set; }
        public DateTime? NextCheckDate { get; set; }
        public bool IsCheckPassed { get; set; }
        public string Image { get; set; }
        public bool HasValidInspection { get => IsInspectionValid(); }

        private bool IsInspectionValid()
        {
            return IsCheckPassed && NextCheckDate.HasValue && NextCheckDate.Value.Date >= DateTime.Now.Date;
        }
    }
}
