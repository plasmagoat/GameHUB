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
        }

        private static Bundle CreateScriptBundle(string name, string serverPath)
        {
            var scriptBundle = new ScriptBundle(name);
            scriptBundle.Transforms.Add(new JsMinify());
            scriptBundle.IncludeDirectory(serverPath, "*.js");

            return scriptBundle;
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}