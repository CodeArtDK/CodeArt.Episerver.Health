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

        string FullName { get; }
        int SortOrder { get; }

        //RunCheck - sets status, status text
        CheckResult PerformCheck();

        /// <summary>
        /// Tries to fix it. 
        /// </summary>
        /// <param name="checkResult">Result from the check</param>
        /// <returns>true, if fix is successful</returns>
        bool Fix(CheckResult checkResult);

    }
}