namespace OperationOOP.Api.Endpoints.Mice;
public class GetAvailableMousepads : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mousepads/available", Handle)
        .WithSummary("Mousepads with at least one in stock");

    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);

    private static List<Response> Handle(IDatabase db)
    {
        return db.Mousepads
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