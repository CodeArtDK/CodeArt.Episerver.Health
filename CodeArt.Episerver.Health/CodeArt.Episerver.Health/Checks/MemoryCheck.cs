using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeArt.Episerver.Health.Checks
{
    public class MemoryCheck : HealthCheckBase
    {
        public override string Name => "Memory";

        public override string Group => CheckGroups.ENVIRONMENT;

        public override CheckResult PerformCheck()
        {
            //Check used memory, compare to available memory
            long memused = Environment.WorkingSet;
            string memusedstr = (memused / (1024 * 1024) + " MB");

            
            return CreateCheckResult(statusText:$"{memusedstr} of memory used.");
        }
    }
}
