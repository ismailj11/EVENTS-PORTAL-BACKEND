
using sib_api_v3_sdk.Client;
using EP_BLL.Services.EmailServices;
using EVENTS_PORTAL_BACKEND.Extensions;
using EVENTS_PORTAL_BACKEND.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

builder.Services.addDb(builder.Configuration);
builder.Services.AddAutoMapperConfig();
builder.Services.AddRepositories();
builder.Services.AddServiceExtension(builder.Configuration);

// Add EmailSender service
builder.Services.AddSingleton<EmailSender>(sp =>
    new EmailSender(
        builder.Configuration["BrevoApi:ApiKey"],
        builder.Configuration["BrevoApi:SenderEmail"],
        builder.Configuration["BrevoApi:SenderName"]
    ));

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
options =>
{

    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme,
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Enter The Bearer Authorization : 'Bearer Generated-JWT-Token'"
            ,
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id =JwtBearerDefaults.AuthenticationScheme
                }
            },new string[]
            {

            }
            }
    });

}

);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

// Use CORS middleware
app.UseCors("AllowAngularApp");

app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
