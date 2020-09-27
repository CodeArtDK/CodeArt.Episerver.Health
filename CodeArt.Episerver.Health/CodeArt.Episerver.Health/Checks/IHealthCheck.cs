using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeArt.Episerver.Health.Checks
{
    public interface IHealthCheck
    {
        string Name { get; }

        //Defined in CheckGroups
        string Group { get; }

        //status and status text
        HealthStatusType Status { get; }

        string StatusText { get; }

        //Last run, last status
        DateTime LastRun { get; }

        //has changed
        bool HasChanged { get; }

        //RunCheck - sets status, status text
        void PerformCheck();

    }
}