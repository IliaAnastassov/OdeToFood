using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBowerComponents(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "bower_components");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/bower_components";
            options.FileProvider = fileProvider;

            app.UseStaticFiles(options);

            return app;
        }
    }
}
