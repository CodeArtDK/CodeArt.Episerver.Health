using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public abstract class HealthCheckBase : IHealthCheck
    {
        public abstract string Name { get; }

        public abstract string Group { get; }

        public HealthStatusType Status { get; set; }

        public string StatusText { get; set; }

        public DateTime LastRun { get; set; }

        public bool HasChanged { get; set; }

        public abstract void PerformCheck();
    }
}
