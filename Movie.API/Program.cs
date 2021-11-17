using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Movie.Business;
using Movie.Business.Gateway;
using Movie.Business.Gateway.Wikipedia;
using Movie.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDBContext))));
builder.Services.AddScoped<IMovieManager, MovieManager>();

builder.Services.AddHttpClient<IImdbConsumer, ImdbConsumer>(client => client.BaseAddress = new Uri(builder.Configuration["Services:IMDB"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Map("/error", (HttpContext context) => Results.Problem(context.Features.Get<IExceptionHandlerFeature>()?.Error.Message, statusCode: 500));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
