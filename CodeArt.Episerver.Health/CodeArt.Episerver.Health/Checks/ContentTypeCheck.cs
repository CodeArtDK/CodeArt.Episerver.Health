using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public class ContentTypeCheck : HealthCheckBase
    {
        public override string Name => "Content Types";

        public override string Group => CheckGroups.CONTENT;

        public override CheckResult PerformCheck()
        {
            //Check how many content types are there. If any of them are not used. If any are overlapping.
            return CreateCheckResult();
        }
    }
}
