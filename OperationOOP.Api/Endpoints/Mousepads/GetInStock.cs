namespace OperationOOP.Api.Endpoints.Mice;
public class GetAvailableMousepads : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mousepads/available", Handle)
        .WithTags("Mousepads")
        .WithSummary("Mousepads with at least one in stock");

    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);

    private static List<Response> Handle(ProductContext db)
    {
        return db.PurchasableProducts.OfType<Mousepad>()
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