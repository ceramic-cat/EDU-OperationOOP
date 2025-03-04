
using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAllProducts : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/products", Handle)
        .WithTags("Products")
        .WithSummary("Get all products");


    public record Response(
        int Id,
        string Name,
        string ProductType,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(PurchasableProductContext db)
    {
        return db.PurchasableProducts
            .OrderBy(item => item.Id) 
            .Select(item => new Response(
                item.Id,
                item.Name,
                item.GetType().Name,
                item.Manufacturer,
                item.Price,
                item.InStock))
            .ToList();
    }
}
