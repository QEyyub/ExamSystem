using ExamSystem.Application.CQRS.Exams.Commands.CreateExam;
using ExamSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateExamCommandHandler).Assembly);
});

builder.Services.AddInfrastructure(builder.Configuration);

// --- Burada CORS siyasətini əlavə et ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
// --------------------------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- Burada CORS middleware əlavə et ---
app.UseCors("AllowAngularDevClient");
// -----------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();
