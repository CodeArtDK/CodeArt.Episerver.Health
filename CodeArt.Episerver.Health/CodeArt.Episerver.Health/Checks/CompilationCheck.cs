using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CodeArt.Episerver.Health.Checks
{
    public class OptimizeCompilationCheck : HealthCheckBase
    {
        public override string Name => "Optimize Compilation" ;

        public override string Group => CheckGroups.CONFIGURATION;

        public override string StatusText => "Compilations not optimized. You can increase performance by setting OptimizeCompilations to true.";

        public override int SortOrder => 10;

        public override void PerformCheck()
        {
            //Check OptimizeCompilations and if it is debug
            CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
            //            if(configSection.Debug

            if (!configSection.OptimizeCompilations) this.Status = HealthStatusType.Performance;
            else this.Status = HealthStatusType.OK;  
        }
    }

    public class DebugCompilationCheck : HealthCheckBase
    {
        public override string Name => "Debug Compilation";

        public override string Group => CheckGroups.CONFIGURATION;

        public override string StatusText => "Code is running with Debug enabled. If this is a production site you can improve it by setting debug to false.";

        public override int SortOrder => 20;

        public override void PerformCheck()
        {
            //Check OptimizeCompilations and if it is debug
            CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");
            //            if(configSection.Debug

            if (configSection.Debug) this.Status = HealthStatusType.Performance;
            else this.Status = HealthStatusType.OK;
        }
    }
}
