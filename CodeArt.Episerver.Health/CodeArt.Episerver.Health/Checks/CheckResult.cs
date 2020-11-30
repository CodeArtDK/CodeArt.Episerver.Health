using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.Health.Checks
{
    public class CheckResult : IDynamicData
    {
        public Identity Id { get; set; }

        public DateTime CheckTime { get; set; }

        public string CheckType { get; set; }

        public HealthStatusType Status { get; set; }

        public string StatusText { get; set; }

        public string StatusCode { get; set; }

        public bool CanFix { get; set; }

        //Severity?

        public CheckResult()
        {
            CheckTime = DateTime.Now;
        }
    }
}
