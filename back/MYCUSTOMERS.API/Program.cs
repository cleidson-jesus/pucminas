using MYCUSTOMERS.DOMAIN.Interfaces;
using MYCUSTOMERS.DOMAIN.Services;
using MYCUSTOMERS.INFRASTRUCTURE.Uow;
using MYCUSTOMERS.HELPERS.CustomExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClientePFService, ClientePFService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<ITelefoneService, TelefoneService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
