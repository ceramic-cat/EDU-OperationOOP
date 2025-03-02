using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Mousepads;
public class GetMousepads : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/mousepads/{id}", Handle)
        .WithTags("Mousepads")
        .WithSummary("Get Mousepad");

    public record Request(int Id);

    public record Response(
        string Name,
        string Manufacturer,
        int ManufacturersId,
        int InStock,
        decimal Price,
        int Width,
        int Height,
        string Color = "Black"
        );

    private static IResult Handle([AsParameters] Request request, ProductContext db)
    {
        var mousepad = db.PurchasableProducts.OfType<Mousepad>()
            .FirstOrDefault(item => item.Id == request.Id);
        if (mousepad is null) return Results.NotFound();

        var response = new Response(
               Name: mousepad.Name,
               Manufacturer: mousepad.Manufacturer,
               ManufacturersId: mousepad.ManufacturersId,
               InStock: mousepad.InStock,
               Price: mousepad.Price,
               Width: mousepad.Width,
               Height: mousepad.Height,
               Color: mousepad.Color
               );

        return Results.Ok(response);
    }


}
