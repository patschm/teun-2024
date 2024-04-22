using ACME.Api.Reviews.DTO;
using ACME.Api.Reviews.Mapping;
using ACME.Api.Reviews.Validators;
using ACME.Database.EntityFramework;
using ACME.Database.EntityFramework.Repositories;
using ACME.Domain.Reviews.Exceptions;
using ACME.Domain.Reviews.Repositories;
using ACME.Domain.Reviews.ValueObjects;
using ACME.Infrastructure.Reviews.Commands;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// De Dependency Injector
builder.Services.AddDbContext<ShopContext>(opts => {
    var constr = builder.Configuration.GetConnectionString("Database");
    opts.UseSqlServer(constr);
});
builder.Services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
builder.Services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
//builder.Services.AddScoped<IValidator<ReviewDTO>, ReviewValidator>();
builder.Services.AddMediatR(conf => {
    conf.RegisterServicesFromAssemblies(
        ACME.Infrastructure.Reviews.AssemblyReference.Assembly
        );
});
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

app.MapGet("/reviews", async ([FromServices] ISender sender, [FromQuery] int page = 1, [FromQuery] int amount = 10) => {
    var result = await sender.Send(new ReadReviewsCommand(new ReviewParameters(page, amount)));
    return Results.Ok(result.Select(r=>r.ToDTOReview()));
})
.WithName("GetReviews")
.WithOpenApi();

app.MapGet("/reviews/{id:long}", async ([FromServices] ISender sender, [FromRoute]long id) =>
{
    try
    {
        //var handler = new ACME.Infrastructure.Reviews.Handlers.ReadReviewCommandHandler(app.Services.GetRequiredService<IReviewReadRepository>());
        //var result = await  handler.Handle(new ReadReviewCommand(id));
        var result = await sender.Send(new ReadReviewCommand(id));
        return Results.Ok(result.ToDTOReview());
    }
    catch (ReviewNotFoundException)
    {
        return Results.NotFound(id);
    }  
})
.WithName("GetReview")
.WithOpenApi();

app.Run();

// For Integration Tests
public partial class Program { }
