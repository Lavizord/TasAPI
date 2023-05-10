using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPOCO;
// TODO: Limpar este ficheiro. Organziar.

public static class AppConfig
{
    // Retorna WebApp com serviços configurados.
    // App deve depois ser configurada / adicionado endpoints e iniciada .Run()
    public static WebApplication ConfigApp(WebApplication app)
    {
        app = ConfigSwagger(app);
        return app;
    }

    private static WebApplication ConfigSwagger(WebApplication app)
    {
        // Estas duas linhas podem estar wraped no if in development statement.
        // Swagger fica disiponivel em: http://localhost:<portNumber>/swagger/
        app.UseSwagger();
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        return app;
    }
}