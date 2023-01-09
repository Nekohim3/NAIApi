using Microsoft.EntityFrameworkCore;
using NAIApi;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(_ =>
                                                    {
                                                        _.SerializerSettings.ReferenceLoopHandling      = ReferenceLoopHandling.Serialize;
                                                        _.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                                                        _.SerializerSettings.NullValueHandling          = NullValueHandling.Ignore;
                                                    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TagContext>(_ =>
                                          {
                                              _.UseNpgsql(builder.Configuration.GetConnectionString("TagDbConnection"));
                                          });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
