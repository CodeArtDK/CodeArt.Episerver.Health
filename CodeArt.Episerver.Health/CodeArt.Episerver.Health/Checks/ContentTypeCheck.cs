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
            int pagetypes = types.Where(tp => tp.ModelType!=null && tp.ModelType.IsAssignableFrom(typeof(PageData))).Count();
            int blocktypes = types.Where(tp => tp.ModelType!=null && tp.ModelType.IsAssignableFrom(typeof(BlockData))).Count();

            //Any types specified in database and not in code?
            int typesfromdb = types.Where(tp => tp.ModelType == null).Count();

            //Types that are not used

            //Types that should inherit from each other?

            //Too many visible types to the editor?

            return CreateCheckResult(statusText:$"{pagetypes} page types and {blocktypes} blocks. {typesfromdb} types defined in database only (and not in code).");
        }

        public ContentTypeCheck(IContentTypeRepository typeRepo)
        {
            this.typeRepo = typeRepo;
        }
    }
}
