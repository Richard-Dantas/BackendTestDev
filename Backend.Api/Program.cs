using BackendTest.Application.Models.Tarefas;
using BackendTest.Application.Models.Tarefas.Validators;
using BackendTest.Application.Models.Usuarios;
using BackendTest.Application.Models.Usuarios.Validators;
using BackendTest.Application.Service.Interfaces.Tarefas;
using BackendTest.Application.Service.Interfaces.Usuarios;
using BackendTest.Application.Service.Tarefas;
using BackendTest.Application.Service.Usuarios;
using BackendTest.Application.Validator.Interfaces.Tarefas;
using BackendTest.Application.Validator.Interfaces.Usuarios;
using BackendTest.Application.Validator.Tarefas;
using BackendTest.Application.Validator.Usuarios;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using BackendTest.Infrastructure.DataAcess.Data;
using BackendTest.Infrastructure.Database.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddScoped<IUsuarioValidator, UsuarioValidator>();
builder.Services.AddScoped<ITarefaValidator, TarefaValidator>();

builder.Services.AddTransient<IValidator<UsuarioRequest>, UsuarioRequestValidator>();
builder.Services.AddTransient<IValidator<TarefaRequest>, TarefaRequestValidator>();

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
