using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public class ScheduledJobsCheck : HealthCheckBase
    {
        public override string Name => "Scheduled Jobs";

        public override string Group => CheckGroups.ENVIRONMENT;

        public override CheckResult PerformCheck()
        {
            //Go through each scheduled job
            //Check if has been run, how long it was running, if it's currently running, if it crashed.

            return CreateCheckResult();
        }
    }
}
