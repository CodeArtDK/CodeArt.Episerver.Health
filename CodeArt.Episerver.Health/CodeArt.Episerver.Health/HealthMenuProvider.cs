using EPiServer.Security;
using EPiServer.Shell;
using EPiServer.Shell.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeArt.Episerver.Health
{
    [MenuProvider]
    public class HealthMenuProvider : IMenuProvider
    {
        const string ModuleName = "CodeArt.Episerver.Health";

        const string HealthTitle = "HealthCheck";
        const string ConsolePath = "global/cms/Health";
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var console = CreateUrlMenuItem(HealthTitle, ConsolePath, Paths.ToResource(ModuleName, "Main"));
            

            yield return console;

        }


        protected virtual UrlMenuItem CreateUrlMenuItem(string title, string logicalPath, string resourcePath)
        {
            return new UrlMenuItem(title, logicalPath, resourcePath)
            {
                IsAvailable = request => PrincipalInfo.HasAdminAccess
            };
        }
    }
}