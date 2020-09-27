using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public class CompilationCheck : HealthCheckBase
    {
        public override string Name => "Compilation" ;

        public override string Group => CheckGroups.ENVIRONMENT;

        public override void PerformCheck()
        {
            //Check OptimizeCompilations and if it is debug

        }
    }
}
