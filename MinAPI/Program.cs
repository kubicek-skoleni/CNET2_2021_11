using WPFTextGUI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/hello", () => "hello");

// POST -> /stats
// GET -> /stats/5
// GET -> /stats/all

app.MapGet("/stats/{id}", (int id) =>
{
    StatsResult sr = new StatsResult();
    sr.Id = id;
    sr.Source = "dummy result";
    return sr;
});


app.Run();

