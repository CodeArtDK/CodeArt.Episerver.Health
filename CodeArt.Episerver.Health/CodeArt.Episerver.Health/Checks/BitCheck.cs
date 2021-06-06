using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public class BitCheck : HealthCheckBase
    {
        public override string Name => "64Bit Check";

        public override string Group => CheckGroups.ENVIRONMENT;

        public override CheckResult PerformCheck()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                if (!Environment.Is64BitProcess)
                {
                    return base.CreateCheckResult(HealthStatusType.Performance, "Episerver is hosted on a 64 bit operating system, but is not taking advantage of it, since it is not running as a 64 bit process");
                }
                else return base.CreateCheckResult(HealthStatusType.OK, "Running well on 64bit");
            } else
            {
                return base.CreateCheckResult(HealthStatusType.Performance, "To optimize performance run on a 64bit system.");
            }
        }
    }
}
