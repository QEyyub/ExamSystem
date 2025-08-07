using ExamSystem.Application.CQRS.Exams.Commands.CreateExam;
using Microsoft.Extensions.DependencyInjection;
using ExamSystem.Infrastructure;
using ExamSystem.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateExamCommandHandler).Assembly);
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); DataSeeder.Seed(app.Services);

app.Run();
