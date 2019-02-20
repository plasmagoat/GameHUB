using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Optimization;

namespace GameHUB.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class BundleConfig : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
                RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(CreateScriptBundle("~/bundle/scripts", "~/Static/js"));
            bundles.Add(CreateStyleBundle("~/bundle/styles","~/Static/css"));
        }

        private static Bundle CreateScriptBundle(string name, string serverPath)
        {
            var scriptBundle = new ScriptBundle(name);
            scriptBundle.Transforms.Add(new JsMinify());
            scriptBundle.IncludeDirectory(serverPath, "*.js");

            return scriptBundle;
        }

        private static Bundle CreateStyleBundle(string name, string serverPath)
        {
            var styleBundle = new StyleBundle(name);
            styleBundle.Transforms.Add(new CssMinify());
            styleBundle.IncludeDirectory(serverPath, "*.css");

            return styleBundle;
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}