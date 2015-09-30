using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Kyrt;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        private static readonly Lazy<string> Root = new Lazy<string>(() => GetFullRoot(@"..\scripts"));

        private static string GetFullRoot(string root)
        {
            var applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var fullRoot = Path.GetFullPath(Path.Combine(applicationBase, root));
            if (!fullRoot.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                fullRoot += Path.DirectorySeparatorChar;
            }
            return fullRoot;
        }

        private string GetFullPath(string path)
        {
            var fullPath = Path.GetFullPath(Path.Combine(Root.Value, path));
            if (!fullPath.StartsWith(Root.Value, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            return fullPath;
        }

        public void Configuration(IAppBuilder app)
        {
            app.Run(async context =>
            {
                if (!(context.Request.Path.ToString().Length > 1))
                    return;

                var scriptName = GetFullPath($"{context.Request.Path.ToString().Remove(0, 1)}.ps1");



                if (scriptName != null && !File.Exists(scriptName))
                {
                    return;
                }
                context.Response.ContentType = "text/plain";

                var exitCode = Executor.Run(
                    async (s) => await context.Response.WriteAsync(s + Environment.NewLine),
                    async (s) => await context.Response.WriteAsync(s + Environment.NewLine),
                    "powershell.exe", "-NoProfile", "-NoLogo", "-ExecutionPolicy Unrestricted", $"-File {scriptName}");

                await context.Response.WriteAsync(exitCode.ToString());

            });
        }
    }
}
