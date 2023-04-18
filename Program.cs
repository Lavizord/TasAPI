using Microsoft.OpenApi.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;

// TODO: Ver se existe melhor forma dee configurar isto, só quis tirar o código da frente.

void ConfigBuilderServices(IServiceCollection services)
{
    // TODO: Ler isto da AppSettings
    // TODO: Não deviamos usar TrustServerCertificate=True, no futuro alterar.
    services.AddDbContext<TasDB>(opts => 
        opts.UseSqlServer("Server=DESKTOP-2FSRJ25\\SQLEXPRESS;Database=TakeAStep01;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
    ));    
    // Builder.Services code taken from :
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio-code
    // Seems to be boilerplate code for swagger integration.
    //services.AddControllers();    // Não precisamos porque não vamos usar Controllers para os endpoints. Its new.
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Take a Step API",
        Description = "Taking the steps you love",
        Version = "v1" });
    });
}

void ConfigSwagger(WebApplication app)
{
    // Estas duas linhas podem estar wraped no if in development statement.
    // Swagger fica disiponivel em: http://localhost:<portNumber>/swagger/
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

// Minimal WebApp começa aqui.
var builder = WebApplication.CreateBuilder(args);
ConfigBuilderServices(builder.Services);
// Damos Build da app, esta linha tem de ser depois da config do builder.
var app = builder.Build();
ConfigSwagger(app);

app.MapGet("/", () => "Hello World!")
.WithName("GetWeatherForecast") // TODO: Explorar melhor :  https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/openapi?view=aspnetcore-7.0
.WithOpenApi(operation => new(operation)    // Não parece estar a funcionar corretamente.
{
    Summary = "This is a summary",
    Description = "This is a description"
});

// TODO: Estudar melhor os Posts, o facto de termos a chave a ser criada automáticamente pode dar problemas com os IDS.
//      ver qual é a melhor abordagem.

// TODO: Criar os grupos de endpoints.
// 1. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0#route-groups
// 2. https://anthonygiretti.com/2023/03/16/asp-net-core7-use-endpoint-groups-to-manage-minimal-apis-versioning/
// TODO: Scene Groups
// TODO: Scene filters
app.MapGet("/scenes", async (TasDB db) =>
{
    await db.Scenes.Include("SceneEffect").ToListAsync();   // TODO: Testar se isto funciona.
});
app.MapPost("/scenes", async (TasDB db, Scene scene) =>
{
    await db.Scenes.AddAsync(scene);
    await db.SaveChangesAsync();
    return Results.Created($"/scene/{scene._Id}", scene);
});
app.MapGet("/sceneseffect", async (TasDB db) =>
{
    await db.SceneEffects.ToListAsync();
});

//TODO: Choice Groups
//TODO: Choice Filters
app.MapGet("/choice", async (TasDB db) => 
{
    await db.Choices.ToListAsync();
});

app.Run();