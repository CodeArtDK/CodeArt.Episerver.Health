using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Hosting;

namespace CodeArt.Episerver.Health.Checks
{
    public class OptimizeCompilationCheck : HealthCheckBase
    {
        public override string Name => "Optimize Compilation" ;

        public override string Group => CheckGroups.CONFIGURATION;

        public override int SortOrder => 10;

        public override CheckResult PerformCheck()
        {
            //Check OptimizeCompilations and if it is debug
            CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
            //            if(configSection.Debug

            if (!configSection.OptimizeCompilations) return base.CreateCheckResult(HealthStatusType.Performance, "Compilations not optimized. You can increase performance by setting OptimizeCompilations to true.", true);
            else return CreateCheckResult();
            
        }

        public override bool Fix(CheckResult checkResult)
        {
            if (checkResult.CanFix)
            {
                CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
                configSection.OptimizeCompilations = true;
                
            }
            return true;
        }
    }

    public class DebugCompilationCheck : HealthCheckBase
    {
        public override string Name => "Debug Compilation";

        public override string Group => CheckGroups.CONFIGURATION;

        public override int SortOrder => 20;

        public override CheckResult PerformCheck()
        {
            //Check OptimizeCompilations and if it is debug
            CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
            //            if(configSection.Debug

            if (configSection.Debug) return CreateCheckResult(HealthStatusType.Performance, "Code is running with Debug enabled. If this is a production site you can improve it by setting debug to false.", true);
            else return CreateCheckResult();
        }
    }
}
