#pragma warning disable CA1506

using Habrbr.Application.Extensions;
using Habrbr.Infrastructure.Persistence.Extensions;
using Habrbr.Presentation.Http.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using habrbr.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);

IMvcBuilder mvcBuilder = builder.Services.AddControllers().AddNewtonsoftJson();
mvcBuilder.AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("habrbr.Infrastructure.Persistence")));

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

await app.RunAsync();