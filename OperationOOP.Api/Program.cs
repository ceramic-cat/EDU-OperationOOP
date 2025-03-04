
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OperationOOP.Api.Endpoints;
using System.Reflection;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<PurchasableProductContext>(options => options.UseInMemoryDatabase("ProductsDb"));
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Electronics store", 
                    Version ="v1", 
                    Description ="A API for an electronics store" 
                });
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
                options.DocumentFilter<TagOrderDocumentFilter>();

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapEndpoints<Program>();

            app.Run();
        }
    }
}
