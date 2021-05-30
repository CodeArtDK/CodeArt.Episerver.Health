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

        public void CheckSingle(string fullname)
        {
            var obj=this.HealthChecks.Where(hc => hc.FullName == fullname).FirstOrDefault();
            if (obj != null)
            {
                var res = obj.PerformCheck();
                SaveResults(res);
            }
        }

        public HealthService()
        {
            var lst = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && typeof(IHealthCheck).IsAssignableFrom(t))).Select(s => ServiceLocator.Current.GetInstance(s)).ToList(); //Activator.CreateInstance(s)

            HealthChecks =lst.Cast<IHealthCheck>().ToList();
        }

    }
}