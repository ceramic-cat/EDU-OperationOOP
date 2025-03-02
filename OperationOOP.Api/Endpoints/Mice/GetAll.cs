namespace OperationOOP.Api.Endpoints.Mice;
public class GetAllMice : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mice", Handle)
        .WithTags("Mice")
        .WithSummary("Get all Mice");


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
