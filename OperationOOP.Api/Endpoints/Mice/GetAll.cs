namespace OperationOOP.Api.Endpoints.Mice;
public class GetAllMice : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mice", Handle)
        .WithSummary("Get all Mice");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(IDatabase db)
    {
        return db.Mice
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
