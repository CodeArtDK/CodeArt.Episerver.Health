using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    /// <summary>
    /// Checks version of Episerver
    /// </summary>
    public class VersionCheck : HealthCheckBase
    {
        public override string Name => "Episerver Version Check";

        public override string Group => CheckGroups.ENVIRONMENT;

        public override CheckResult PerformCheck()
        {
            //Get Packages List
            //Fetch list from Episerver nuget feed.
            //See which packages are in old versions
            return CreateCheckResult();
        }
    }
}
