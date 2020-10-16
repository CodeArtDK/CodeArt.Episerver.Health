using CodeArt.Episerver.Health.Checks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Models
{
    public class MainModel
    {
        public List<IHealthCheck> HealthChecks{ get; set; }
    }
}
