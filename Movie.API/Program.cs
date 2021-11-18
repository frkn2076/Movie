using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movie.API;
using Movie.API.Filters;
using Movie.Business;
using Movie.Business.Gateway.IMDB;
using Movie.DataAccess;
using Hangfire;
using Hangfire.MemoryStorage;
using Movie.API.Job;
using Movie.Business.Notifier;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelStateAttribute));
})
.AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Movie API",
        Description = "An ASP.NET Core Web API for managing watchlist of the user"
    });
    opt.EnableAnnotations();
});

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});

builder.Services.AddDbContext<AppDBContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDBContext))));
builder.Services.AddScoped<IMovieManager, MovieManager>();

builder.Services.AddHttpClient<IImdbConsumer, ImdbConsumer>(client => client.BaseAddress = new Uri(builder.Configuration["Services:IMDB:BaseUrl"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Map("/error", (HttpContext context) => Results.Problem(context.Features.Get<IExceptionHandlerFeature>()?.Error.Message, statusCode: 500));

Mapper.MapsterInit();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireServer();

HangfireJobs.Init();

Batch.Configure(builder.Services.BuildServiceProvider().GetService<IMovieManager>());

app.Run();
