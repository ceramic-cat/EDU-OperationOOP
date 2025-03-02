namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAvailableKeyboards : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/keyboards/available", Handle)
        .WithTags("Keyboards")
        .WithSummary("Keyboards");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(ProductContext db)
    {
        return db.PurchasableProducts
            .OfType<Keyboard>()
            .Where(item => item.InStock > 0)
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