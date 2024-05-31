using Staff_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//*********************** Add services to the container.***********************
builder.Services.AddSingleton<IStaffService, StaffService>();
//*********************** Add services to the container end.***********************

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
