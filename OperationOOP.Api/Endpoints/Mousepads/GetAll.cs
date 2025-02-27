namespace OperationOOP.Api.Endpoints.Mice;
public class GetAllMousepads : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mousepads", Handle)
        .WithSummary("Get all Mousepads");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(IDatabase db)
    {
        return db.Mousepads
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
