using CodeArt.Episerver.Health.Checks;
using EPiServer.Data.Dynamic;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiHealthCheck.modules._protected.HealthCheck
{
    [ServiceConfiguration(ServiceType = typeof(HealthService), Lifecycle = ServiceInstanceScope.Singleton)]
    public class HealthService
    {
        //Find all registered health checks and go through them (based on UI).

        /* Check ideas:
         * Status of scheduled jobs (and long running ones)
         * Go through add-ons and find outdated ones (or ones on a list with known issues)
         * Check config and compilation is not running in debug mode
         * Check if public errors are visible
         * Ping various pages on the site and check for server errors
         * Investigate log
         * Security check - look at logins - how many with admin access? Any inactive?
         * Check performance for various pages
         * Find connection
         * Connectivity check to internet
         * Changes in amount of 404 calls?
         * Content models - too many / too few?
         * Available memory vs used
         * Database version / connections?
         * Validate email settings are valid
         * Trace mode should be disabled
         * Meta-tag for http headers
         * Cookie check
         * https check
         * content provider checks
         * cache checks  - outputcaching
         * 
         * Security checks - roles
         * ACL checks - any lower pages pages with specific accessibility higher than parents?
         * Content checks - Blocks that are not used?
         * 
         * 
         * Commerce checks
         * 
         * Support Potential to Fix issues found.
         * 
         * 
         * 
         * Also:
         * Scheduled job to run checks and report if something changes
         * ability to ignore/accept a status in future reports
         * Some checks should support "Fix this" call
         * 
         * */
        public List<IHealthCheck> HealthChecks { get; set; }


        //Use DDS to store check results

        public CheckResult GetLatestResultFrom(IHealthCheck hc)
        {
            string nm = hc.GetType().FullName;
            return GetStore().Items<CheckResult>().Where(cr => cr.CheckType == nm).OrderByDescending(cr => cr.CheckTime).FirstOrDefault();
        }

        private DynamicDataStore GetStore()
        {
            var store = DynamicDataStoreFactory.Instance.CreateStore(typeof(CheckResult));
            return store;
        }

        public void SaveResults(CheckResult result)
        {
            GetStore().Save(result);
        }

        public void CheckAll()
        {
            foreach(var check in this.HealthChecks)
            {
                var res = check.PerformCheck();
                SaveResults(res);
            }
        }

        public HealthService()
        {
            var lst = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && typeof(IHealthCheck).IsAssignableFrom(t))).Select(s => Activator.CreateInstance(s)).ToList();

            HealthChecks =lst.Cast<IHealthCheck>().ToList();
        }

    }
}