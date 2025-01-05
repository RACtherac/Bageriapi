//Om denna ser lite konstig ut är för jag kunnde inte få imigration att funka detta är min tredje kod den första så glömde jag att göra imigration min andra ville inte Nuget funka jag ber om ursäkt. 
//Allt är typ copy pasta från min första kod.
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BakeryContext>(options =>
    options.UseSqlite("Data Source=Bakery.db"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
