using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CodeArt.Episerver.Health.Checks
{
    public class CustomErrorsCheck : HealthCheckBase
    {
        public override string Name => "Custom Errors";

        public override string Group => CheckGroups.CONFIGURATION;

        public override CheckResult PerformCheck()
        {
            CustomErrorsSection configSection = (CustomErrorsSection)ConfigurationManager.GetSection("system.web/customErrors");
            if (configSection.Mode == CustomErrorsMode.Off)
            {
                return CreateCheckResult(HealthStatusType.Warning, "Custom errors are off. You should never have them off in production.");
            }

            return CreateCheckResult(statusText: $"Custom errors are {configSection.Mode.ToString()}");
        }
    }
}
