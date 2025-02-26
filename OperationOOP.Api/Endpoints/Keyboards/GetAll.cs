
namespace OperationOOP.Api.Endpoints.Keyboards;

public class GetAllKeyboards : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/keyboards", Handle)
        .WithSummary("Keyboards");


    public record Response(
        int Id,
        string Name,
        string Manufacturer,
        decimal Price,
        int InStock);


    private static List<Response> Handle(IDatabase db)
    {
        return db.Keyboards
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
