namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAvailableKeyboards : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/keyboards/available", Handle)
        .WithSummary("Keyboards with at least one in stock");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(IDatabase db)
    {
        return db.Keyboards
            .Where(item => item.InStock > 0)
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                Manufacturer: item.Manufacturer,
                Price: item.Price,
                InStock: item.InStock
                ))
            .ToList();
    }
}