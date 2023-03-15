using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supplier.Project.Core.MappingProfiles;
using Supplier.Project.Core.Services;
using Supplier.Project.Persistence.DbContexts;
using Supplier.Project.Persistence.Repositories;
using Supplier.Project.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISupplierRepository,SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new SupplierProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policyBuilder => policyBuilder.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader()));

var app = builder.Build();

//Seed database
AppDbInitializer.Seed(app);
app.UseCors();

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
