using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Expensely.Swagger.Extensions;

public static class ApplicationBuilder
{
    public static IApplicationBuilder UseSwagger(
        this IApplicationBuilder app,
        IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var desc in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", $"Version {desc.ApiVersion}");
                options.DefaultModelsExpandDepth(-1);
            }
        });

        return app;
    }
}