using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess.Models
{
    public record DbProviderModel
    {
        public string DbSchema { get; set; } = "[dbo]";
        public string ConnectionString { get; set; }
    }
}
