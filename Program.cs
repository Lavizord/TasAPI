using Entities.Models;
using DTOs.Scene;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Endpoints.Groups;

var MyAllowSpecificOrigins = "_CorsPolicyLocalhost"; 

// Criação e Configuração da APP.
var app = AppBuilder.GetApp(args, MyAllowSpecificOrigins);
app = AppConfig.ConfigApp(app);

var mapper = app.Services.GetService<IMapper>();
if (mapper == null)
{
    throw new InvalidOperationException(
      "Mapper not found");
}

app.MapGroup("/scenes")
    .Scenes(mapper)
    .WithTags("Scenes");

app.MapGroup("/items")
    .Items(mapper)
    .WithTags("Items");
      
app.UseCors(MyAllowSpecificOrigins);
app.Run();