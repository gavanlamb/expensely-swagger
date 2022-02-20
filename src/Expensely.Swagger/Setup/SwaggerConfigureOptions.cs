using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Expensely.Swagger.Setup;

public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerConfigureOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var desc in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                desc.GroupName, 
                new OpenApiInfo
                {
                    Title = Assembly.GetEntryAssembly()?.GetName().Name, 
                    Version = $"Version {desc.ApiVersion}",
                });
            var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
            options.IncludeXmlComments(xmlPath);
            options.CustomSchemaIds(x => x.FullName);
        }
        
        options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        options.OperationFilter<SecurityRequirementsOperationFilter>();
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Scheme = "bearer",
            BearerFormat = "JWT",
            Type = SecuritySchemeType.Http
        });
    }
}