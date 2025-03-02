namespace OperationOOP.Api.Endpoints.Mice;
public class GetAllMousepads : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mousepads", Handle)
        .WithTags("Mousepads")
        .WithSummary("Get all Mousepads");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(ProductContext db)
    {
        return db.PurchasableProducts.OfType<Mousepad>()
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
