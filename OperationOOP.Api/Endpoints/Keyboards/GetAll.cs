
using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAllKeyboards : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/keyboards", Handle)
        .WithTags("Keyboards")
        .WithSummary("Keyboards");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(PurchasableProductContext db)
    {
        return db.PurchasableProducts
            .OfType<Keyboard>()
            .Select(item => new Response(
                item.Id,
                item.Name,
                item.Manufacturer,
                item.Price,
                item.InStock))
            .ToList();
    }
}
