namespace OperationOOP.Api.Endpoints.Mice;
public class GetAvailableMice : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mice/available", Handle)
        .WithSummary("Computer Mice with at least one in stock");

    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);

    private static List<Response> Handle(ProductContext db)
    {
        return db.PurchasableProducts
            .OfType<Mouse>()
            .Where(item => item.InStock > 0)
            .Select(item => new Response(
                item.Id,
                item.Name,
                item.Manufacturer,
                item.Price,
                item.InStock))
            .ToList();
    }
}