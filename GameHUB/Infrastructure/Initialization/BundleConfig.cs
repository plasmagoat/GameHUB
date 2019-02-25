using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System;
using System.Web.Optimization;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Resolvers;

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
            BundleResolver.Current = new CustomBundleResolver();
            bundles.Add(CreateScriptBundle("~/bundle/scripts", "~/Static/js"));
            bundles.Add(CreateStyleBundle("~/bundle/styles","~/Static/css"));
            bundles.Add(CreateSassBundle("~/bundle/sass", "~/Static/css"));
        }

        private static Bundle CreateSassBundle(string name, string serverPath)
        {
            var sassBundle = new CustomStyleBundle(name);
            sassBundle.IncludeDirectory(serverPath, "*.scss");

            return sassBundle;
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