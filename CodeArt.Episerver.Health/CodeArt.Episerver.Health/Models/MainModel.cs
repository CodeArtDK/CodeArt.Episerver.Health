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
        public int TotalChecks { get; set; }

        public int ChecksNotRun { get; set; }

        public int ChecksNotOK { get; set; }

        public int Errors { get; set; }

        public List<HealthCheckAndResult> HealthChecks{ get; set; }
    }

    public class HealthCheckAndResult
    {
        public IHealthCheck HealthCheck { get; set; }

        public CheckResult LastResult { get; set; }

    }
}
