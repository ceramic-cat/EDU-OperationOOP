namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAvailableProducts : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/products/available", Handle)
        .WithTags("Products")
        .WithSummary("Products with at least one in stock");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);

    private static List<Response> Handle(ProductContext db)
    {
        return db.PurchasableProducts
            .Where(item => item.InStock > 0)
            .OrderBy(item => item.Id)
            .Select(item => new Response(
                item.Id,
                item.Name,
                item.Manufacturer,
                item.Price,
                item.InStock
                ))
            .ToList();
    }
}