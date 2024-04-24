using Microsoft.Identity.Web;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration, "Blah");
//builder.Services.AddAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(conf=>{
conf.AddPolicy("alleskan", pol=>{
    pol.AllowAnyHeader();
    pol.AllowAnyOrigin();
    pol.AllowAnyMethod();
});

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("alleskan");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
