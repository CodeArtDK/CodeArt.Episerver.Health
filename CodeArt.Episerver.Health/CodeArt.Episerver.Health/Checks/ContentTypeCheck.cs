using EPiServer.Core;
using EPiServer.DataAbstraction;
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

        private readonly IContentTypeRepository typeRepo;

        public override CheckResult PerformCheck()
        {
            //Check how many content types are there. If any of them are not used. If any are overlapping.
            var types=typeRepo.List().ToList();

            int pagetypes = types.Where(tp => tp.Base.ToString()=="Page").Count();
            int blocktypes = types.Where(tp => tp.Base.ToString()=="Block").Count();

            var groups=types.GroupBy(tp => tp.Base.ToString());
            var groupstring=string.Join(", ", groups.Select(grp => grp.Count().ToString() + " " + grp.Key).ToArray());

            if (pagetypes > 50) return base.CreateCheckResult(HealthStatusType.BadPractice, $"You have more than {pagetypes} page types. That can make it hard to find the right one to use. Consider refactoring.");
            if (blocktypes > 80) return base.CreateCheckResult(HealthStatusType.BadPractice, $"You have more than {blocktypes} block types. That can make it hard to find the right one to use. Consider refactoring.");
            if (pagetypes < 2) return base.CreateCheckResult(HealthStatusType.BadPractice, $"You only have {pagetypes} page types. This could indicate a site with very unstructured content.");

            //Warnings if a page has more than X properties


            //Any types specified in database and not in code?
            int typesfromdb = types.Where(tp => tp.ModelType == null).Count();

            //Types that are not used

            //Types that should inherit from each other?

            //Too many visible types to the editor?

            return CreateCheckResult(statusText:$"{groupstring}.");
        }

        public ContentTypeCheck(IContentTypeRepository typeRepo)
        {
            this.typeRepo = typeRepo;
        }
    }

    public class ContentTypeFromCodeCheck : HealthCheckBase
    {
        public override string Name => "Content Types From Code";

        public override string Group => CheckGroups.CONTENT;

        private readonly IContentTypeRepository typeRepo;

        public override CheckResult PerformCheck()
        {
            //Check how many content types are there. If any of them are not used. If any are overlapping.
            var types = typeRepo.List().ToList();

            var groups = types.GroupBy(tp => tp.Base.ToString());
            var groupstring = string.Join(", ", groups.Select(grp => grp.Count().ToString() + " " + grp.Key).ToArray());

            //Warnings if a page has more than X properties


            //Any types specified in database and not in code?
            int typesfromdb = types.Where(tp => tp.ModelType == null).Count();

            var orphans=types.Where(tp => tp.ModelType != null).SelectMany(tp => tp.PropertyDefinitions).Where(pd => !pd.ExistsOnModel).ToList();

            if (orphans.Count > 0)
            {
                string example = orphans.Select(o => o.Name + " on " + typeRepo.Load(o.ContentTypeID).Name).First();
                return CreateCheckResult(HealthStatusType.Fault, $"You have {orphans.Count} properties not defined in code on content types that are defined in code. For example {example}.");

            }

            return CreateCheckResult(statusText: $"{typesfromdb} types defined in database only (and not in code).");
        }

        public ContentTypeFromCodeCheck(IContentTypeRepository typeRepo)
        {
            this.typeRepo = typeRepo;
        }
    }
}
