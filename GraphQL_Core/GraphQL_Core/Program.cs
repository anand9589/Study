using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL_Core.Contracts;
using GraphQL_Core.Entities.Context;
using GraphQL_Core.GraphQL.GraphQLSchema;
using GraphQL_Core.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("sqlConString");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<AppSchema>();

builder.Services.AddGraphQL().AddSystemTextJson().AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);
builder.Services.AddControllers()
        .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
app.MapControllers();

app.Run();
