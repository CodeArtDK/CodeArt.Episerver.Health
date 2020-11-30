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

        public virtual int SortOrder { get => 100; }

        public string FullName { get => this.GetType().FullName;}

        protected virtual CheckResult CreateCheckResult(HealthStatusType statusType=HealthStatusType.OK, string statusText="", bool canFix = false, string statusCode = "")
        {
            CheckResult cr = new CheckResult();
            cr.CheckTime = DateTime.Now;
            cr.CheckType = FullName;
            cr.CanFix = canFix;
            cr.Status = statusType;
            cr.StatusText = statusText;
            cr.StatusCode = statusCode;
            return cr;
        }

        public virtual bool Fix(CheckResult checkResult)
        {
            return false;
        }

        public abstract CheckResult PerformCheck();
    }
}
